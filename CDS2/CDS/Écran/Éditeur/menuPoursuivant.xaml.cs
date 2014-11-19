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

namespace CDS
{
    /// <summary>
    /// Logique d'interaction pour menuPoursuivant.xaml
    /// </summary>
    public partial class menuPoursuivant : UserControl
    {
        public MainViewModel ViewModel { get { return (MainViewModel)DataContext; } }
        public menuPoursuivant()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            ViewModel.CurrentView = new ecranCreationPoursuivant();
        }

        private void btnNouveauPoursuivant_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentView = new ecranCreationPoursuivant();
        }

        private void btnModifPoursuivant_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentView = new ecranCreationPoursuivant();
        }

        private void btnSupprimPoursuivant_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentView = new ecranSupressionPoursuivant();
        }
    }
}
