﻿#pragma checksum "..\..\..\..\Écran\Survie\ecranDescriptionNiveau.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F539A74CCEAE831F8F69D2A798FEEF6A"
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
    /// ecranDescriptionNiveau
    /// </summary>
    public partial class ecranDescriptionNiveau : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Écran\Survie\ecranDescriptionNiveau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTitre;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Écran\Survie\ecranDescriptionNiveau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtObjectif;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Écran\Survie\ecranDescriptionNiveau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCommencer;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Écran\Survie\ecranDescriptionNiveau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtPoursuivantDispo;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Écran\Survie\ecranDescriptionNiveau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtObjetDispo;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Écran\Survie\ecranDescriptionNiveau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtRestriction;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Écran\Survie\ecranDescriptionNiveau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgPoursuivant;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Écran\Survie\ecranDescriptionNiveau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTitreNiveau;
        
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
            System.Uri resourceLocater = new System.Uri("/CDS;component/%c3%89cran/survie/ecrandescriptionniveau.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Écran\Survie\ecranDescriptionNiveau.xaml"
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
            this.txtObjectif = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.btnCommencer = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\..\Écran\Survie\ecranDescriptionNiveau.xaml"
            this.btnCommencer.Click += new System.Windows.RoutedEventHandler(this.btnCommencer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtPoursuivantDispo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.txtObjetDispo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txtRestriction = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.imgPoursuivant = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.txtTitreNiveau = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

