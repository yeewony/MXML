﻿#pragma checksum "..\..\W_MessageBox.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E852468B8F688682C5D8983E7A1298E4F4A885DE841F723643C55BFA96744288"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WinniesMessageBox;


namespace WinniesMessageBox {
    
    
    /// <summary>
    /// W_MessageBox
    /// </summary>
    public partial class W_MessageBox : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\W_MessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gBody;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\W_MessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbText;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\W_MessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnYes;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\W_MessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNo;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\W_MessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOK;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\W_MessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gBar;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\W_MessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
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
            System.Uri resourceLocater = new System.Uri("/WinniesMessageBox;component/w_messagebox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\W_MessageBox.xaml"
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
            
            #line 8 "..\..\W_MessageBox.xaml"
            ((WinniesMessageBox.W_MessageBox)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 8 "..\..\W_MessageBox.xaml"
            ((WinniesMessageBox.W_MessageBox)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gBody = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.txbText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnYes = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\W_MessageBox.xaml"
            this.btnYes.Click += new System.Windows.RoutedEventHandler(this.btnReturnValue_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnNo = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\W_MessageBox.xaml"
            this.btnNo.Click += new System.Windows.RoutedEventHandler(this.btnReturnValue_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnOK = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\W_MessageBox.xaml"
            this.btnOK.Click += new System.Windows.RoutedEventHandler(this.btnReturnValue_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.gBar = ((System.Windows.Controls.Grid)(target));
            
            #line 30 "..\..\W_MessageBox.xaml"
            this.gBar.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.gBar_MouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\W_MessageBox.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

