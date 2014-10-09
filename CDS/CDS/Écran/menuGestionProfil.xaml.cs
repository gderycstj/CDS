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
    /// Logique d'interaction pour gestionProfil.xaml
    /// </summary>
    public partial class menuGestionProfil : Window
    {
        public menuGestionProfil()
        {
            InitializeComponent();
            modifier();
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            modifier();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            supprimer();
        }


        private void btnConfirmerMod_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnConfirmerSupp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            menuJouer menuJ = new menuJouer();
            menuJ.Show();
            Close();
        }

        public void modifier()
        {
            //Titre
            txtTitreOnglet.Text = "Modification";

            //Activation/Désactivation Bouton
            btnModifier.IsEnabled = false;
            btnSupprimer.IsEnabled = true;

            //Activation
            btnConfirmerMod.Visibility = Visibility.Visible;
            txtNomUsager.Visibility = Visibility.Visible;
            txtNomUsagerMod.Visibility = Visibility.Visible;
            txtMotPasse.Visibility = Visibility.Visible;
            txtMotDePasseModif.Visibility = Visibility.Visible;
            txtMotDePasseConfirm.Visibility = Visibility.Visible;
            txtConfirmMotPasse.Visibility = Visibility.Visible;

            //Désactivation
            btnConfirmerSupp.Visibility = Visibility.Hidden;
            txtSupprimerInfo.Visibility = Visibility.Hidden;
            txtMDPSupp.Visibility = Visibility.Hidden;
            txtMotDePasseSupp.Visibility = Visibility.Hidden;
        }

        public void supprimer()
        {
            //Titre
            txtTitreOnglet.Text = "Supprimer";

            //Activation/Désactivation Bouton(Gauche)
            btnModifier.IsEnabled = true;
            btnSupprimer.IsEnabled = false;

            //Activation
            btnConfirmerSupp.Visibility = Visibility.Visible;
            txtSupprimerInfo.Visibility = Visibility.Visible;
            txtMDPSupp.Visibility = Visibility.Visible;
            txtMotDePasseSupp.Visibility = Visibility.Visible;

            //Désactivation
            btnConfirmerMod.Visibility = Visibility.Hidden;
            txtNomUsager.Visibility = Visibility.Hidden;
            txtNomUsagerMod.Visibility = Visibility.Hidden;
            txtMotPasse.Visibility = Visibility.Hidden;
            txtMotDePasseModif.Visibility = Visibility.Hidden;
            txtMotDePasseConfirm.Visibility = Visibility.Hidden;
            txtConfirmMotPasse.Visibility = Visibility.Hidden;
        }
    }
}
