﻿#pragma checksum "..\..\..\Views\ConnectPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "207164BA5BFE79B4EF259319D9C097FC3A3DDA9AB8263D057529FF9B980ED433"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using InvoiceManager.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace InvoiceManager.Views {
    
    
    /// <summary>
    /// ConnectPage
    /// </summary>
    public partial class ConnectPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 62 "..\..\..\Views\ConnectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border allUsersBorder;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Views\ConnectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView invoiceListView;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\Views\ConnectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\Views\ConnectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox newPassword;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\Views\ConnectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox cfmPassword;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\Views\ConnectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox dbPassword;
        
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
            System.Uri resourceLocater = new System.Uri("/InvoiceManager;component/views/connectpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ConnectPage.xaml"
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
            this.allUsersBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.invoiceListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 117 "..\..\..\Views\ConnectPage.xaml"
            this.txtPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.onChangePass);
            
            #line default
            #line hidden
            return;
            case 4:
            this.newPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 132 "..\..\..\Views\ConnectPage.xaml"
            this.newPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.onChangeNewPass);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cfmPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 134 "..\..\..\Views\ConnectPage.xaml"
            this.cfmPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.onChangeCfmPass);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dbPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 199 "..\..\..\Views\ConnectPage.xaml"
            this.dbPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.onChangeDBPass);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

