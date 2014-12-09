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
    /// Logique d'interaction pour msg.xaml
    /// </summary>
    public partial class msg : Window
    {
        public msg()
        {
            InitializeComponent();

            this.Title=Globale.titrePMsg;
            this.txtTitre.Text=Globale.titreMsg;
            this.txtContent.Text=Globale.contenuMsg;
           
        }

        private void btnFermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
