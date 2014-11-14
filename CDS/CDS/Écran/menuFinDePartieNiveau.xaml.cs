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
    /// Logique d'interaction pour menuFinDePartieNiveau.xaml
    /// </summary>
    public partial class menuFinDePartieNiveau : Window
    {
        public menuFinDePartieNiveau()
        {
            InitializeComponent();
            if(Globale.j1.estConnecte == false)
            {
                btnNiveauSuivant.IsEnabled = false;
                txtPub.Text = "Créer vous un compte pour pouvoir accéder aux prochains niveaux disponibles";
            }
            else if(Globale.j1.estConnecte == true)
            {
                if (Globale.iNumeroDuNiveauAJouer < 10)
                {
                    txtPub.Text = "Vous avez survécu au niveau "+Globale.iNumeroDuNiveauAJouer+" , mais il reste toujours les niveaux supérieur à surpasser.";
                    Globale.iNumeroDuNiveauAJouer += 1;
                }
                else
                {
                    txtPub.Text = "Félicitation, vous êtes parvenu à survivre aux dix niveaux de la chambre de survie";
                    btnNiveauSuivant.IsEnabled = false;
                }
            }

        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            menuSurvie menuS = new menuSurvie();
            menuS.Show();
            Close();
        }

        private void btnSelectionNiveau_Click(object sender, RoutedEventArgs e)
        {
            if(Globale.j1.estConnecte == true)
            {
                if(Globale.iNumeroDuNiveauAJouer<10)
                {
                    Globale.iNumeroDuNiveauAJouer += 1;
                }
            }
            menuSelectionNiveau menuSelec = new menuSelectionNiveau();
            menuSelec.Show();
            Close();
        }

        private void btnNiveauSuivant_Click(object sender, RoutedEventArgs e)
        {
            jeuNiveau jeu = new jeuNiveau();
            jeu.Show();
            Close();
        }
    }
}
