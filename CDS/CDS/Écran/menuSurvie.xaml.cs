using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logique d'interaction pour menuSurvie.xaml
    /// </summary>
    public partial class menuSurvie : Window
    {
        public menuSurvie()
        {
            InitializeComponent();
            if(Globale.j1.estConnecte == true)
            {
                btnNouvellePartie.IsEnabled = true;

                     List<string>[] lstCharge;
                    int col = 0;
                    string req = "SELECT niveauAtteint FROM Progressions p INNER JOIN Utilisateurs u on p.idUtilisateur = u.idUtilisateur INNER JOIN ModesDeJeu m ON m.idModeDeJeu = p.idModeDeJeu WHERE u.nom = '" + Globale.j1.getNom() + "' AND m.nom = '" + Globale.mode + "';";
                    lstCharge = Globale.bdCDS.selection(req,1,ref col);

                    if (col != 0)
                    {
                        Globale.iNumeroDuNiveauAJouer = Convert.ToInt32(lstCharge[0][0]);
                    }


                if(Globale.iNumeroDuNiveauAJouer <2)
                {
                    btnCharger.IsEnabled = false;
                }
                else
                {
                    btnCharger.IsEnabled = true; 
                }
            }
            else
            {
                btnCharger.IsEnabled = false;
                btnNouvellePartie.IsEnabled = false;
            }
        }

        private void btnRetourSurvie_Click(object sender, RoutedEventArgs e)
        {
            menuJouer menuJ = new menuJouer();
            menuJ.Show();
            Close();
        }

        private void btnNouvellePartie_Click(object sender, RoutedEventArgs e)
        {
            Globale.iNumeroDuNiveauAJouer = 1;
            jeuNiveau partiNiveau = new jeuNiveau();
            partiNiveau.Show();
            Close();
        }

        private void btnCharger_Click(object sender, RoutedEventArgs e)
        {
            jeuNiveau partiNiveau = new jeuNiveau();
            partiNiveau.Show();
            Close();
        }

        private void btnSelection_Click(object sender, RoutedEventArgs e)
        {
            menuSelectionNiveau menuSelec = new menuSelectionNiveau();
            menuSelec.Show();
            Close();
        }
    }
}
