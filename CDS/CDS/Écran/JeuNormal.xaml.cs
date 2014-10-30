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
        bool partieEnCours = true;
        public JeuNormal()
        {
            InitializeComponent();
            Globale.j1.pathImage="/image/perso.png";
            txtCTour.Text = tour.ToString();
            partieNormal.initialiser();
            txtCScore.Text = partieNormal.score.ToString();
            validationVie();
            AfficherJoueur();
            AfficherPoursuivant();
        }

        void AfficherJoueur()
        {
            Image img = new Image();
            img = Globale.j1.obtenirImage();
            Grid.SetColumn(img, Globale.j1.positionJoueur.posX);
            Grid.SetRow(img, Globale.j1.positionJoueur.posY);
            grillePrincipale.Children.Add(img);

        }

        //fonction test
        void AfficherPoursuivant() 
        {
            foreach (Poursuivant p in partieNormal.PoursuivantDansLaPartie) 
            {
                Image img = new Image();
                img = p.obtenirImage();
                 if(p.positionEntite.posX >= 0 && p.positionEntite.posY >= 0)
                { 
                  Grid.SetColumn(img,  p.positionEntite.posX);
                   Grid.SetRow(img, p.positionEntite.posY);
                }
                grillePrincipale.Children.Add(img);
             }
        }

        void AfficherObjet()
        {
            foreach (Objet o in partieNormal.objetDansLaPartie)
            {
                Image img = new Image();
                img = o.obtenirImage();
                if (o.positionEntite.posX >= 0 && o.positionEntite.posY >= 0)
                {
                    Grid.SetColumn(img, o.positionEntite.posX);
                    Grid.SetRow(img, o.positionEntite.posY);
                }
                grillePrincipale.Children.Add(img);
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
                if (partieNormal.obj2 != null)
                {
                    partieNormal.obj2.unEffet.action();
                    partieNormal.obj2 = null;
                    validationVie();
                    item2.Background = null;
                }
            }
            

            //Bouton Z(item)
            if(Keyboard.IsKeyDown(Key.Z))
            {
                if (partieNormal.obj1 != null)
                {
                    partieNormal.obj1.unEffet.action();
                    partieNormal.obj1 = null;
                    validationVie();
                    item1.Background = null;
                }
            } 
            //Bouton Enter(passer le tour)
            if(Keyboard.IsKeyDown(Key.Enter))
            {
                if(partieEnCours == true)
                { 
                    tour += 1;
                    generationTour();
                    afficherInfo();
                }
            }
            
        }

            //fonction de déplacement par les boutons
            void deplacerDroite()
            {
                 if (Globale.j1.positionJoueur.posX < Globale.tailleGrille - 2)
                {
                    Globale.j1.positionJoueur.posX = Globale.j1.positionJoueur.posX + 1;
                    generationTour();
                }
            }

            void deplacerGauche()
            {
                if (Globale.j1.positionJoueur.posX > 1)
                {
                    Globale.j1.positionJoueur.posX = Globale.j1.positionJoueur.posX - 1;
                    generationTour();
                }
            }

            void deplacerHaut()
            {
                if (Globale.j1.positionJoueur.posY > 1)
                {
                    Globale.j1.positionJoueur.posY = Globale.j1.positionJoueur.posY - 1;
                    generationTour();
                }
            }

            void deplacerBas()
            {
                 if (Globale.j1.positionJoueur.posY < Globale.tailleGrille - 2)
                  {
                      Globale.j1.positionJoueur.posY = Globale.j1.positionJoueur.posY + 1;
                      generationTour();
                  }   
            }

            void afficherInfo()
            {
                txtCTour.Text = tour.ToString();
                txtCScore.Text = partieNormal.score.ToString();
            }

            public void rentrerObjet() 
            {
               if (partieNormal.obj1 != null) 
               {
                    var brush = new ImageBrush();
                    brush.ImageSource = new BitmapImage(new Uri("pack://application:,,," + partieNormal.obj1.getUrlImage(), UriKind.RelativeOrAbsolute));
                    item1.Background = brush;
               }

               if (partieNormal.obj2 != null)
               {
                   var brush = new ImageBrush();
                   brush.ImageSource = new BitmapImage(new Uri("pack://application:,,," + partieNormal.obj2.getUrlImage(), UriKind.RelativeOrAbsolute));
                   item2.Background = brush;
               }
            }

            public void validationVie()
            {
                //on met les coueur vide
                vie1.Source = new BitmapImage(new Uri(@"/image/coeurVide.png", UriKind.Relative));
                vie2.Source = new BitmapImage(new Uri(@"/image/coeurVide.png", UriKind.Relative));
                vie3.Source = new BitmapImage(new Uri(@"/image/coeurVide.png", UriKind.Relative));

                viesSup.Text = "";
                armuresSup.Text = "";
                //on remplit les coeur selon la Vie Actuelle
                switch (Globale.vie.nbVieActu)
                {
					case 0:
                        break;
                    case 1:
                        vie1.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                        break;
                    case 2:
                        vie1.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                        vie2.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                        break;
                    case 3:
                        vie1.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                        vie2.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                        vie3.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                        break;

                    default:
                        vie1.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                        vie2.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                        vie3.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));

                        viesSup.Text="+"+(Globale.vie.nbVieActu-3);
                        break;
                }
                //Armure
                switch (Globale.vie.nbArmure)
                {
                    case 0:
                        break;

                    case 1:
                        vie1.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                        break;

                    case 2:
                        vie1.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                        vie2.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                        break;

                    case 3:
                        vie1.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                        vie2.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                        vie3.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                        break;

                    default:
                        vie1.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                        vie2.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));
                        vie3.Source = new BitmapImage(new Uri(@"/image/coeurBouclier.png", UriKind.Relative));

                        armuresSup.Text = "+" + (Globale.vie.nbArmure - 3);
                        break;
                }
            }

            public void generationTour()
            {
                //va éffacer la grille a chaque déplacement et va réafficher le joueur à sa nouvelle position
                  grillePrincipale.Children.Clear();

                if (tour == 1 && Globale.j1.positionJoueur.posX == 5 && Globale.j1.positionJoueur.posY == 5)
                {
                    tour -= 1;
                }

                partieNormal.validationPoursuivant(false);
                partieNormal.validationObjet();
                rentrerObjet();

                tour += 1;
                AfficherJoueur();
                foreach (Poursuivant p in partieNormal.PoursuivantDansLaPartie)
                {
                    p.action();
                }
                if(Globale.vie.nbVieActu != 0)
                {
                    partieNormal.validationPoursuivant(true);

                    partieNormal.generationPoursuivantTour(tour);
                    AfficherPoursuivant();

                    partieNormal.GenerationObjet(tour);
                    AfficherObjet();
                }
                validationVie();
                validationObjectifPartieNormal();
            }
			
			public void validationObjectifPartieNormal()
            {
                if (partieNormal.finDeTour() == false)
                {
                    Globale.j1.pathImage=("/image/persoMort.png");
                    grillePrincipale.Children.Clear();
                    AfficherJoueur();
                    //Appel de l'écran de fin de partie
                    partieEnCours = false;
                    ecranMeilleurScore ecranM = new ecranMeilleurScore();
                    ecranM.Show();
                    System.Threading.Thread.Sleep(1000);
                    Close();
                 }
             }


            private void item1_click(object sender, RoutedEventArgs e)
            {
                if (partieNormal.obj1 != null) 
                {
                    partieNormal.obj1.unEffet.action();
                    partieNormal.obj1 = null;
                    validationVie();
                    item1.Background = null;
                }

            }

            private void item2_click(object sender, RoutedEventArgs e)
            {
                if (partieNormal.obj2 != null)
                {
                    partieNormal.obj2.unEffet.action();
                    partieNormal.obj2 = null;
                    validationVie();
                    item2.Background = null;

                }

            }
    }
}
