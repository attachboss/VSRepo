// Updated by XamlIntelliSenseFileGenerator 2022/11/7 18:10:53
#pragma checksum "..\..\AttributeTableFrom.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2B3CD9F758390FB5FFF5DBE2B7B04609EFDC36A6CC0B4FC83251AAC6BD4B1564"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using ArcObjectsDemo;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ArcObjectsDemo
{


    /// <summary>
    /// Symbology
    /// </summary>
    public partial class AttributeTableFrom : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ArcObjectsDemo;component/attributetablefrom.xaml", System.UriKind.Relative);

#line 1 "..\..\AttributeTableFrom.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 10 "..\..\AttributeTableFrom.xaml"
                    ((ArcObjectsDemo.Symbology)(target)).Loaded += new System.Windows.RoutedEventHandler(this.SymbologyFormLoaded);

#line default
#line hidden
                    return;
                case 2:
                    this.SymbologyContainer = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Forms.Integration.WindowsFormsHost AttributeTableContainer;
    }
}
