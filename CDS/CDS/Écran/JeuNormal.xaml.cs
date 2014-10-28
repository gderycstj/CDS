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
    public partial class JeuNormal : Window
    {
        
        int tour = 1;
        Partie partieNormal = new Partie();

        public JeuNormal()
        {
            InitializeComponent();
            txtCTour.Text = tour.ToString();
            partieNormal.initialiser();
            txtCScore.Text = partieNormal.score.ToString();
            validationVie();
            afficherGrilleJeu();
        }
        /// <summary>
        /// cette fonction devrait théorquement afficher tout les éléments du jeu mais je n'ai fait que le déplacement du joueur
        /// </summary>
        void afficherGrilleJeu()
        {
            DéplacerJoueur();
            AfficherMonstre();
        }

        //fonction test
        void AfficherMonstre() 
        {
            foreach (Poursuivant p in partieNormal.PoursuivantDansLaPartie) 
            {
                Image img = new Image();
                img = p.obtenirImage();
                Grid.SetColumn(img,  p.positionEntite.posX);
                Grid.SetRow(img, p.positionEntite.posY);
                grillePrincipale.Children.Add(img);
             }
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
            Grid.SetColumn(img, Globale.j1.positionJoueur.posX);
            Grid.SetRow(img, Globale.j1.positionJoueur.posY);
            grillePrincipale.Children.Add(img);
            if(tour == 1 && Globale.j1.positionJoueur.posX == 5 && Globale.j1.positionJoueur.posY == 5)
            {
                tour -=1;
            }
            tour +=1;
            if (tour > 1)
            {
                generationTour();
            }
        }
        
        //fonction de déplacement pour les boutons, haut veux dire déplacement haut... fait aussi les validations pour pas dépasser la grille
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
            tour += 1;
            generationTour();
            afficherInfo();
        }     

        private void grilleJeuWindow_KeyDown(object sender, KeyEventArgs e)
        {
              //Vers le bas
              if(Keyboard.IsKeyDown(Key.Down))
              {
                  deplacerBas();
                  afficherInfo();
              }
            //Vers le Haut
              if(Keyboard.IsKeyDown(Key.Up))
              {
                 deplacerHaut();
                 afficherInfo();
              }
            //Vers la droite
            if(Keyboard.IsKeyDown(Key.Right))
            {
                deplacerDroite();
                afficherInfo();
            }
            //Vers la gauche
            if(Keyboard.IsKeyDown(Key.Left))
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
            if(Keyboard.IsKeyDown(Key.Enter))
            {
                tour += 1;
                generationTour();
                afficherInfo();
            }
            
        }

            //fonction de déplacement par les boutons
            void deplacerDroite()
            {
                 if (Globale.j1.positionJoueur.posX < Globale.tailleGrille - 2)
                {
                    Globale.j1.positionJoueur.posX = Globale.j1.positionJoueur.posX + 1;
                    DéplacerJoueur();
                }
            }

            void deplacerGauche()
            {
                if (Globale.j1.positionJoueur.posX > 1)
                {
                    Globale.j1.positionJoueur.posX = Globale.j1.positionJoueur.posX - 1;
                    DéplacerJoueur();
                }
            }

            void deplacerHaut()
            {
                if (Globale.j1.positionJoueur.posY > 1)
                {
                    Globale.j1.positionJoueur.posY = Globale.j1.positionJoueur.posY - 1;
                    DéplacerJoueur();
                }
            }

            void deplacerBas()
            {
                 if (Globale.j1.positionJoueur.posY < Globale.tailleGrille - 2)
                  {
                      Globale.j1.positionJoueur.posY = Globale.j1.positionJoueur.posY + 1;
                      DéplacerJoueur();
                  }   
            }

            void afficherInfo()
            {
                txtCTour.Text = tour.ToString();
                txtCScore.Text = partieNormal.score.ToString();
                validationVie();
            }

            public void validationVie()
            {
                //Vie Actuelle
                switch(partieNormal.vie.nbVieActu)
                {
                    case 1:
                        vie1.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                        vie2.Source = new BitmapImage(new Uri(@"/image/coeurVide.png", UriKind.Relative));
                        vie3.Source = new BitmapImage(new Uri(@"/image/coeurVide.png", UriKind.Relative));
                        break;
                    case 2:
                        vie1.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                        vie2.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                        vie3.Source = new BitmapImage(new Uri(@"/image/coeurVide.png", UriKind.Relative));
                        break;
                    case 3:
                        vie1.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                        vie2.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                        vie3.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                        break;
                }
                //Armure
                switch(partieNormal.vie.nbArmure)
                {
                    case 1:
                        if (partieNormal.vie.nbVieActu == 1)
                        {
                            vie1.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                            vie2.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                            vie3.Source = new BitmapImage(new Uri(@"/image/coeurVide.png", UriKind.Relative));
                        }
                        if(partieNormal.vie.nbVieActu < 2)
                        {
                            vie1.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                            vie2.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                            vie3.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                        }
                        break;
                    case 2:
                        if (partieNormal.vie.nbVieActu == 1)
                        {
                            vie1.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                            vie2.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                            vie3.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                        }
                        if(partieNormal.vie.nbVieActu < 2)
                        {
                            vie1.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                            vie2.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                            vie3.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                        }
                        break;
                    case 3:
                        vie1.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                        vie2.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                        vie3.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                        break;
                }
            }

            public void generationTour()
            {
                //DeplacementPoursuivant
                partieNormal.validationPoursuivant();
                partieNormal.generationPoursuivantTour(tour);
                AfficherMonstre();
                //affichage des monstres déplacé
                //fonctionFinDeTour();
                //Affichage des infos
            }
    }
}
