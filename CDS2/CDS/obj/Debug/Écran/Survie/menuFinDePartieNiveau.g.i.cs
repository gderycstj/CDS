﻿#pragma checksum "..\..\..\..\Écran\Survie\menuFinDePartieNiveau.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E6E70F5C34F7A74609CC035EF84BC183"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18444
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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


namespace CDS {
    
    
    /// <summary>
    /// menuFinDePartieNiveau
    /// </summary>
    public partial class menuFinDePartieNiveau : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Écran\Survie\menuFinDePartieNiveau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTitre;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Écran\Survie\menuFinDePartieNiveau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMenu;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Écran\Survie\menuFinDePartieNiveau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelectionNiveau;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Écran\Survie\menuFinDePartieNiveau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNiveauSuivant;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Écran\Survie\menuFinDePartieNiveau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtPub;
        
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
            System.Uri resourceLocater = new System.Uri("/CDS;component/%c3%89cran/survie/menufindepartieniveau.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Écran\Survie\menuFinDePartieNiveau.xaml"
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
            this.txtTitre = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.btnMenu = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\Écran\Survie\menuFinDePartieNiveau.xaml"
            this.btnMenu.Click += new System.Windows.RoutedEventHandler(this.btnMenu_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnSelectionNiveau = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\..\Écran\Survie\menuFinDePartieNiveau.xaml"
            this.btnSelectionNiveau.Click += new System.Windows.RoutedEventHandler(this.btnSelectionNiveau_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnNiveauSuivant = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\..\Écran\Survie\menuFinDePartieNiveau.xaml"
            this.btnNiveauSuivant.Click += new System.Windows.RoutedEventHandler(this.btnNiveauSuivant_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtPub = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

