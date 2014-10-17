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
        /// <summary>
        /// cette fonction devrait théorquement afficher tout les éléments du jeu mais je n'ai fait que le déplacement du joueur
        /// </summary>
        void afficherGrilleJeu()
        {
            DéplacerJoueur();
        }

        /// <summary>
        /// Fonction pour déplacer un joueur
        /// </summary>
        void DéplacerJoueur() 
        {
            //va éffacer la grille a chaque déplacement et va réafficher le joueur à sa nouvelle position
            grillePrincipale.Children.Clear();
            Image img = new Image();
            img = Globale.j1.obtenirImage();
            Grid.SetColumn(img, Globale.j1.positionJoueur.pos.posX);
            Grid.SetRow(img, Globale.j1.positionJoueur.pos.posY);
            grillePrincipale.Children.Add(img);
        
        }
        
        //fonctionde déplacement pour les boutons, haut veux dire déplacement haut... fait aussi les validations pour pas dépasser la grille
        private void haut(object sender, RoutedEventArgs e)
        {
            if (Globale.j1.positionJoueur.pos.posY > 1)
            {
                Globale.j1.positionJoueur.pos.posY = Globale.j1.positionJoueur.pos.posY - 1;
                DéplacerJoueur();
            }

        }

        private void bas(object sender, RoutedEventArgs e)
        {
            if (Globale.j1.positionJoueur.pos.posY < GrilleDeJeu.TailleGrille - 2)
            {
                Globale.j1.positionJoueur.pos.posY = Globale.j1.positionJoueur.pos.posY + 1;
                DéplacerJoueur();
            }
        }

        private void droite(object sender, RoutedEventArgs e)
        {
            if (Globale.j1.positionJoueur.pos.posX < GrilleDeJeu.TailleGrille - 2)
            {
                Globale.j1.positionJoueur.pos.posX = Globale.j1.positionJoueur.pos.posX + 1;
                DéplacerJoueur();
            }
        }

        private void gauche(object sender, RoutedEventArgs e)
        {

            if (Globale.j1.positionJoueur.pos.posX > 1)
            {
                Globale.j1.positionJoueur.pos.posX = Globale.j1.positionJoueur.pos.posX - 1;
                DéplacerJoueur();
            }

        }
    }
}
