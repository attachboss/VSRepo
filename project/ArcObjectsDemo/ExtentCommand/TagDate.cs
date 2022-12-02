using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using stdole;

namespace ExtentCommand
{
    /// <summary>
    /// Summary description for $safeitemrootname$.
    /// </summary>
    [Guid("ac63b0f5-56bf-438b-9e10-e4e96db8225a")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ExtentCommand.TagDate")]
    public sealed class TagDate : BaseTool
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
            ControlsCommands.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Unregister(regKey);

        }

        #endregion
        #endregion

        private IHookHelper m_hookHelper;

        public TagDate()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; //localizable text 
            base.m_caption = "标注当前时间";  //localizable text 
            base.m_message = "";  //localizable text
            base.m_toolTip = "";  //localizable text
            base.m_name = "";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
            try
            {
                //
                // TODO: change resource name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
                base.m_cursor = new System.Windows.Forms.Cursor(GetType(), GetType().Name + ".cur");
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
            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                {
                    m_hookHelper = null;
                }
            }
            catch
            {
                m_hookHelper = null;
            }

            if (m_hookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            IActiveView activeView = m_hookHelper.ActiveView;

            ITextElement textElement = new TextElementClass();
            ITextSymbol textSymbol = new TextSymbolClass();
            textSymbol.Size = 25;
            stdole.Font pFont = new stdole.StdFontClass()
            {
                Name = "微软雅黑",
            };
            textSymbol.Color = new RgbColorClass() { RGB = 255 };
            textSymbol.Font = pFont as IFontDisp;
            textElement.Symbol = textSymbol;
            textElement.Text = $"{DateTime.Now.ToLocalTime()}";

            IElement element = (IElement)textElement;
            IPoint point = new PointClass
            {
                X = 0,
                Y = 0
            };
            element.Geometry = point;

            //activeView.GraphicsContainer.DeleteAllElements();
            activeView.GraphicsContainer.AddElement(element, 0);
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
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
