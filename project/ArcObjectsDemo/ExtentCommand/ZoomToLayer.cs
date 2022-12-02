using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace ExtentCommand
{
	[Guid("4D81E970-F87C-4734-8500-4E5493DCAD15")]
	[ClassInterface(ClassInterfaceType.None)]
	[ProgId("ExtentCommand.ZoomToLayerZoomToLayer")]
	public sealed class ZoomToLayer : BaseCommand
	{
		#region COM Registration Function(s)
		[ComRegisterFunction()]
		[ComVisible(false)]
		static void RegisterFunction(Type registerType)
		{
			// Required for ArcGIS Component Category Registrar support
			ArcGISCategoryRegistration(registerType);

			//
			// TODO: Add any COM registration code here
			//
		}

		[ComUnregisterFunction()]
		[ComVisible(false)]
		static void UnregisterFunction(Type registerType)
		{
			// Required for ArcGIS Component Category Registrar support
			ArcGISCategoryUnregistration(registerType);

			//
			// TODO: Add any COM unregistration code here
			//
		}

		#region ArcGIS Component Category Registrar generated code
		/// <summary>
		/// Required method for ArcGIS Component Category registration -
		/// Do not modify the contents of this method with the code editor.
		/// </summary>
		private static void ArcGISCategoryRegistration(Type registerType)
		{
			string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
			MxCommands.Register(regKey);

		}
		/// <summary>
		/// Required method for ArcGIS Component Category unregistration -
		/// Do not modify the contents of this method with the code editor.
		/// </summary>
		private static void ArcGISCategoryUnregistration(Type registerType)
		{
			string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
			MxCommands.Unregister(regKey);

		}

		#endregion
		#endregion

		private IHookHelper hookHelper;
		public ZoomToLayer()
        {
			//实例化全局hook
			hookHelper = new HookHelperClass();
            base.m_category = "Developer Samples";
            base.m_caption = "Zoom To Layer";
            base.m_message = "Zoom to the extent of the active layer in the TOC";
            base.m_toolTip = "Zoom To Layer";
            base.m_name = "DeveloperSamples_ZoomToLayer";
            try
            {
                string bitmapResourceName = GetType().Name + ".png";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

		#region Overridden Class Methods

		/// <summary>
		/// 实现自抽象父类
		/// </summary>
		/// <param name="hook">Instance of the application</param>
		public override void OnCreate(object hook)
		{
            if (hook == null)
                return;

			hookHelper.Hook = hook;
            //Disable if it is not ArcMap
            //if (hook is IMxApplication)
            //    base.m_enabled = true;
            //else
            //    base.m_enabled = false;

		}

		/// <summary>
		/// 命令点击处理
		/// </summary>
		public override void OnClick()
        {
			//IMxDocument mxDocument = (IMxDocument)hookHelper.FocusMap;

            ZoomToLayerInTOC();
		}

        #endregion
		

		/// <summary>
		/// 从IApplication中获取mxDoc对象
		/// </summary>
		/// <param name="application"></param>
		/// <returns></returns>
        public IMxDocument GetMxDocument(IApplication application)
        {

            if (application == null)
            {
                return null;
            }

            IMxDocument mxDocument = (IMxDocument)(application.Document);

            return mxDocument;

        }


		/// <summary>
		/// 缩放到TOC选定的图层
		/// </summary>
		/// <param name="mxDocument"></param>
        public void ZoomToLayerInTOC(/*IMxDocument mxDocument*/)
        {
            //if (mxDocument == null)
            //{
            //    return;
            //}
            //IActiveView activeView = mxDocument.ActiveView;

            //IContentsView contentsView = mxDocument.CurrentContentsView;

            IActiveView activeView = hookHelper.ActiveView;
            ILayer layer = hookHelper.FocusMap.Layer[1];

            activeView.Extent = layer.AreaOfInterest;
            activeView.Refresh();
        }

    }
}
