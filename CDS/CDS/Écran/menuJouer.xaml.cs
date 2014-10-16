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
    /// Logique d'interaction pour menuJouer.xaml
    /// </summary>
    /// 
    public partial class menuJouer : Window
    {
        BdService bdCDS = new BdService();

        public menuJouer()
        {
            InitializeComponent();
            txtErreur.Text ="";
            Connect();
            string req = "SELECT nom FROM modesDeJeu;";
            List<string>[] listeMode;
            int col = 0;

            listeMode = bdCDS.selection(req,1,ref col);

            for (int i = 0; i < listeMode.Length; i++) 
            {
                cboChoixMode.Items.Add(listeMode[i][0]);
             }

             cboChoixMode.SelectedIndex = 0;

        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
            txtErreur.Text ="";
            List<string>[] listeJoueur;

            string req = "SELECT * FROM Utilisateurs WHERE nom = '" + txtNomUsager.Text + "' AND motDePasse = '" + txtMotDePasse.Password + "';";
            int nombreRange = 0;

            //va sélectionner l'identifiant  qui c'est connecté
            listeJoueur = bdCDS.selection(req, 5, ref nombreRange);


            //si le nombre de rangé = 0, ça veut dire que la requête n'a rien retourné, donc que l'utilisateur existe pas
            if (nombreRange == 0)
            {
                txtErreur.Text = "Votre nom d'utilisateur ou votre mot de passe est incorrect";
                txtNomUsager.Clear();
                txtMotDePasse.Clear();
            }
            if (nombreRange != 0)
            {
                if (listeJoueur[0][4].ToString() == "False")
                {
                    txtErreur.Text = "Votre nom d'utilisateur ou votre mot de passe est incorrect";
                    txtNomUsager.Clear();
                    txtMotDePasse.Clear();
                }

            //Sinon, il va rentrer le contenu de la liste dans un joueur et va afficher l'interface connecté
                else
                {
                    Globale.j1.setJoueur(listeJoueur[0][2], Convert.ToInt32(listeJoueur[0][0]), listeJoueur[0][1], true);
                    Connect();
                }
            }
        }

        private void btnRetourCDS_Click(object sender, RoutedEventArgs e)
        {
            menuPrincipal menuP = new menuPrincipal();
            menuP.Show();
            Close();
        }

        private void btnDemarrer_Click(object sender, RoutedEventArgs e)
        {
            if(cboChoixMode.SelectedItem.ToString() == "Survie")
            {
                menuSurvie menuS = new menuSurvie();
                menuS.Show();
                Close();
            }
            else
            {
                /*Partie partieNormal = new Partie();
                partieNormal.jouer();*/
                Jeu menuJeu = new Jeu();
                menuJeu.Show();
                Close();
            }
        }

        private void btnInscription_Click(object sender, RoutedEventArgs e)
        {
            menuInscription menuI = new menuInscription();
            menuI.Show();
            Close();
        }

        private void btnDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            Globale.j1.estConnecte = false;
            Connect();
        }

        public void Connect()
        {
            if (Globale.j1.estConnecte)
            {
                //Va mettre le nom du joueur dans la
                txtNomJoueur.Text = Globale.j1.getNom();

                //On cache les anciens objets de connexion
                btnConnexion.Visibility = Visibility.Hidden;
                btnInscription.Visibility = Visibility.Hidden;
                txtNomUsager.Visibility = Visibility.Hidden;
                txtMotDePasse.Visibility = Visibility.Hidden;
                lblNomUtilisateur.Visibility = Visibility.Hidden;
                lblMDP.Visibility = Visibility.Hidden;

                //On affiche les objets de déconnexion
                btnDeconnexion.Visibility = Visibility.Visible;
                txtNomJoueur.Visibility = Visibility.Visible;
                btnGestionProfil.Visibility = Visibility.Visible;
            }
            else
            {
                //On met les objets de connexion
                btnConnexion.Visibility = Visibility.Visible;
                btnInscription.Visibility = Visibility.Visible;
                txtNomUsager.Visibility = Visibility.Visible;
                txtMotDePasse.Visibility = Visibility.Visible;
                lblNomUtilisateur.Visibility = Visibility.Visible;
                lblMDP.Visibility = Visibility.Visible;

                //On cache les objets de déconnexion
                btnDeconnexion.Visibility = Visibility.Hidden;
                txtNomJoueur.Visibility = Visibility.Hidden;
                btnGestionProfil.Visibility = Visibility.Hidden;

            }
        }

        private void btnGestionProfil_Click(object sender, RoutedEventArgs e)
        {
            menuGestionProfil menuG = new menuGestionProfil();
            menuG.Show();
            Close();
        } 

    }
}
