using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ArcObjectsDemo.ContextMenu;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DisplayUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using ExtentCommand;

namespace ArcObjectsDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        AxMapControl mapCtrl;
        AxToolbarControl toolbarCtrl;
        AxTOCControl tocCtrl;
        AxMapControl engerEyeCtrl;
        string MxFilePath;
        IActiveView pActiveView;
        IMapDocument mapDoc;
        IToolbarMenu menuMap;
        IToolbarMenu menuLayer;
        public MainWindow()
        {
            InitializeComponent();
            InitialCtrls();
        }


        /// <summary>
        /// 初始化Ax控件
        /// </summary>
        private void InitialCtrls()
        {
            mapCtrl = new AxMapControl();
            MapViewContainer.Child = mapCtrl;
            toolbarCtrl = new AxToolbarControl();
            ToolBarContainer.Child = toolbarCtrl;
            tocCtrl = new AxTOCControl();
            TocContainer.Child = tocCtrl;
            engerEyeCtrl = new AxMapControl();
            EngerEyeContainer.Child = engerEyeCtrl;


        }



        #region 事件处理

        /// <summary>
        /// 地图点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MapCtrl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //缩放
            //pActiveView.Extent = pEnvelope;
            //pActiveView.Refresh();

            //多边形选择
            //SelectFeaturesPolygon();

            //SQL选择
            //SelectFeauresBySQL("NAME = 'Beijing'");


        }

        /// <summary>
        /// 地图鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapCtrl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            //左下角显示当前坐标
            esriUnits mapUnits = this.mapCtrl.Map.MapUnits;
            string sMapUnits = String.Empty;
            switch (mapUnits)
            {
                case esriUnits.esriCentimeters:
                    sMapUnits = "厘米";
                    break;
                case esriUnits.esriDecimalDegrees:
                    sMapUnits = "十进制";
                    break;
                case esriUnits.esriDecimeters:
                    sMapUnits = "分米";
                    break;
                case esriUnits.esriFeet:
                    sMapUnits = "尺";
                    break;
                case esriUnits.esriInches:
                    sMapUnits = "英寸";
                    break;
                case esriUnits.esriKilometers:
                    sMapUnits = "千米";
                    break;
                case esriUnits.esriMeters:
                    sMapUnits = "米";
                    break;
                case esriUnits.esriMiles:
                    sMapUnits = "英里";
                    break;
                case esriUnits.esriMillimeters:
                    sMapUnits = "毫米";
                    break;
                case esriUnits.esriNauticalMiles:
                    sMapUnits = "海里";
                    break;
                case esriUnits.esriPoints:
                    sMapUnits = "点";
                    break;
                case esriUnits.esriUnitsLast:
                    sMapUnits = "UnitsLast";
                    break;
                case esriUnits.esriUnknownUnits:
                    sMapUnits = "未知单位";
                    break;
                case esriUnits.esriYards:
                    sMapUnits = "码";
                    break;
                default:
                    break;
            }
            this.Label1.Content = String.Format("当前坐标：{0:F4}, {1:F4}  {2}", e.mapX, e.mapY, sMapUnits);
        }

        /// <summary>
        /// TOC点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        void TOCCtrl_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap map = null;
            ILayer layer = null;
            object other = null;
            object index = null;

            tocCtrl.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);

            if (e.button == 1)
            {
                //左键样式符号
                if (item == esriTOCControlItem.esriTOCControlItemLegendClass)
                {

                    //获取当前图层的符号样式
                    ILegendClass legendClass = new LegendClassClass();
                    ISymbol symbol = null;
                    if (other is ILegendGroup && (int)index != 1)
                    {
                        legendClass = ((ILegendGroup)other).Class[(int)index];
                        symbol = legendClass.Symbol;
                    }
                    if (symbol == null)
                        return;

                    //调用ArcMap中的符号选择器
                    ISymbolSelector selector = new SymbolSelectorClass();
                    bool flag = false;
                    selector.AddSymbol(symbol);
                    flag = selector.SelectSymbol(0);
                    if (flag)
                    {
                        legendClass.Symbol = selector.GetSymbolAt(0);
                    }
                    //刷新地图和TOC
                    mapCtrl.ActiveView.Refresh();
                    tocCtrl.Refresh();
                }

            }
            if (e.button == 2)
            {
                //判断右键类型
                if (item == esriTOCControlItem.esriTOCControlItemMap)
                {
                    tocCtrl.SelectItem(map, null);
                }
                else if (item == esriTOCControlItem.esriTOCControlItemLayer)
                {
                    tocCtrl.SelectItem(layer, null);
                    mapCtrl.CustomProperty = layer;
                }

                //展示右键菜单
                if (item == esriTOCControlItem.esriTOCControlItemMap) menuMap.PopupMenu(e.x, e.y, tocCtrl.hWnd);
                if (item == esriTOCControlItem.esriTOCControlItemLayer)
                {
                    //只打开一次属性表，因此在加入TOC右键菜单后删除
                    menuLayer.AddItem(new OpenAttributeTable(), -1, 0, false, esriCommandStyles.esriCommandStyleIconAndText);
                    menuLayer.PopupMenu(e.x, e.y, tocCtrl.hWnd);
                    menuLayer.Remove(0);
                }
            }
        }

        /// <summary>
        /// 地图绘制前事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MapCtrl_OnBeforeScreenDraw(object sender, IMapControlEvents2_OnBeforeScreenDrawEvent e)
        {
            mapCtrl.MousePointer = esriControlsMousePointer.esriPointerHourglass;

        }

        /// <summary>
        /// 地图绘制后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapCtrl_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            mapCtrl.MousePointer = esriControlsMousePointer.esriPointerDefault;


        }

        /// <summary>
        /// 地图视图变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapCtrl_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {

            IEnvelope envelope = e.newEnvelope as IEnvelope;
            IGraphicsContainer graphicContainer = engerEyeCtrl.Map as IGraphicsContainer;

            DrawEnvelopeElement(envelope, graphicContainer);
        }

        /// <summary>
        /// 新地图替换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapCtrl_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //两个控件之间传值
            engerEyeCtrl.ClearLayers();
            IMap pMap;
            pMap = mapCtrl.Map;
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                engerEyeCtrl.Map.AddLayer(pMap.Layer[i]);
            }
            engerEyeCtrl.Map.SpatialReference = pMap.SpatialReference;
            engerEyeCtrl.Extent = mapCtrl.FullExtent;

        }

        /// <summary>
        /// 鹰眼地图点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void EngerEyeCtrl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            IPoint point = new PointClass();
            point.X = e.mapX;
            point.Y = e.mapY;
            mapCtrl.CenterAt(point);
        }



        #endregion


        #region 选择要素

        /// <summary>
        /// 根据SQL语句选择
        /// </summary>
        /// <param name="sql"></param>
        void SelectFeauresBySQL(string sql)
        {
            ClearSelectedFeatures();
            IFeatureLayer layer = mapCtrl.Map.Layer[0] as IFeatureLayer;

            IFeatureSelection feaSel = layer as IFeatureSelection;
            if (feaSel != null)
            {
                feaSel.Clear();
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = sql;
                feaSel.SelectFeatures(filter, esriSelectionResultEnum.esriSelectionResultNew, false);
                pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);


                pActiveView.ScreenDisplay.UpdateWindow();
                var resultSet = feaSel.SelectionSet;
                resultSet.Search(null, true, out ICursor cursor);
                IRow row = cursor.NextRow();
                IFeature feature = null;
                while (row != null)
                {
                    feature = row as IFeature;
                    row = cursor.NextRow();
                }
                if (feature != null)
                {

                    //FlashGeometry(feature.Shape, new RgbColor()
                    //{
                    //    Red = 120,
                    //    Green = 0,
                    //    Blue = 0
                    //}, pActiveView.ScreenDisplay, 500);
                }


            }
        }


        /// <summary>
        /// 根据绘制面选择要素
        /// </summary>
        void SelectFeaturesPolygon()
        {
            ClearSelectedFeatures();
            IGeometry geom = mapCtrl.TrackPolygon();
            //创建选择环境
            ISelectionEnvironment pse = new SelectionEnvironmentClass();
            pse.CombinationMethod = esriSelectionResultEnum.esriSelectionResultNew;
            if (geom != null)
            {
                mapCtrl.Map.SelectByShape(geom, pse, false);
                pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                DrawMapShape(geom);
            }
        }


        /// <summary>
        /// 清空并刷新地图选择内容
        /// </summary>
        private void ClearSelectedFeatures()
        {
            mapCtrl.Map.ClearSelection();
            pActiveView.Refresh();
        }

        #endregion


        #region 工具类

        /// <summary>
        /// 绘制几何
        /// </summary>
        /// <param name="pGeom"></param>
        private void DrawMapShape(IGeometry pGeom)
        {
            IRgbColor pColor;
            pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;

            ILineSymbol lineSymbol = new SimpleLineSymbolClass();
            lineSymbol.Color = pColor;
            //新建一个绘制图形的填充符号
            ISimpleFillSymbol pFillsyl;
            pFillsyl = new SimpleFillSymbolClass();
            pFillsyl.Outline = lineSymbol;
            //pFillsyl.Color = pColor;
            pFillsyl.Style = esriSimpleFillStyle.esriSFSHollow;
            object oFillsyl = pFillsyl;

            mapCtrl.DrawShape(pGeom, ref oFillsyl);
        }

        /// <summary>
        /// 获取TOC控件选中的图层
        /// </summary>
        /// <returns></returns>
        object GetSeletedIndex(AxTOCControl tocCtrl)
        {
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap map = null;
            ILayer layer = null;
            object other = null;
            object index = null;

            //对于没有确定返回值 因此使用此法
            tocCtrl.GetSelectedItem(ref item, ref map, ref layer, ref other, ref index);

            return index;
        }

        /// <summary>
        /// 添加鹰眼框
        /// </summary>
        /// <param name="envelope"></param>
        /// <param name="graphicContainer"></param>
        private static void DrawEnvelopeElement(IEnvelope envelope, IGraphicsContainer graphicContainer)
        {
            IActiveView activeView = graphicContainer as IActiveView;
            IRectangleElement rect = new RectangleElementClass();
            IElement element = rect as IElement;

            IPoint pointWN = envelope.UpperLeft;
            IPoint pointES = envelope.LowerRight;
            activeView.ScreenDisplay.DisplayTransformation.FromMapPoint(pointWN, out int xWN, out int yWN);
            activeView.ScreenDisplay.DisplayTransformation.FromMapPoint(pointES, out int xES, out int yES);
            //设置鹰眼窗口最小缩放范围
            if (Math.Abs(yWN - yES) < 12)
            {
                pointWN = activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(xWN - 10, yWN - 6);
                pointES = activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(xWN + 10, yWN + 6);
                envelope = new EnvelopeClass
                {
                    UpperLeft = pointWN,
                    LowerRight = pointES
                };
            }
            element.Geometry = envelope;

            IFillShapeElement fillShapeElement = element as IFillShapeElement;
            fillShapeElement.Symbol = new SimpleFillSymbolClass()
            {
                Color = new RgbColorClass()
                {
                    Transparency = 0,
                },
                Outline = new SimpleLineSymbolClass()
                {
                    Color = new RgbColorClass()
                    {
                        RGB = 0,
                        Transparency = 255,
                    },
                    Width = 2.5,
                },
            };

            graphicContainer.DeleteAllElements();
            graphicContainer.AddElement(element, 0);
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        #endregion


        /// <summary>
        /// 程序启动时默认地图文档
        /// </summary>
        private void OpenDefaultMapDoc(string path)
        {
            mapDoc = new MapDocumentClass();
            if (mapCtrl.CheckMxFile(path))
            {
                //地图更换事件要求使用控件方式打开mxd地图文档
                mapCtrl.LoadMxFile(path, 0, Type.Missing);
                //layoutCtrl.LoadMxFile(path, Type.Missing);
                //mapDoc.Open(path, null);
                //if (mapDoc.MapCount != 0)
                //{
                //    mapCtrl.Map = mapDoc.Map[0];
                //    pActiveView = mapDoc.Map[0] as IActiveView;
                //    pActiveView.Extent = mapCtrl.FullExtent;
                //    pActiveView.Refresh();
                //}

            }
        }


        /// <summary>
        /// 注册所有控件事件
        /// </summary>
        void RegistAllEvents()
        {
            //注册地图绘制前事件
            mapCtrl.OnBeforeScreenDraw += new IMapControlEvents2_Ax_OnBeforeScreenDrawEventHandler(MapCtrl_OnBeforeScreenDraw);
            //注册地图绘制后事件
            mapCtrl.OnAfterScreenDraw += new IMapControlEvents2_Ax_OnAfterScreenDrawEventHandler(MapCtrl_OnAfterScreenDraw);
            //注册地图MouseDown事件
            mapCtrl.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(MapCtrl_OnMouseDown);
            mapCtrl.OnMouseMove += new IMapControlEvents2_Ax_OnMouseMoveEventHandler(MapCtrl_OnMouseMove);
            //注册地图视图变化事件
            mapCtrl.OnExtentUpdated += new IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(MapCtrl_OnExtentUpdated);
            mapCtrl.OnMapReplaced += new IMapControlEvents2_Ax_OnMapReplacedEventHandler(MapCtrl_OnMapReplaced);
            //注册TOC点击事件
            tocCtrl.OnMouseDown += new ITOCControlEvents_Ax_OnMouseDownEventHandler(TOCCtrl_OnMouseDown);
            //注册鹰眼地图点击事件
            engerEyeCtrl.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(EngerEyeCtrl_OnMouseDown);
        }








 



        private void OpenDefaultMapDoc()
        {
            string path = "D://File//专业课//地图制图//150投影.mxd";
            mapDoc = new MapDocumentClass();
            mapDoc.Open(path, null);
            if (mapDoc.MapCount != 0)
            {
                mapCtrl.Map = mapDoc.Map[0];
                pActiveView = mapDoc.Map[0] as IActiveView;
                pActiveView.Extent = mapCtrl.FullExtent;
                pActiveView.Refresh();
            }
            //注册MouseDown事件
            //mapCtrl.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(this.MapCtrl_OnMouseDown);
        }

        /// <summary>
        /// 窗体加载后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            //窗体加载完成后再设置控件关系
            tocCtrl.SetBuddyControl(mapCtrl);
            toolbarCtrl.SetBuddyControl(mapCtrl);
            #region 工具栏、TOC右键菜单
            //给工具栏控件添加项目

            //generic
            toolbarCtrl.AddItem("esriControls.ControlsOpenDocCommand", -1, -1,
                false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            toolbarCtrl.AddItem("esriControls.ControlsSaveAsDocCommand", -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            toolbarCtrl.AddItem("esriControls.ControlsAddDataCommand", -1, -1,
                false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            //layout
            toolbarCtrl.AddItem("esriControls.ControlsPagePanTool", -1, -1, true,
                0, esriCommandStyles.esriCommandStyleIconOnly);
            toolbarCtrl.AddItem("esriControls.ControlsPageZoomWholePageCommand", -1,
                -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            //navigation
            toolbarCtrl.AddItem("esriControls.ControlsMapPanTool", -1, -1, false,
                0, esriCommandStyles.esriCommandStyleIconOnly);
            toolbarCtrl.AddItem("esriControls.ControlsMapFullExtentCommand", -1, -
                1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            toolbarCtrl.AddItem("esriControls.ControlsMapZoomToLastExtentBackCommand",
                -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            toolbarCtrl.AddItem(
                "esriControls.ControlsMapZoomToLastExtentForwardCommand", -1, -1, false,
                0, esriCommandStyles.esriCommandStyleIconOnly);

            //inquiry
            toolbarCtrl.AddItem("esriControls.ControlsMapIdentifyTool", -1, -1,
                true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            toolbarCtrl.AddItem("esriControls.ControlsSelectFeaturesTool", -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            toolbarCtrl.AddItem("esriControls.ControlsMapFindCommand", -1, -1,
                false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            toolbarCtrl.AddItem("esriControls.ControlsMapMeasureTool", -1, -1,
                false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            //Palette
            IToolbarPalette toolbarPalette = new ToolbarPaletteClass();
            toolbarPalette.AddItem("esriControls.ControlsNewMarkerTool", -1, -1);
            toolbarPalette.AddItem("esriControls.ControlsNewLineTool", -1, -1);
            toolbarPalette.AddItem("esriControls.ControlsNewCircleTool", -1, -1);
            toolbarPalette.AddItem("esriControls.ControlsNewEllipseTool", -1, -1);
            toolbarPalette.AddItem("esriControls.ControlsNewRectangleTool", -1, -1);
            toolbarPalette.AddItem("esriControls.ControlsNewPolygonTool", -1, -1);
            toolbarCtrl.AddItem(toolbarPalette, 0, -1, false, 0,
                esriCommandStyles.esriCommandStyleIconOnly);

            //添加自定义命令
            toolbarCtrl.AddItem(new ExtentCommand.ZoomTriple(), -1, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            toolbarCtrl.AddItem(new ExtentCommand.TagDate(), -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconAndText);
            toolbarCtrl.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);



            //创建上下文菜单对象
            menuMap = new ToolbarMenuClass();
            menuLayer = new ToolbarMenuClass();
            //添加TOC图组右键菜单命令
            menuMap.AddItem("esriControls.ControlsAddDataCommand", 0, 0, false, esriCommandStyles.esriCommandStyleIconAndText);
            menuMap.AddItem(new LayerVisibility(), 1, 1, false, esriCommandStyles.esriCommandStyleIconAndText);
            menuMap.AddItem(new LayerVisibility(), 2, 2, false, esriCommandStyles.esriCommandStyleIconAndText);
            menuMap.AddSubMenu("esriControls.ControlsFeatureSelectionMenu", 3, true);
            //添加TOC图层右键菜单命令
            menuLayer.AddItem(new RemoveLayer(), -1, 0, false, esriCommandStyles.esriCommandStyleIconAndText);
            menuLayer.AddItem(new ScaleThresholds(), 1, 1, true, esriCommandStyles.esriCommandStyleIconAndText);
            menuLayer.AddItem(new ScaleThresholds(), 2, 2, false, esriCommandStyles.esriCommandStyleIconAndText);
            menuLayer.AddItem(new ScaleThresholds(), 3, 3, false, esriCommandStyles.esriCommandStyleIconAndText);
            menuLayer.AddItem(new LayerSelectable(), 1, 4, true, esriCommandStyles.esriCommandStyleIconAndText);
            menuLayer.AddItem(new LayerSelectable(), 2, 5, false, esriCommandStyles.esriCommandStyleIconAndText);
            menuLayer.AddItem(new ContextMenu.ZoomToLayer(), -1, 6, true, esriCommandStyles.esriCommandStyleIconAndText);
            //设置上下文菜单设置的对象
            menuMap.SetHook(mapCtrl);
            menuLayer.SetHook(mapCtrl);
            #endregion




            //注册事件
            RegistAllEvents();

            //打开默认地图文档
            MxFilePath = "D://File//专业课//地图制图//150投影.mxd";
            OpenDefaultMapDoc(MxFilePath);

            //首次运行时添加鹰眼窗口
            DrawEnvelopeElement(mapCtrl.ActiveView.Extent, engerEyeCtrl.Map as IGraphicsContainer);


        }

        /// <summary>
        /// 获取TOC控件选中的图层
        /// </summary>
        /// <returns></returns>
        object GetSeletedIndex()
        {
            IBasicMap map = null;
            ILayer layer = null;
            object other = null;
            object index = null;
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;

            //对于没有确定返回值 因此使用此法
            tocCtrl.GetSelectedItem(ref item, ref map, ref layer, ref other, ref index);

            return index;
        }

        /// <summary>
        /// 窗体关闭后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("是否保存更改？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                mapDoc.Save();
            }
            else if (res == System.Windows.Forms.DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                return;
            }
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();
        }



    }
}
