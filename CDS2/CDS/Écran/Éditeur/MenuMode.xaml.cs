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
    /// Logique d'interaction pour menuMode.xaml
    /// </summary>
    public partial class menuMode : UserControl
    {
        public class Poursuivant
        {
            public string Nom;
            public string Valeur;
            public string Rarete;
        }

        public menuMode()
        {
            InitializeComponent();


            String req = "SELECT nom FROM Poursuivants WHERE idUtilisateur = (SELECT idUtilisateur FROM Utilisateurs WHERE nom = '" + Globale.j1.getNom() + "') OR (SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin');";
            List<string>[] listePoursuivant;
            int col = 0;
            listePoursuivant = Globale.bdCDS.selection(req, 1, ref col);

            for (int i = 0; i < listePoursuivant.Length; i++)
            {
                cboPoursuivant.Items.Add(listePoursuivant[i][0]);
            }

            cboPoursuivant.SelectedIndex = 0;

            String req2 = "SELECT nom FROM Objets WHERE idUtilisateur = (SELECT idUtilisateur FROM Utilisateurs WHERE nom = '" + Globale.j1.getNom() + "')  OR (SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin');";
            List<string>[] listeObjet;
            listeObjet = Globale.bdCDS.selection(req2, 1, ref col);

            for (int i = 0; i < listeObjet.Length; i++)
            {
                cboObjet.Items.Add(listeObjet[i][0]);
            }


            cboObjet.SelectedIndex = 0;
        }

        private void btnPoursuivants_Click(object sender, RoutedEventArgs e) 
        {
                string poursuivant = cboPoursuivant.SelectedIndex.ToString();

                string[] row = new string[] {"allo","0","0","0"};
                dataPoursuivant.Items.Add(new Poursuivant() {Nom = "toto", Rarete= "0", Valeur="0"});
         }

    }
}
