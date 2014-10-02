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
    /// Logique d'interaction pour menuInstruction.xaml
    /// </summary>
    public partial class menuInstruction : Window
    {
        public menuInstruction()
        {
            InitializeComponent();
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            menuPrincipal menuP = new menuPrincipal();
            menuP.Show();
            Close();
        }

        private void btnBut_Click(object sender, RoutedEventArgs e)
        {
            txtTitreInstruc.Text = "But";
        }

        private void btnCommandes_Click(object sender, RoutedEventArgs e)
        {
            txtTitreInstruc.Text = "Commandes";
        }

        private void btnPoursuivants_Click(object sender, RoutedEventArgs e)
        {
            txtTitreInstruc.Text = "Poursuivants";
        }

        private void btnObjets_Click(object sender, RoutedEventArgs e)
        {
            txtTitreInstruc.Text = "Objets";
        }

    }
}
