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
    /// Logique d'interaction pour menuInscription.xaml
    /// </summary>
    public partial class menuInscription : Window
    {
        public menuInscription()
        {
            InitializeComponent();
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            menuJouer menuJ = new menuJouer();
            menuJ.Show();
            Close();
        }
    }
}
