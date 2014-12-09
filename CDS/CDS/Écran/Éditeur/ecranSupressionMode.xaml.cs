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
    /// Logique d'interaction pour ecranSupressionMode.xaml
    /// </summary>
    public partial class ecranSupressionMode : UserControl
    {
        public ecranSupressionMode()
        {
            InitializeComponent();
            String req = "SELECT nom FROM ModesDeJeu WHERE idUtilisateur = (SELECT idUtilisateur FROM Utilisateurs WHERE nom = '" + Globale.j1.getNom() + "');";
            List<string>[] listeMode;
            int col = 0;
            listeMode = Globale.bdCDS.selection(req, 1, ref col);
            if(col != 0)
            { 
                for (int i = 0; i < listeMode.Length; i++)
                {
                    cboMode.Items.Add(listeMode[i][0]);
                }
            }
            else
            { 
                cboMode.Items.Add("aucun mode");
                btnSupprimMode.IsEnabled = false;
            }


            cboMode.SelectedIndex = 0;
        }

        private void btnSupprimMode_Click(object sender, RoutedEventArgs e)
        {
            string req = "SELECT * FROM Utilisateurs WHERE nom = '" + Globale.j1.getNom() + "' AND MotDePasse = '" + passwordUser.Password + "';";

            int col = 0;
             Globale.bdCDS.selection(req, 1, ref col);

            if (col != 0) 
            {
                req = "DELETE FROM ModesDeJeu  WHERE idUtilisateur = (SELECT idUtilisateur FROM Utilisateurs u WHERE nom = '" + Globale.j1.getNom() + "') AND nom ='" + cboMode.SelectedItem.ToString() + "';";
                col = 0;
                Globale.bdCDS.supression(req);
                txtErreur.Text= "votre mode a bien été supprimé";
                cboMode.Items.Remove(cboMode.SelectedItem);
             }
             else
            {
                txtErreur.Text = "Vous n'avez pas rentré le bon mot de passe";
            }


        }

        private void btnAide_Click(object sender, RoutedEventArgs e)
        {
            Globale.titrePMsg = "Aide";
            Globale.titreMsg = "Écran supression";
            Globale.contenuMsg = "Voici l'écran de supression d'un mode. \n\nIci, vous pouver supprimer vos créations et seulement les votres. \n\nChoisisez, entrez votre mot de passe et valider, c'est tout";

            msg popup = new msg();
            popup.ShowDialog();
        }

    }
}
