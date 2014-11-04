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
using System.Drawing.Imaging;

namespace CDS
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class menuPrincipal : Window
    {
        public menuPrincipal()
        {
          //btnJouer.Background = new ImageBrush(new BitmapImage(new Uri(@"K:\chambre de survie\infoMenu\CDS\CDS\Resources\3.jpg")));
          InitializeComponent();
          
        }

        private void btnJouer_Click(object sender, RoutedEventArgs e)
        {
            menuJouer menuJ = new menuJouer();
            menuJ.Show();
            Close();
            
        }

        private void btnInstruction_Click(object sender, RoutedEventArgs e)
        {
            menuInstruction menuI = new menuInstruction();
            menuI.Show();
            Close();
        }

        private void btnEditeur_Click(object sender, RoutedEventArgs e)
        {
           if (Globale.j1.estConnecte == true)
           {
               menuEditeur menuE = new menuEditeur();
               menuE.Show();
               Close();
           }
           else
           {
               menuConnexion menuC = new menuConnexion();
               menuC.Show();
               Close();
           }
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
