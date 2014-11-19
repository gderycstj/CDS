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
    /// Logique d'interaction pour menuConnexion.xaml
    /// </summary>
    public partial class menuConnexion : Window
    {
        public menuConnexion()
        {
            InitializeComponent();
        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
             txtErreur.Text ="";
            List<string>[] listeJoueur;

            string req = "SELECT nom,idUtilisateur,image,estActive FROM Utilisateurs u INNER JOIN apparences p ON p.idApparence = u.idApparence WHERE nom = '" + txtNomUsager.Text + "' AND motDePasse = '" + txtMotDePasse.Password + "';";
            int nombreRange = 0;

            //va sélectionner l'identifiant  qui c'est connecté
            listeJoueur = Globale.bdCDS.selection(req, 4, ref nombreRange);



            //si le nombre de rangé = 0, ça veut dire que la requête n'a rien retourné, donc que l'utilisateur existe pas
            if (nombreRange == 0)
            {
                txtErreur.Text = "Votre nom d'utilisateur ou votre mot de passe est incorrect";
                txtNomUsager.Clear();
                txtMotDePasse.Clear();
            }
            else if(listeJoueur[0][3].ToString() == "False")
            {
                txtErreur.Text = "Votre nom d'utilisateur ou votre mot de passe est incorrect";
                txtNomUsager.Clear();
                txtMotDePasse.Clear();
            }
            //Sinon, il va rentrer le contenu de la liste dans un joueur et va afficher l'interface connecté
            else
            {
                Globale.j1.setJoueur(listeJoueur[0][0], Convert.ToInt32(listeJoueur[0][1]), listeJoueur[0][2],true);
                menuEditeur menuE = new menuEditeur();
                menuE.Show();
                Close();
             }
        }

        private void btnRetourCDS_Click(object sender, RoutedEventArgs e)
        {
            menuPrincipal menuP = new menuPrincipal();
            menuP.Show();
            Close();
        }


    }
}
