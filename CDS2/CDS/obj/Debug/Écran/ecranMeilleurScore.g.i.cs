﻿#pragma checksum "..\..\..\Écran\ecranMeilleurScore.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B5CC451F3AA53095B16D0CE829D114F0"
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
    /// ecranMeilleurScore
    /// </summary>
    public partial class ecranMeilleurScore : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Écran\ecranMeilleurScore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTitre;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Écran\ecranMeilleurScore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRetour;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Écran\ecranMeilleurScore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRejouer;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Écran\ecranMeilleurScore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrilleScore;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Écran\ecranMeilleurScore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtNom;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Écran\ecranMeilleurScore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtScore;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Écran\ecranMeilleurScore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtMeilleursScores;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Écran\ecranMeilleurScore.xaml"
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
            System.Uri resourceLocater = new System.Uri("/CDS;component/%c3%89cran/ecranmeilleurscore.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Écran\ecranMeilleurScore.xaml"
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
            this.btnRetour = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Écran\ecranMeilleurScore.xaml"
            this.btnRetour.Click += new System.Windows.RoutedEventHandler(this.btnRetour_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnRejouer = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Écran\ecranMeilleurScore.xaml"
            this.btnRejouer.Click += new System.Windows.RoutedEventHandler(this.btnRejouer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GrilleScore = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.txtNom = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txtScore = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.txtMeilleursScores = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.txtPub = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

