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
    /// Logique d'interaction pour menuEditeur.xaml
    /// </summary>
    public partial class menuEditeur : Window
    {
        public MainViewModel ViewModel { get { return (MainViewModel)DataContext; } }
        public menuEditeur()
        {
            InitializeComponent();
            btnMode.IsEnabled = false;
            DataContext = new MainViewModel();
            ViewModel.CurrentView = new MenuMode();
        }

        /// <summary>
        /// Active tout les boutons de navigation entre les différentes parties de l'éditeur
        /// </summary>
        public void activerBouton()
        {
            btnMode.IsEnabled = true;
            btnPoursuivant.IsEnabled = true;
            btnObjet.IsEnabled = true;
            btnEffet.IsEnabled = true;
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            menuPrincipal menuP = new menuPrincipal();
            menuP.Show();
            Close();
        }

        private void btnMode_Click(object sender, RoutedEventArgs e)
        {
            activerBouton();
            btnMode.IsEnabled = false;
            //MenuMode m = new Mode();
            ViewModel.CurrentView = new MenuMode();
           
        }

        private void btnPoursuivant_Click(object sender, RoutedEventArgs e)
        {
            activerBouton();
            btnPoursuivant.IsEnabled = false;
        }

        private void btnObjet_Click(object sender, RoutedEventArgs e)
        {
            activerBouton();
            btnObjet.IsEnabled = false;
        }

        private void btnEffet_Click(object sender, RoutedEventArgs e)
        {
            activerBouton();
            btnEffet.IsEnabled = false;
        }
    }
}
