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
    /// Logique d'interaction pour menuJouer.xaml
    /// </summary>
    public partial class menuJouer : Window
    {
        public menuJouer()
        {
            InitializeComponent();

        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void btnRetourCDS_Click(object sender, RoutedEventArgs e)
        {
            menuPrincipal menuP = new menuPrincipal();
            menuP.Show();
            Close();
        }

        private void btnDemarrer_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void btnInscription_Click(object sender, RoutedEventArgs e)
        {
            menuInscription menuI = new menuInscription();
            menuI.Show();
            Close();
        }

    }
}
