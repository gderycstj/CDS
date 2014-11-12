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
                btnSelectionNiveau.IsEnabled = false;
                btnNiveauSuivant.IsEnabled = false;
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
            menuSelectionNiveau menuSelec = new menuSelectionNiveau();
            menuSelec.Show();
            Close();
        }
    }
}
