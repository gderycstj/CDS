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
    /// Logique d'interaction pour ecranFinDePartieMode.xaml
    /// </summary>
    public partial class ecranFinDePartieMode : Window
    {
        public ecranFinDePartieMode()
        {
            InitializeComponent();
            txtTitre.Text = "Fin de partie " + Globale.mode;
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            menuJouer menuJ = new menuJouer();
            menuJ.Show();
            Close();
        }

        private void btnRejouer_Click(object sender, RoutedEventArgs e)
        {
            jeuNiveau jeu = new jeuNiveau();
            jeu.Show();
            Close();
        }
    }
}
