﻿#pragma checksum "..\..\AttributeTableForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A7DE8B915B4739D211FCB9BCD09D6E29EE51E725BE6D6DB9363B65C4D7150C88"
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


namespace ArcObjectsDemo {
    
    
    /// <summary>
    /// AttributeTableForm
    /// </summary>
    public partial class AttributeTableForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\AttributeTableForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost AttributeTableContainer;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AttributeTableForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridView1;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AttributeTableForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContextMenu DataGridMenu;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AttributeTableForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label1;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\AttributeTableForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ArcObjectsDemo;component/attributetableform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AttributeTableForm.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\AttributeTableForm.xaml"
            ((ArcObjectsDemo.AttributeTableForm)(target)).Loaded += new System.Windows.RoutedEventHandler(this.AttributeTableFormLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AttributeTableContainer = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 3:
            this.DataGridView1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 14 "..\..\AttributeTableForm.xaml"
            this.DataGridView1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGridView1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DataGridMenu = ((System.Windows.Controls.ContextMenu)(target));
            return;
            case 5:
            
            #line 18 "..\..\AttributeTableForm.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.FlashToSelected);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 19 "..\..\AttributeTableForm.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ZoomToSelected);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 20 "..\..\AttributeTableForm.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MoveToSelected);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 21 "..\..\AttributeTableForm.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ZoomToThisLayer);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 22 "..\..\AttributeTableForm.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ZoomToAllSelected);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 23 "..\..\AttributeTableForm.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelSelectAll);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 24 "..\..\AttributeTableForm.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteAllSelected);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.Label2 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

