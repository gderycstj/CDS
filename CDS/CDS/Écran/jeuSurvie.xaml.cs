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
    public partial class JeuSurvie : Window
    {

        int tour = 1;
        Partie partieSurvie = new Partie();
        public JeuSurvie()
        {
            InitializeComponent();
            txtCTour.Text = tour.ToString();
            afficherGrilleJeu();
        }
        /// <summary>
        /// cette fonction devrait théorquement afficher tout les éléments du jeu mais je n'ai fait que le déplacement du joueur
        /// </summary>
        void afficherGrilleJeu()
        {
            DéplacerJoueur();
            //Déplacer Poursuivant
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
            deplacerHaut();
            afficherInfo();
        }

        private void bas(object sender, RoutedEventArgs e)
        {
            deplacerBas();
            afficherInfo();
        }

        private void droite(object sender, RoutedEventArgs e)
        {
            deplacerDroite();
            afficherInfo();
        }

        private void gauche(object sender, RoutedEventArgs e)
        {
            deplacerGauche();
            afficherInfo();
        }

        private void btnPasserTour_Click(object sender, RoutedEventArgs e)
        {
            afficherInfo();
        }

        private void grilleJeuWindow_KeyDown(object sender, KeyEventArgs e)
        {
            //Vers le bas
            if (Keyboard.IsKeyDown(Key.Down))
            {
                deplacerBas();
                afficherInfo();
            }
            //Vers le Haut
            if (Keyboard.IsKeyDown(Key.Up))
            {
                deplacerHaut();
                afficherInfo();
            }
            //Vers la droite
            if (Keyboard.IsKeyDown(Key.Right))
            {
                deplacerDroite();
                afficherInfo();
            }
            //Vers la gauche
            if (Keyboard.IsKeyDown(Key.Left))
            {
                deplacerGauche();
                afficherInfo();
            }
            //Bouton X(item)
            if(Keyboard.IsKeyDown(Key.X))
            {
                
            }
            

            //Bouton Z(item)
            if(Keyboard.IsKeyDown(Key.Z))
            {
             
             
            }
            //Bouton Enter(passer le tour)
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                afficherInfo();
            }

        }
        void deplacerDroite()
        {
            if (Globale.j1.positionJoueur.pos.posX < GrilleDeJeu.TailleGrille - 2)
            {
                Globale.j1.positionJoueur.pos.posX = Globale.j1.positionJoueur.pos.posX + 1;
                DéplacerJoueur();
            }
        }

        void deplacerGauche()
        {
            if (Globale.j1.positionJoueur.pos.posX > 1)
            {
                Globale.j1.positionJoueur.pos.posX = Globale.j1.positionJoueur.pos.posX - 1;
                DéplacerJoueur();
            }
        }

        void deplacerHaut()
        {
            if (Globale.j1.positionJoueur.pos.posY > 1)
            {
                Globale.j1.positionJoueur.pos.posY = Globale.j1.positionJoueur.pos.posY - 1;
                DéplacerJoueur();
            }
        }

        void deplacerBas()
        {
            if (Globale.j1.positionJoueur.pos.posY < GrilleDeJeu.TailleGrille - 2)
            {
                Globale.j1.positionJoueur.pos.posY = Globale.j1.positionJoueur.pos.posY + 1;
                DéplacerJoueur();
            }
        }

        void afficherInfo()
        {
            tour += 1;
            txtCTour.Text = tour.ToString();
        }
    }
}