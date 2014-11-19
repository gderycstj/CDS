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
    /// Logique d'interaction pour menuObjet.xaml
    /// </summary>
    public partial class menuObjet : UserControl
    {
        public MainViewModel ViewModel { get { return (MainViewModel)DataContext; } }
        public menuObjet()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            ViewModel.CurrentView = new ecranCreationObjet();
        }

        private void btnNouveauObjet_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentView = new ecranCreationObjet();
        }

        private void btnModifObjet_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentView = new ecranCreationObjet();
        }

        private void btnSupprimObjet_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentView = new ecranSupressionObjet();
        }
    }
}
