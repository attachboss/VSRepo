using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ArcObjectsDemo
{
    /// <summary>
    /// Symbology.xaml 的交互逻辑
    /// </summary>
    public partial class AttributeTableForm : Window
    {
        IMap m_map = null;
        ILayer m_layer = null;
        IFeatureLayer currentLayer = null;
        IActiveView m_activeView = null;

        public DataTable AttributeTable { get; set; }
        public AttributeTableForm(IMap map, ILayer pLayer)
        {
            InitializeComponent();
            this.m_map = map;
            this.m_layer = pLayer;
            this.m_activeView = map as IActiveView;
            currentLayer = pLayer as IFeatureLayer;
        }


        void AttributeTableFormLoaded(object sender, RoutedEventArgs e)
        {
            this.Title = $"{m_layer.Name} 属性表";
            OpenAttributeTable(m_layer);
        }

        #region 属性表右键菜单

        void FlashToSelected(object sender, RoutedEventArgs e)
        {
            PanToFlash();

        }

        void ZoomToSelected(object sender, EventArgs e)
        {
            try
            {
                IEnvelope pEnvelope = new EnvelopeClass();
                IFeature selectedFeature = GetCurrentFeature();
                m_map.SelectFeature(currentLayer, selectedFeature);
                //点状要素：放大四倍、置于中心
                if (currentLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                {
                    pEnvelope = m_activeView.Extent;
                    pEnvelope.Height = pEnvelope.Height / 2;
                    pEnvelope.Width = pEnvelope.Width / 2;
                    pEnvelope.CenterAt(selectedFeature.ShapeCopy as IPoint);
                }
                else
                {
                    pEnvelope = selectedFeature.Extent;
                }

                m_activeView.Extent = pEnvelope;
                m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, m_activeView.Extent);
            }
            catch (Exception)
            {
                return;
            }
        }

        void MoveToSelected(object sender, EventArgs e)
        {
            PanToFlash();
        }

        void ZoomToThisLayer(object sender, EventArgs e)
        {
            m_activeView.Extent = ((IGeoDataset)currentLayer).Extent;
            m_activeView.ScreenDisplay.UpdateWindow();
            m_activeView.PartialRefresh((esriViewDrawPhase)6, null, m_activeView.Extent);
        }

        void ZoomToAllSelected(object sender, EventArgs e)
        {
            IEnvelope wholeEnvelope = GetLayerSelectedFeaturesEnvelope(currentLayer);
            if (wholeEnvelope == null) return;

            m_activeView.Extent = wholeEnvelope;
            //m_activeView.ScreenDisplay.UpdateWindow();
            m_activeView.PartialRefresh((esriViewDrawPhase)6, null, m_activeView.Extent);
        }

        void CancelSelectAll(object sender, EventArgs e)
        {
            m_map.ClearSelection();
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, m_activeView.Extent);
            DataGridView1.UnselectAll();
        }

        void DeleteAllSelected(object sender, EventArgs e)
        {
            DeleteSelectedFeatures();
            m_activeView.Refresh();
        } 

        #endregion
        #region 初始化属性表

        /// <summary>
        /// 根据图层字段创建一个只含字段的空DataTable
        /// </summary>
        /// <param name="pLayer"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private static DataTable CreateDataTableByLayer(ILayer pLayer, string tableName)
        {
            DataTable dt = new DataTable(tableName);
            ITable table = pLayer as ITable;
            IField field = null;
            DataColumn column;
            for (int i = 0; i < table.Fields.FieldCount; i++)
            {
                field = table.Fields.Field[i];
                column = new DataColumn(field.Name);
                if (field.Name == table.OIDFieldName)
                {
                    column.Unique = true;
                }
                column.AllowDBNull = field.IsNullable;
                column.Caption = field.AliasName;
                column.DataType = Type.GetType(ParseFieldType(field.Type));
                column.DefaultValue = field.DefaultValue;
                if (field.VarType == 8)
                {
                    column.MaxLength = field.Length;
                }
                dt.Columns.Add(column);
                field = null;
                column = null;
            }
            return dt;
        }


        /// <summary>
        /// 将GeoDatabase字段类型转换成.Net相应的数据类型
        /// </summary>
        /// <param name="fieldType"></param>
        /// <returns></returns>
        public static string ParseFieldType(esriFieldType fieldType)
        {
            switch (fieldType)
            {
                case esriFieldType.esriFieldTypeBlob:
                    return "System.String";

                case esriFieldType.esriFieldTypeDate:
                    return "System.DateTime";

                case esriFieldType.esriFieldTypeDouble:
                    return "System.Double";

                case esriFieldType.esriFieldTypeGeometry:
                    return "System.String";

                case esriFieldType.esriFieldTypeGlobalID:
                    return "System.String";

                case esriFieldType.esriFieldTypeGUID:
                    return "System.String";

                case esriFieldType.esriFieldTypeInteger:
                    return "System.Int32";

                case esriFieldType.esriFieldTypeOID:
                    return "System.String";

                case esriFieldType.esriFieldTypeRaster:
                    return "System.String";

                case esriFieldType.esriFieldTypeSingle:
                    return "System.Single";

                case esriFieldType.esriFieldTypeSmallInteger:
                    return "System.Int32";

                case esriFieldType.esriFieldTypeString:
                    return "System.String";

                default:
                    return "System.String";
            }

        }


        /// <summary>
        /// 填充DataTable中的数据
        /// </summary>
        /// <param name="pLayer"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable FillDataTable(ILayer pLayer, string tableName)
        {
            DataTable dt = CreateDataTableByLayer(pLayer, tableName);
            string shapeType = GetShapeType(pLayer);
            DataRow dr = null;
            ITable table = pLayer as ITable;
            ICursor pCursor = table.Search(null, false);
            IRow pRow = pCursor.NextRow();
            while (pRow != null)
            {
                dr = dt.NewRow();
                for (int i = 0; i < pRow.Fields.FieldCount; i++)
                {
                    if (pRow.Fields.Field[i].Type == esriFieldType.esriFieldTypeGeometry)
                    {
                        dr[i] = shapeType;
                    }
                    else if (pRow.Fields.Field[i].Type == esriFieldType.esriFieldTypeBlob)
                    {
                        dr[i] = "Element";
                    }
                    else
                    {
                        dr[i] = pRow.Value[i];
                    }
                }
                dt.Rows.Add(dr);
                pRow = pCursor.NextRow();
                dr = null;
            }
            return dt;
        }


        /// <summary>
        /// 获得图层的Shape类型
        /// </summary>
        /// <param name="pLayer"></param>
        /// <returns></returns>
        public static string GetShapeType(ILayer pLayer)
        {
            IFeatureLayer featureLayer = pLayer as IFeatureLayer;
            switch (featureLayer.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    return "Point";
                case esriGeometryType.esriGeometryPolyline:
                    return "Polyline";
                case esriGeometryType.esriGeometryPolygon:
                    return "Polygon";
                default:
                    return null;
            }
        }


        /// <summary>
        /// 绑定DataTable
        /// </summary>
        /// <param name="pLayer"></param>
        public void OpenAttributeTable(ILayer pLayer)
        {
            string tableName;
            tableName = GetValidFeatureClassName(pLayer.Name);
            AttributeTable = FillDataTable(pLayer, tableName);
            DataGridView1.ItemsSource = AttributeTable.DefaultView;
            Label1.Content = $"属性表：{tableName}      记录数：{AttributeTable.Rows.Count}";
        }


        /// <summary>
        /// DataTable的表名不允许含有.  用_替换
        /// </summary>
        /// <param name="FeatureClassName"></param>
        /// <returns></returns>
        public static string GetValidFeatureClassName(string FeatureClassName)
        {
            int index = FeatureClassName.IndexOf(".");
            if (index != -1)
            {
                return FeatureClassName.Replace(".", "_");
            }
            return FeatureClassName;
        }

        #endregion


        private void DataGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_map.ClearSelection();
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, m_activeView.Extent);

            var rows = this.DataGridView1.SelectedItems;

            string strOID = string.Empty;
            List<string> OIDList = new List<string>();

            for (int i = 0; i < rows.Count; i++)
            {
                DataRowView row = rows[i] as DataRowView;
                strOID = row.Row["OBJECTID"].ToString();
                OIDList.Add(strOID);
            }
            this.Label2.Content = $"选择项：{OIDList.Count}/{DataGridView1.Items.Count}";
            SelectFeatures(OIDList);
        }



        void SelectFeatures(List<string> OIDList)
        {
            IFeatureClass featureClass = currentLayer.FeatureClass;
            for (int i = 0; i < OIDList.Count; i++)
            {
                IFeature selectedFeature = featureClass.GetFeature(Convert.ToInt32(OIDList[i]));
                m_map.SelectFeature(currentLayer, selectedFeature);
            }
            m_activeView.PartialRefresh((esriViewDrawPhase)6, null, m_activeView.Extent);
        }

        private void PanToFlash()
        {
            try
            {
                IFeature selectedFeature = GetCurrentFeature();
                IGeometry geometry = selectedFeature.Shape;
                IPoint pCenterPoint = new PointClass();
                //double x = (geometry.Envelope.LowerLeft.X + geometry.Envelope.UpperRight.X) / 2;
                //double y = (geometry.Envelope.LowerLeft.Y + geometry.Envelope.UpperRight.Y) / 2;

                double x = geometry.Envelope.LowerLeft.X + geometry.Envelope.Width / 2;
                double y = geometry.Envelope.LowerLeft.Y + geometry.Envelope.Height / 2;
                pCenterPoint.PutCoords(x, y);

                IDisplayTransformation pDisplayTransform = m_activeView.ScreenDisplay.DisplayTransformation;
                IEnvelope pEnvelope = pDisplayTransform.VisibleBounds;
                pEnvelope.CenterAt(pCenterPoint);
                pDisplayTransform.VisibleBounds = pEnvelope;

                //m_map.SelectFeature(currentLayer, selectedFeature);

                //m_activeView.PartialRefresh((esriViewDrawPhase)6, null, m_activeView.Extent);
                m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, m_activeView.Extent);

                m_activeView.ScreenDisplay.UpdateWindow();

                ISymbol symbol = CreateSimpleSsymbol(geometry.GeometryType);
                if (symbol == null) return;
                DrawSymbol(symbol, geometry);
            }
            catch (Exception)
            {
                return;
            }
        }

        private IFeature GetCurrentFeature()
        {
            try
            {
                var row = DataGridView1.SelectedItems[0] as DataRowView;
                string strID = row.Row["OBJECTID"].ToString();

                IFeatureClass featureClass = currentLayer.FeatureClass;
                IFeature selectedFeature = featureClass.GetFeature(Convert.ToInt32(strID));
                return selectedFeature;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private ISymbol CreateSimpleSsymbol(esriGeometryType geometryType)
        {
            ISymbol symbol = null;
            switch (geometryType)
            {
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
                    ISimpleMarkerSymbol markerSymbol = new SimpleMarkerSymbolClass();
                    markerSymbol.Color = getRGB(255, 0, 0);
                    markerSymbol.Size = 8;
                    symbol = markerSymbol as ISymbol;
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                    ISimpleLineSymbol lineSymbol = new SimpleLineSymbolClass();
                    lineSymbol.Color = getRGB(255, 0, 0);
                    lineSymbol.Width = 4;
                    symbol = lineSymbol as ISymbol;
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                    ISimpleFillSymbol fillSymbol = new SimpleFillSymbolClass();
                    fillSymbol.Color = getRGB(255, 0, 0);
                    symbol = fillSymbol as ISymbol;
                    break;
                default:
                    break;
            }
            symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;

            return symbol;
        }


        private IColor getRGB(int yourRed, int yourGreen, int yourBlue)
        {

            IRgbColor pRGB;
            pRGB = new RgbColorClass();
            pRGB.Red = yourRed;
            pRGB.Green = yourGreen;
            pRGB.Blue = yourBlue;
            pRGB.UseWindowsDithering = true;
            return pRGB;
        }


        private void DrawSymbol(ISymbol symbol, IGeometry geometry)
        {
            IScreenDisplay pDisplay = m_activeView.ScreenDisplay;

            pDisplay.StartDrawing(0, (short)esriScreenCache.esriNoScreenCache);
            pDisplay.SetSymbol(symbol);
            for (int i = 0; i < 10; i++)
            {
                switch (geometry.GeometryType)
                {
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
                        pDisplay.DrawPoint(geometry);
                        break;
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryMultipoint:
                        pDisplay.DrawMultipoint(geometry);
                        break;
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                        pDisplay.DrawPolyline(geometry);
                        break;
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                        pDisplay.DrawPolygon(geometry);
                        break;
                    default:
                        break;
                }
                System.Threading.Thread.Sleep(100);
            }
            //m_mapControl.FlashShape(geometry, 5, 300, symbol);
            pDisplay.FinishDrawing();
        }

        private IEnvelope GetLayerSelectedFeaturesEnvelope(IFeatureLayer pFeatLyr)
        {
            IEnvelope layerEnvelope = null;
            IFeatureClass pFeatCls = pFeatLyr.FeatureClass;
            IFeatureSelection selectLayer = pFeatLyr as IFeatureSelection;
            ISelectionSet selectionSet = selectLayer.SelectionSet;
            IEnumIDs enumIDs = selectionSet.IDs;
            IFeature feature;
            int i = 1;
            int iD = enumIDs.Next();
            while (iD != -1) //-1 is reutned after the last valid ID has been reached        
            {
                feature = pFeatCls.GetFeature(iD);
                IEnvelope envelope = feature.ShapeCopy.Envelope;
                if (i == 1)
                    layerEnvelope = envelope;
                else
                {
                    layerEnvelope.Union(envelope);
                }
                i++;
                iD = enumIDs.Next();
            }
            return layerEnvelope;
        }

        private void DeleteSelectedFeatures()
        {
            IFeatureClass pFeatCls = currentLayer.FeatureClass;
            IFeatureSelection selectLayer = currentLayer as IFeatureSelection;
            ISelectionSet selectionSet = selectLayer.SelectionSet;
            IEnumIDs enumIDs = selectionSet.IDs;
            IFeature feature;
            int iD = enumIDs.Next();
            while (iD != -1) //-1 is reutned after the last valid ID has been reached        
            {
                feature = pFeatCls.GetFeature(iD);
                feature.Delete();
                iD = enumIDs.Next();
            }
        }
    }
}
