using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ArcMapUI;

namespace ExtentCommand
{
	/// <summary>
	/// Summary description for $safeitemrootname$.
	/// </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[ProgId("$rootnamespace$.$safeitemrootname$")]
	public sealed class OverviewWindow: BaseTool
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

		private IApplication m_application;
		public OverviewWindow()
		{
			//
			// TODO: Define values for the public properties
			//
            base.m_category = ""; //localizable text 
            base.m_caption = "";  //localizable text 
            base.m_message = "";  //localizable text
            base.m_toolTip = "";  //localizable text
            base.m_name = "";   //unique id, non-localizable (e.g. "MyCategory_ArcMapTool")
			try
			{
				//
				// TODO: change resource name if necessary
				//
				string bitmapResourceName = GetType().Name + ".bmp";
				base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
			}
		}

		#region Overridden Class Methods

		/// <summary>
		/// Occurs when this tool is created
		/// </summary>
		/// <param name="hook">Instance of the application</param>
		public override void OnCreate(object hook)
		{
			m_application = hook as IApplication;

            //Disable if it is not ArcMap
            //if (hook is IMxApplication)
            //    base.m_enabled = true;
            //else
            //    base.m_enabled = false;

			// TODO:  Add other initialization code
		}

		/// <summary>
		/// Occurs when this tool is clicked
		/// </summary>
		public override void OnClick()
		{
			// TODO: Add $safeitemrootname$.OnClick implementation
		}

		public override void OnMouseDown(int Button, int Shift, int X, int Y)
		{
			// TODO:  Add $safeitemrootname$.OnMouseDown implementation
		}
  
		public override void OnMouseMove(int Button, int Shift, int X, int Y)
		{
			// TODO:  Add $safeitemrootname$.OnMouseMove implementation
		}
  
		public override void OnMouseUp(int Button, int Shift, int X, int Y)
		{
			// TODO:  Add $safeitemrootname$.OnMouseUp implementation
		}
		#endregion
	}
}
