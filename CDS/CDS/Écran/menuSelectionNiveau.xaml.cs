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
    /// Logique d'interaction pour menuSelectionNiveau.xaml
    /// </summary>
    public partial class menuSelectionNiveau : Window
    {
        public menuSelectionNiveau()
        {
            InitializeComponent();
            if(Globale.j1.estConnecte==true)
            {
                chargerNiveau();
            }
            else
            {
                btnNiveau1.IsEnabled = true;
            }
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            menuSurvie menuS = new menuSurvie();
            menuS.Show();
            Close();
        }

        public void chargerNiveau()
        {
            string req = "SELECT niveauAtteint FROM Progressions as p "+ 
            "INNER JOIN Utilisateurs as u ON p.idUtilisateur = u.idUtilisateur "+
            "INNER JOIN ModesDeJeu as m ON p.idModeDeJeu = m.idModeDeJeu ";

            int nbRange = 0;
            List<string>[] niveauMaxList;
            niveauMaxList = Globale.bdCDS.selection(req, 1, ref nbRange);
            if(nbRange != 0)
            {

             int niveauMax = Convert.ToInt32(niveauMaxList[0][0]);
                 switch (niveauMax)
                {
                    case 1:
                        btnNiveau1.IsEnabled = true;
                    break;
                    case 2:
                    btnNiveau1.IsEnabled = true;
                    btnNiveau2.IsEnabled = true;
                    break;
                    case 3:
                    btnNiveau1.IsEnabled = true;
                    btnNiveau2.IsEnabled = true;
                    btnNiveau3.IsEnabled = true;
                    break;
                    case 4:
                    btnNiveau1.IsEnabled = true;
                    btnNiveau2.IsEnabled = true;
                    btnNiveau3.IsEnabled = true;
                    btnNiveau4.IsEnabled = true;
                    break;
                    case 5:
                    btnNiveau1.IsEnabled = true;
                    btnNiveau2.IsEnabled = true;
                    btnNiveau3.IsEnabled = true;
                    btnNiveau4.IsEnabled = true;
                    btnNiveau5.IsEnabled = true;
                    break;
                    case 6:
                    btnNiveau1.IsEnabled = true;
                    btnNiveau2.IsEnabled = true;
                    btnNiveau3.IsEnabled = true;
                    btnNiveau4.IsEnabled = true;
                    btnNiveau5.IsEnabled = true;
                    btnNiveau6.IsEnabled = true;
                    break;
                    case 7:
                    btnNiveau1.IsEnabled = true;
                    btnNiveau2.IsEnabled = true;
                    btnNiveau3.IsEnabled = true;
                    btnNiveau4.IsEnabled = true;
                    btnNiveau5.IsEnabled = true;
                    btnNiveau6.IsEnabled = true;
                    btnNiveau7.IsEnabled = true;
                    break;
                    case 8:
                    btnNiveau1.IsEnabled = true;
                    btnNiveau2.IsEnabled = true;
                    btnNiveau3.IsEnabled = true;
                    btnNiveau4.IsEnabled = true;
                    btnNiveau5.IsEnabled = true;
                    btnNiveau6.IsEnabled = true;
                    btnNiveau7.IsEnabled = true;
                    btnNiveau8.IsEnabled = true;
                    break;
                    case 9:
                    btnNiveau1.IsEnabled = true;
                    btnNiveau2.IsEnabled = true;
                    btnNiveau3.IsEnabled = true;
                    btnNiveau4.IsEnabled = true;
                    btnNiveau5.IsEnabled = true;
                    btnNiveau6.IsEnabled = true;
                    btnNiveau7.IsEnabled = true;
                    btnNiveau8.IsEnabled = true;
                    btnNiveau9.IsEnabled = true;
                    break;
                    case 10:
                    btnNiveau1.IsEnabled = true;
                    btnNiveau2.IsEnabled = true;
                    btnNiveau3.IsEnabled = true;
                    btnNiveau4.IsEnabled = true;
                    btnNiveau5.IsEnabled = true;
                    btnNiveau6.IsEnabled = true;
                    btnNiveau7.IsEnabled = true;
                    btnNiveau8.IsEnabled = true;
                    btnNiveau9.IsEnabled = true;
                    btnNiveau10.IsEnabled = true;
                    break;
                }
            }
            else
            {
                btnNiveau1.IsEnabled = true;
            }
             
        }
    }
}
