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
    /// Logique d'interaction pour Jeu.xaml
    /// </summary>
    public partial class Jeu : Window
    {
        public Jeu()
        {
            InitializeComponent();
            afficherGrilleJeu();
        }

        void afficherGrilleJeu()
        {
            DéplacerJoueur();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Globale.j1.positionJoueur.pos.posY = Globale.j1.positionJoueur.pos.posY - 1;
            DéplacerJoueur();

        }

        void DéplacerJoueur() 
        {
            grillePrincipale.Children.Clear();
            Image img = new Image();
            img = Globale.j1.obtenirImage();

            Grid.SetColumn(img, Globale.j1.positionJoueur.pos.posX);
            Grid.SetRow(img, Globale.j1.positionJoueur.pos.posY);
            grillePrincipale.Children.Add(img);
        
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Globale.j1.positionJoueur.pos.posY = Globale.j1.positionJoueur.pos.posY + 1;
            DéplacerJoueur();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Globale.j1.positionJoueur.pos.posX = Globale.j1.positionJoueur.pos.posX + 1;
            DéplacerJoueur();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Globale.j1.positionJoueur.pos.posX = Globale.j1.positionJoueur.pos.posX - 1;
            DéplacerJoueur();
        }
    }
}
