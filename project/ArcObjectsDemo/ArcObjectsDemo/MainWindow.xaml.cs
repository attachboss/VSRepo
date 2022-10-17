using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
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
        IActiveView pActiveView;
        AxMapControl mapCtrl;
        AxToolbarControl toolbarCtrl;
        AxTOCControl tocCtrl;
        IMapDocument mapDoc;
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
        }



 

        void MapCtrl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            mapCtrl.MousePointer = esriControlsMousePointer.esriPointerArrow;
            IEnvelope pEnvelope = mapCtrl.TrackRectangle();
            pActiveView.Extent = pEnvelope;
            pActiveView.Refresh();
            mapCtrl.MousePointer = esriControlsMousePointer.esriPointerDefault;
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
            //给工具栏控件添加项目
            toolbarCtrl.AddItem("esriControls.ControlsOpenDocCommand");
            toolbarCtrl.AddItem("esriControls.ControlsAddDataCommand");
            toolbarCtrl.AddItem("esriControls.ControlsSaveAsDocCommand");
            toolbarCtrl.AddItem("esriControls.ControlsMapNavigationToolbar");
            toolbarCtrl.AddItem("esriControls.ControlsMapIdentifyTool");
            toolbarCtrl.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            //打开默认地图文档
            OpenDefaultMapDoc();
            //添加自定义命令
            toolbarCtrl.AddItem(new ZoomToLayer(), -1, -1, true, 20, esriCommandStyles.esriCommandStyleIconOnly);
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
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();
        }
    }
}
