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
        bool estConnecter;

        public menuJouer()
        {
            InitializeComponent();
            txtErreur.Text ="";
            Connect(estConnecter);
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
            //Sinon, il va rentrer le contenu de la liste dans un joueur et va afficher l'interface connecté
            else
            {
                Joueur j1 = new Joueur(listeJoueur[0][2], Convert.ToInt32(listeJoueur[0][0]), listeJoueur[0][1]);
              //  string nom = j1.getNom;
                estConnecter = true;
                Connect(estConnecter);
                txtNomJoueur.Text = j1.getNom();
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
            return;
        }

        private void btnInscription_Click(object sender, RoutedEventArgs e)
        {
            menuInscription menuI = new menuInscription();
            menuI.Show();
            Close();
        }

        private void btnDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            estConnecter = false;
            Connect(estConnecter);
        }

        public void Connect(bool connecter)
        {
            if (estConnecter)
            {
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
            if (!estConnecter)
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
