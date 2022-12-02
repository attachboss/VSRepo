using Esri.ArcGISRuntime.ArcGISServices;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
using Esri.ArcGISRuntime.Mapping.Popups;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Speech.Synthesis;
using System.Globalization;
using System.Linq;

namespace WpfMapApp1
{

    public enum TDTLayerType
    {
        /**
         * 天地图矢量墨卡托投影地图服务
         */
        TDT_VECTOR_MERCATOR,
        /**
         * 天地图矢量2000地图服务
         */
        TDT_VECTOR_2000,

        /**
         * 天地图影像墨卡托地图服务
         */
        TDT_IMAGE_MERCATOR,

        /**
         * 天地图影像2000地图服务
         */
        TDT_IMAGE_2000,
        /**
         * 天地图地形墨卡托地图服务
         */
        TDT_TERRAIN_MERCATOR,
        /**
         * 天地图地形2000地图服务
         */
        TDT_TERRAIN_2000,
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpatialReference _spatialReference = SpatialReference.Create(4490);
        Geodatabase _geoDb;
        GeodatabaseFeatureTable _featureTable;
        FeatureLayer _featureLayer;
        GraphicsOverlayCollection _graphicsOverlays = new GraphicsOverlayCollection();
        string _gdbPath = Path.Combine(Environment.CurrentDirectory, "LocationGDB.geodatabase");

        public MainWindow()
        {
            InitializeComponent();

            Basemap baseMap = TianDiTu(TDTLayerType.TDT_VECTOR_2000, false);

            //初始化地图
            Map map = new Map();
            map.Basemap = baseMap;
            //map.Basemap = new Basemap(BasemapStyle.ArcGISDarkGray);
            MainMapView.Map = map;
            MainMapView.SetViewpoint(new Viewpoint(
                new MapPoint(104.08, 30.68, _spatialReference),
                scale: 50000));

            //去水印
            MainMapView.IsAttributionTextVisible = false;


            //添加Feature图层
            _featureLayer = new FeatureLayer(new Uri("https://services7.arcgis.com/HoHotNAcqE5Lae5U/arcgis/rest/services/BurgerKing/FeatureServer/0"));
            map.OperationalLayers.Add(_featureLayer);
            //添加Graphics图层
            //MainMapView.GraphicsOverlays.AddRange(_graphicsOverlays);



            //new Action(async () => { await CreateDB(); }).Invoke();
            //注册地图点击事件
            MainMapView.GeoViewTapped += IdentifyEvent;
            //MainMapView.GeoViewTapped += AddPointEvent;

            //语音播报
            SpeechSynthesizer synthesiser = new SpeechSynthesizer();
            synthesiser.SelectVoice("Microsoft Zira Desktop");
            //synthesiser.SpeakAsync("fuck track number 6");
        }

        /// <summary>
        /// 加载天地图底图
        /// </summary>
        /// <param name="layerType">底图类型</param>
        /// <param name="label">是否添加注记</param>
        /// <returns>Mapping.Basemap类型对象</returns>
        private Basemap TianDiTu(TDTLayerType layerType, bool label)
        {
            Basemap basemap = new Basemap();
            int SRID = 4490;
            string layer = "";
            string tilematrixset = "";
            switch (layerType)
            {
                case TDTLayerType.TDT_VECTOR_MERCATOR:
                    layer = "vec";
                    tilematrixset = "w";
                    SRID = 3857;
                    break;
                case TDTLayerType.TDT_VECTOR_2000:
                    layer = "vec";
                    tilematrixset = "c";
                    SRID = 4490;
                    break;
                case TDTLayerType.TDT_IMAGE_MERCATOR:
                    layer = "img";
                    tilematrixset = "w";
                    SRID = 3857;
                    break;
                case TDTLayerType.TDT_IMAGE_2000:
                    layer = "img";
                    tilematrixset = "c";
                    SRID = 4490;
                    break;
                case TDTLayerType.TDT_TERRAIN_MERCATOR:
                    layer = "ter";
                    tilematrixset = "w";
                    SRID = 3857;
                    break;
                case TDTLayerType.TDT_TERRAIN_2000:
                    layer = "ter";
                    tilematrixset = "c";
                    SRID = 4490;
                    break;
            }
            SpatialReference spatialReference = SpatialReference.Create(SRID);
            string uriTDT_map = $"http://{{subDomain}}.tianditu.gov.cn/{layer}_{tilematrixset}/wmts?SERVICE=WMTS&REQUEST=GetTile&VERSION=1.0.0&LAYER={layer}&STYLE=default&TILEMATRIXSET={tilematrixset}&FORMAT=tiles&TILEMATRIX={{level}}&TILEROW={{row}}&TILECOL={{col}}&tk=8959c2fd78399b107a6486ee26910098";
            List<LevelOfDetail> lods = new List<LevelOfDetail> {
                new LevelOfDetail(1, 0.703125, 295497593.05875003),
                new LevelOfDetail(2, 0.3515625, 147748796.52937502),
                new LevelOfDetail(3, 0.17578125, 73874398.264687508),
                new LevelOfDetail(4, 0.087890625, 36937199.132343754),
                new LevelOfDetail(5, 0.0439453125, 18468599.566171877),
                new LevelOfDetail(6, 0.02197265625, 9234299.7830859385),
                new LevelOfDetail(7, 0.010986328125, 4617149.8915429693),
                new LevelOfDetail(8, 0.0054931640625, 2308574.9457714846),
                new LevelOfDetail(8, 0.00274658203125, 1154287.4728857423),
                new LevelOfDetail(10, 0.001373291015625, 577143.73644287116),
                new LevelOfDetail(11, 0.0006866455078125, 288571.86822143558),
                new LevelOfDetail(12, 0.00034332275390625, 144285.93411071779),
                new LevelOfDetail(13, 0.000171661376953125, 72142.967055358895),
                new LevelOfDetail(14, 8.58306884765625e-005, 36071.483527679447),
                new LevelOfDetail(15, 4.291534423828125e-005, 18035.741763839724),
                new LevelOfDetail(16, 2.1457672119140625e-005, 9017.8708819198619),
                new LevelOfDetail(17, 1.0728836059570313e-005, 4508.9354409599309),
                new LevelOfDetail(18, 5.3644180297851563e-006, 2254.4677204799655),
                new LevelOfDetail(19, 2.6822090148925781e-006, 1127.2338602399827),
                new LevelOfDetail(20, 1.3411045074462891e-006, 563.61693011999137)
            };
            List<string> subDomains = new List<string>() { "t0", "t1", "t2", "t3", "t4", "t5", "t6", "t7" };
            try
            {
                TileInfo tileInfo = new TileInfo(90, TileImageFormat.Png24, lods, new MapPoint(-180, 90, spatialReference), spatialReference, 256, 256);
                WebTiledLayer webTileLayer = new WebTiledLayer(uriTDT_map, subDomains, tileInfo, new Envelope(-180, -90, 180, 90, spatialReference));
                basemap.BaseLayers.Add(webTileLayer);
                if (label)
                {
                    layer = "cva";
                    string uriTDT_label = $"http://{{subDomain}}.tianditu.gov.cn/{layer}_{tilematrixset}/wmts?SERVICE=WMTS&REQUEST=GetTile&VERSION=1.0.0&LAYER={layer}&STYLE=default&TILEMATRIXSET={tilematrixset}&FORMAT=tiles&TILEMATRIX={{level}}&TILEROW={{row}}&TILECOL={{col}}&tk=8959c2fd78399b107a6486ee26910098";
                    WebTiledLayer webTiledLayerLabel = new WebTiledLayer(uriTDT_label, subDomains, tileInfo, new Envelope(-180, -90, 180, 90, spatialReference));
                    basemap.BaseLayers.Add(webTiledLayerLabel);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return basemap;
        }

        private async Task CreateDB()
        {
            if (!File.Exists(_gdbPath))
            {
                //异步创建GDB
                _geoDb = await Geodatabase.CreateAsync(_gdbPath);
            }
            _geoDb = await Geodatabase.OpenAsync(_gdbPath);
            //添加要素表信息
            var tableDescription = new TableDescription("LocationTable", SpatialReferences.Wgs84, GeometryType.Point)
            {
                HasAttachments = false,
                HasM = false,
                HasZ = false,
            };
            tableDescription.FieldDescriptions.Add(new FieldDescription("oid", FieldType.OID));
            tableDescription.FieldDescriptions.Add(new FieldDescription("datetime", FieldType.Date));
            //异步创建要素表
            _featureTable = await _geoDb.CreateTableAsync(tableDescription);

        }

        /// <summary>
        /// 点击地图创建点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPointEvent(object sender, GeoViewInputEventArgs e)
        {
            _graphicsOverlays.Add(CreatePointGraphicOverlay(e));
            //_ = AddPointFeature(e.Location);
        }


        /// <summary>
        /// 点击地图识别事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void IdentifyEvent(object sender, GeoViewInputEventArgs e)
        {
            //IdentifyGraphicsOverlayResult igor = await MainMapView.IdentifyGraphicsOverlayAsync(_graphicsOverlays[0], e.Position, 10d, false, 1);

            FeatureLayer idtentiftLayer = MainMapView.Map.OperationalLayers.First() as FeatureLayer;
            IdentifyLayerResult result = await MainMapView.IdentifyLayerAsync(idtentiftLayer, e.Position, 20, true);
            if (result != null)
            {
                CalloutDefinition callout = new CalloutDefinition("title", "details");
                MainMapView.ShowCalloutAt(e.Location, callout);
                //IdentifyLayerResult result = await MainMapView.IdentifyLayerAsync(_featureLayer, e.Position, 10d, false);
                //MessageBox.Show(result.GeoElements[0].Attributes["key"].ToString());
            }
        }

        /// <summary>
        /// 创建点
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private static GraphicsOverlay CreatePointGraphicOverlay(GeoViewInputEventArgs e)
        {
            SimpleMarkerSymbol symbol = new SimpleMarkerSymbol(SimpleMarkerSymbolStyle.X, Color.FromArgb(0, 0, 0), 10)
            {
                Outline = new SimpleLineSymbol(SimpleLineSymbolStyle.Solid, Color.DarkGray, 5),
            };
            GraphicsOverlay pointGraphic = new GraphicsOverlay()
            {
                Renderer = new SimpleRenderer(symbol),
            };
            Graphic graphic = new Graphic(e.Location);
            pointGraphic.Graphics.Add(graphic);
            return pointGraphic;
        }


        /// <summary>
        /// 将点参数存入GDB
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private async Task AddPointFeature(MapPoint point)
        {
            Dictionary<string, object> attr = new Dictionary<string, object>();
            attr["datetime"] = DateTime.UtcNow;
            Feature feature = _featureTable.CreateFeature(attr, point);
            await _featureTable.AddFeatureAsync(feature);
        }
    }
}
