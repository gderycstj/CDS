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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CDS
{
    /// <summary>
    /// Logique d'interaction pour ecranSupressionPoursuivant.xaml
    /// </summary>
    public partial class ecranSupressionPoursuivant : UserControl
    {
        public ecranSupressionPoursuivant()
        {
            InitializeComponent();
            String req = "SELECT nom FROM Poursuivants WHERE idUtilisateur = (SELECT idUtilisateur FROM Utilisateurs WHERE nom = '" + Globale.j1.getNom() + "');";
            List<string>[] listePoursuivant;
            int col = 0;
            listePoursuivant = Globale.bdCDS.selection(req, 1, ref col);
            if (col != 0)
            {
                for (int i = 0; i < listePoursuivant.Length; i++)
                {
                    cboPoursuivant.Items.Add(listePoursuivant[i][0]);
                }
            }
            else
            {
                cboPoursuivant.Items.Add("aucun poursuivant");
                btnSupprimPoursuivant.IsEnabled = false;
            }
            cboPoursuivant.SelectedIndex = 0;
            imageP();
        }

        private void btnSupprimPoursuivant_Click(object sender, RoutedEventArgs e)
        {
             string req = "SELECT * FROM Utilisateurs WHERE nom = '" + Globale.j1.getNom() + "' AND MotDePasse = '" + passwordUser.Password + "';";

            int col = 0;
            Globale.bdCDS.selection(req, 1, ref col);

            if (col != 0) 
            {
                req = "DELETE FROM Poursuivants  WHERE idUtilisateur = (SELECT idUtilisateur FROM Utilisateurs u WHERE nom = '" + Globale.j1.getNom() + "') AND nom ='" + cboPoursuivant.SelectedItem.ToString() + "';";
                col = 0;
                Globale.bdCDS.supression(req);
                cboPoursuivant.Items.Remove(cboPoursuivant.SelectedItem);
                cboPoursuivant.SelectedIndex = 0;

                     if (cboPoursuivant.Items.Count != 0)
                     { 
                        imageP();
                     }
                     else 
                     {
                         imgPoursuivant.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                      }
                      passwordUser.Clear();
            }
             else
            {
                txtErreur.Text = "Vous n'avez pas rentrer le bon mot de passe";
            }
         

        }

        private void trouverImageP(object sender, EventArgs e)
        {
               imageP();
        }

        public void imageP() 
        {
           
            string req = "SELECT image FROM Poursuivants p INNER JOIN Apparences a ON a.idApparence = p.idApparence WHERE nom ='" + cboPoursuivant.SelectedItem.ToString() + "';";
            int col = 0;
            List<string>[] listImage;
            listImage = Globale.bdCDS.selection(req, 1, ref col);


            if (col != 0)
            {
                imgPoursuivant.Source = new BitmapImage(new Uri("pack://application:,,," + listImage[0][0], UriKind.RelativeOrAbsolute));
            }       
         }

        private void btnAide_Click(object sender, RoutedEventArgs e)
        {
            Globale.titrePMsg = "Aide";
            Globale.titreMsg = "Écran supression";
            Globale.contenuMsg = "Voici l'écran de supression d'un Poursuivant. \n\nIci, vous pouver supprimer vos créations et seulement les votres. \n\nChoisisez, entrez votre mot de passe et valider, c'est tout";

            msg popup = new msg();
            popup.ShowDialog();
        }    
    }
}
