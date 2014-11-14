﻿using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CDS
{
    /// <summary>
    /// Logique d'interaction pour menuSurvie.xaml
    /// </summary>
    public partial class menuSurvie : Window
    {
        public menuSurvie()
        {
            InitializeComponent();
            if(Globale.j1.estConnecte == true)
            {
                btnNouvellePartie.IsEnabled = true;

                if(Globale.iNumeroDuNiveauAJouer <2)
                {
                    btnCharger.IsEnabled = false;
                }
                else
                {
                    btnCharger.IsEnabled = true; 
                }
            }
            else
            {
                btnCharger.IsEnabled = false;
                btnNouvellePartie.IsEnabled = false;
            }
        }

        private void btnRetourSurvie_Click(object sender, RoutedEventArgs e)
        {
            menuJouer menuJ = new menuJouer();
            menuJ.Show();
            Close();
        }

        private void btnNouvellePartie_Click(object sender, RoutedEventArgs e)
        {
            Globale.iNumeroDuNiveauAJouer = 1;
            jeuNiveau partiNiveau = new jeuNiveau();
            partiNiveau.Show();
            Close();
        }

        private void btnCharger_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void btnSelection_Click(object sender, RoutedEventArgs e)
        {
            menuSelectionNiveau menuSelec = new menuSelectionNiveau();
            menuSelec.Show();
            Close();
        }
    }
}
