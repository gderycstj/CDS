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

            for (int i = 0; i < listeMode.Length; i++)
            {
                cboMode.Items.Add(listeMode[i][0]);
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
                req = "DELETE FROM ModesDeJeu WHERE idUtilisateur = (SELECT idUtilisateur FROM Utilisateurs WHERE nom = '" + Globale.j1.getNom() + "';";

                col = 0;
                Globale.bdCDS.supression(req);


             }
             else
            {
                txtErreur.Text = "Vous n'avez pas rentrez le bon mot de passe";
            }


        }

    }
}
