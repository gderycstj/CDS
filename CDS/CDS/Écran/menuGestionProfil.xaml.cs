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
        List<string>[] listeJoueur;
        string nom = Globale.j1.getNom();
        int nombreRange = 0;

        //va sélectionner l'identifiant  qui c'est connecté
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
            bool estValide = true;
            string req = "SELECT motDePasse FROM Utilisateurs WHERE nom = '" + nom + "';";
            listeJoueur = Globale.bdCDS.selection(req, 1, ref nombreRange);

            if(txtAncienMdp.Password != listeJoueur[0][0].ToString())
            {
                txtErreur.Text = "Votre mot de passe actuel ne correspond pas avec celui inscrit";
                estValide = false;
            }

            if (txtMotDePasseModif.Password.Length < 3 || txtMotDePasseModif.Password.Length > 30)
            {
                txtErreur.Text = "Votre mot de passe doit avoir entre 3 et 20 caractères";
                estValide = false;

            }

            if(txtMotDePasseModif.Password != txtMotDePasseConfirm.Password)
            {
                txtErreur.Text = "Les 2 mots de passe que vous avez écrit ne sont pas identique";
                estValide = false;
            }

            if(estValide == true)
            {
                string req2 = "UPDATE Utilisateurs SET motDePasse = '"+txtMotDePasseModif.Password+"' WHERE nom ='" + nom + "';";
                Globale.bdCDS.modification(req2);
                txtErreur.Text = "Votre mot de passe à été mis à jour";
                txtMotDePasseModif.Clear();
                txtMotDePasseConfirm.Clear();
                txtAncienMdp.Clear();
            }
            else
            {
                txtMotDePasseConfirm.Clear();
                txtMotDePasseModif.Clear();
                txtAncienMdp.Clear();
            }

        }

        private void btnConfirmerSupp_Click(object sender, RoutedEventArgs e)
        {
            //On va chercher le mot de passe
            string req = "SELECT motDePasse FROM Utilisateurs WHERE nom = '" + nom + "';";
            listeJoueur = Globale.bdCDS.selection(req, 1, ref nombreRange);
            //Si le mot de passe est pareille, on désactive le compte
            if (txtMotDePasseSupp.Password == listeJoueur[0][0].ToString())
            {
                string req2 = "UPDATE Utilisateurs SET estActive=false WHERE nom ='" + nom + "';";
                Globale.bdCDS.modification(req2);
                Globale.j1.estConnecte = false;
                menuJouer menuJ = new menuJouer();
                menuJ.Show();
                Close();
            }

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
            txtMotPasse.Visibility = Visibility.Visible;
            txtMotDePasseModif.Visibility = Visibility.Visible;
            txtMotDePasseConfirm.Visibility = Visibility.Visible;
            txtConfirmMotPasse.Visibility = Visibility.Visible;
            txtErreur.Visibility = Visibility.Visible;

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
            txtMotPasse.Visibility = Visibility.Hidden;
            txtMotDePasseModif.Visibility = Visibility.Hidden;
            txtMotDePasseConfirm.Visibility = Visibility.Hidden;
            txtConfirmMotPasse.Visibility = Visibility.Hidden;
            txtErreur.Visibility = Visibility.Hidden;
        }
    }
}
