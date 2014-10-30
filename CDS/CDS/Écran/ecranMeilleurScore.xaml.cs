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
    /// Logique d'interaction pour ecranMeilleurScore.xaml
    /// </summary>
    public partial class ecranMeilleurScore : Window
    {
        public ecranMeilleurScore()
        {
            InitializeComponent();
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            menuJouer menuJ = new menuJouer();
            menuJ.Show();
            Close();
        }

        private void btnRejouer_Click(object sender, RoutedEventArgs e)
        {
            Globale.j1.positionJoueur.posX=5;
            Globale.j1.positionJoueur.posY=5;
            JeuNormal menuJeu = new JeuNormal();
            menuJeu.Show();
            Close();
        }
    }
}
