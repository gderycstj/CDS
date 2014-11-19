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
        public string edit = "M";
        public menuEditeur()
        {
            InitializeComponent();
            btnMode.IsEnabled = false;
            DataContext = new MainViewModel();
            ViewModel.CurrentView = new menuMode();
            btnNouveau.IsEnabled = false;
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
        public void activerBoutonEdit() 
        {
            btnNouveau.IsEnabled = true;
            btnModif.IsEnabled = true;
            btnSupprim.IsEnabled = true;
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

            activerBoutonEdit();
            btnNouveau.IsEnabled = false;

            edit = "M";
            ViewModel.CurrentView = new menuMode();
        }

        private void btnPoursuivant_Click(object sender, RoutedEventArgs e)
        {
            activerBouton();
            btnPoursuivant.IsEnabled = false;

            activerBoutonEdit();
            btnNouveau.IsEnabled = false;

            edit = "P";
            ViewModel.CurrentView = new ecranCreationPoursuivant();
          
        }

        private void btnObjet_Click(object sender, RoutedEventArgs e)
        {
            activerBouton();
            btnObjet.IsEnabled = false;

            activerBoutonEdit();
            btnNouveau.IsEnabled = false;

            edit = "O";
            ViewModel.CurrentView = new ecranCreationObjet();
          
        }

        private void btnEffet_Click(object sender, RoutedEventArgs e)
        {
            activerBouton();
            btnEffet.IsEnabled = false;

            activerBoutonEdit();
            btnNouveau.IsEnabled = false;

            edit = "E";
            ViewModel.CurrentView = new ecranCreationEffets();

        }

        private void btnNouveau_Click(object sender, RoutedEventArgs e)
        {
            activerBoutonEdit();
            if (edit == "M") 
            {
                ViewModel.CurrentView = new menuMode();
            }

            if (edit == "P") 
            {
                ViewModel.CurrentView = new ecranCreationPoursuivant();
            }

            if (edit == "O") 
            {
                ViewModel.CurrentView = new ecranCreationObjet();
            }

            if (edit == "E")
            {
                ViewModel.CurrentView = new ecranCreationEffets();
            }

            btnNouveau.IsEnabled = false;
        }

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            activerBoutonEdit();

            if (edit == "M")
            {
                ViewModel.CurrentView = new menuMode();
            }

            if (edit == "P")
            {
                ViewModel.CurrentView = new ecranCreationPoursuivant();
            }

            if (edit == "O")
            {
                ViewModel.CurrentView = new ecranCreationObjet();
            }

            if (edit == "E")
            {
                ViewModel.CurrentView = new ecranCreationEffets();
            }

            btnModif.IsEnabled = false;
        }

        private void btnSupprim_Click(object sender, RoutedEventArgs e)
        {
            activerBoutonEdit();

            if (edit == "M")
            {
                ViewModel.CurrentView = new ecranSupressionMode();
            }

            if (edit == "P")
            {
                ViewModel.CurrentView = new ecranSupressionPoursuivant();
            }

            if (edit == "O")
            {
                ViewModel.CurrentView = new ecranSupressionObjet();
            }

            if (edit == "E")
            {
                ViewModel.CurrentView = new ecranSupressionEffet();
            }

            btnSupprim.IsEnabled = false;
        }


    }
}
