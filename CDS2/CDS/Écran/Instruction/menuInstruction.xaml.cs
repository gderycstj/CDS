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
        public MainViewModel ViewModel { get { return (MainViewModel)DataContext; } }
        public menuInstruction()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            //Désactivation du button But
            ToutActiver();
            btnBut.IsEnabled = false;
            ViewModel.CurrentView = new infoBut();
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            menuPrincipal menuP = new menuPrincipal();
            menuP.Show();
            Close();
        }

        private void btnBut_Click(object sender, RoutedEventArgs e)
        {
            ToutActiver();
            btnBut.IsEnabled = false;

            //User Control avec info But
            ViewModel.CurrentView = new infoBut();
        }

        private void btnCommandes_Click(object sender, RoutedEventArgs e)
        {
            ToutActiver();
            btnCommandes.IsEnabled = false;

            ViewModel.CurrentView = new infoCommande();
        }

        private void btnPoursuivants_Click(object sender, RoutedEventArgs e)
        {
            ToutActiver();
            btnPoursuivants.IsEnabled = false;
        }

        private void btnObjets_Click(object sender, RoutedEventArgs e)
        {
            ToutActiver();
            btnObjets.IsEnabled = false;
        }

        public void ToutActiver()
        {
            btnBut.IsEnabled = true;
            btnCommandes.IsEnabled = true;
            btnPoursuivants.IsEnabled = true;
            btnObjets.IsEnabled = true;
        }
    }
}
