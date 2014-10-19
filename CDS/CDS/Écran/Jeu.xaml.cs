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
            chargerInfoBD();
        }

        /// <summary>
        /// Cette fonction va charger toutes les infos en bd et les rentrer dans les objets correspondant
        /// </summary>
        void chargerInfoBD() 
        {
            int nb = 0;
            List<string>[] listePoursuivants;
            List<string>[] listeObjets;


            //Poursuivants
            string req = "SELECT * FROM Poursuivants";
            listePoursuivants = Globale.bdCDS.selection(req,6,ref nb);

            //Objets
            string req2 = "SELECT * FROM Objets";
            listeObjets = Globale.bdCDS.selection(req, 6, ref nb);

        
        
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
        }

        private void bas(object sender, RoutedEventArgs e)
        {
            deplacerBas();
        }

        private void droite(object sender, RoutedEventArgs e)
        {
            deplacerDroite();
        }

        private void gauche(object sender, RoutedEventArgs e)
        {
            deplacerGauche();
        }

        private void grilleJeuWindow_KeyDown(object sender, KeyEventArgs e)
        {
              //Vers le bas
              if(Keyboard.IsKeyDown(Key.Down))
              {
                  deplacerBas();
              }
            //Vers le Haut
              if(Keyboard.IsKeyDown(Key.Up))
              {
                 deplacerHaut();
              }
            //Vers la droite
            if(Keyboard.IsKeyDown(Key.Right))
            {
                deplacerDroite();
            }
            //Vers la gauche
            if(Keyboard.IsKeyDown(Key.Left))
            {
                deplacerGauche();
            }

            /*Bouton X(item)
            if(Keyboard.IsKeyDown(Key.X))
            {
                
            }
            */

            /*Bouton Z(item)
             if(Keyboard.IsKeyDown(Key.Z))
              {
             
             
             }*/ 
            /*Bouton Enter(passer le tour)
            if(Keyboard.IsKeyDown(Key.Enter))
            {

            }
             */
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
        
    }
}
