using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;

namespace ExtentCommand
{
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ExtentCommand.ZoomTriple")]
    public sealed class ZoomTriple : BaseCommand
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
		public ZoomTriple()
        {
			//实例化全局hook
			hookHelper = new HookHelperClass();
            base.m_category = "";
            base.m_caption = "缩放三倍当前的视图";
            base.m_message = "";
            base.m_toolTip = "";
            base.m_name = "";
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
            Zoom();
		}

        #endregion
		



		/// <summary>
		/// 缩放到TOC选定的图层
		/// </summary>
		/// <param name="mxDocument"></param>
        public void Zoom()
        {

            IActiveView activeView = hookHelper.ActiveView;
			IEnvelope envelope = activeView.Extent;
			//宽高分别除根号三
            envelope.Height *= Math.Sqrt(3);
            envelope.Width *= Math.Sqrt(3);
			activeView.Extent = envelope;
            activeView.Refresh();
        }

    }
}
