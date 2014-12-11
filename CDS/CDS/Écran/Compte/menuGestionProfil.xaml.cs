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
                txtErreur.Text = "Votre mot de passe actuel inscrit est incorrect";
                estValide = false;
            }

            if (txtMotDePasseModif.Password.Length < 3 || txtMotDePasseModif.Password.Length > 20)
            {
                txtErreur.Text = "Votre mot de passe doit avoir entre 3 et 20 caractères";
                estValide = false;

            }

            if(txtMotDePasseModif.Password != txtMotDePasseConfirm.Password)
            {
                txtErreur.Text = "Les 2 mots de passe ne sont pas identiques";
                estValide = false;
            }

            if(estValide == true)
            {
                string req2 = "UPDATE Utilisateurs SET motDePasse = '"+txtMotDePasseModif.Password+"' WHERE nom ='" + nom + "';";
                Globale.bdCDS.modification(req2);
                txtErreur.Text = "Votre mot de passe a été mis à jour";
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
            txtErreur.Visibility = Visibility.Visible;
            //Si le mot de passe est pareille, on désactive le compte
            if (txtMotDePasseSupp.Password == listeJoueur[0][0].ToString())
            {
                string req2 = "UPDATE Utilisateurs SET estActive=false WHERE nom ='" + nom + "';";
                Globale.bdCDS.modification(req2);
                Globale.j1.estConnecte = false;

                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;
                btnConfirmerSupp.IsEnabled = false;
                txtMDPSupp.IsEnabled = false;
                txtMotDePasseSupp.IsEnabled = false;
                txtErreur.Text = "Votre compte a été supprimé avec succès. Cliquez sur retour pour retourner au menu jouer";
            }
            else
            {
                txtErreur.Text = "Votre mot de passe actuel inscrit est incorrect";
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

            //Activation
            txtMotPasse.Visibility = Visibility.Visible;
            txtMotDePasseModif.Visibility = Visibility.Visible;
            txtMotDePasseConfirm.Visibility = Visibility.Visible;
            txtConfirmMotPasse.Visibility = Visibility.Visible;
            txtErreur.Visibility = Visibility.Visible;
            txtAncienMdp.Visibility = Visibility.Visible;
            txtAncienMdpTxt.Visibility = Visibility.Visible;

            //Désactivation
            btnConfirmerSupp.Visibility = Visibility.Hidden;
            txtSupprimerInfo.Visibility = Visibility.Hidden;
            txtMDPSupp.Visibility = Visibility.Hidden;
            txtMotDePasseSupp.Visibility = Visibility.Hidden;

            //Activation/Désactivation Bouton
            btnModifier.IsEnabled = false;
            btnSupprimer.IsEnabled = true;
            btnConfirmerMod.Visibility = Visibility.Visible;

        }

        public void supprimer()
        {
            //Titre
            txtTitreOnglet.Text = "Supprimer";

            //Activation
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
            txtAncienMdp.Visibility = Visibility.Hidden;
            txtAncienMdpTxt.Visibility = Visibility.Hidden;

            //Activation/Désactivation Bouton(Gauche)
            btnConfirmerSupp.Visibility = Visibility.Visible;
            btnModifier.IsEnabled = true;
            btnSupprimer.IsEnabled = false;

        }

        private void btnAide_Click(object sender, RoutedEventArgs e)
        {
            Globale.titrePMsg = "Aide";
            Globale.titreMsg = "Gestion du profil ";
            Globale.contenuMsg = "Voici l'écran de gestion de votre profil. \n\nIci, vous pouvez modifier votre mot de passe et supprimer votre compte. \n\n Oubliez pas que le mot de passe doit entre entre 3 et 20 carractère.";

            msg popup = new msg();
            popup.ShowDialog();
        }
    }
}
