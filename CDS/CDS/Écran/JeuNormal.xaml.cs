using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
        Timer tim = new Timer();
        Timer timerFin = new Timer();
        public JeuNormal()
        {
            InitializeComponent();
            Globale.j1.pathImage="/image/perso.png";

            tim.Tick += new EventHandler(OnTimedEvent);
            tim.Interval = 2000;

            txtCTour.Text = tour.ToString();
            mouvement.Text = Globale.j1.vitesse.ToString();

            partieNormal.initialiser();
            txtCScore.Text = partieNormal.score.ToString();

            validationVie();
            AfficherJoueur();
            AfficherPoursuivant();
            tim.Start();
        }

        private void OnTimedEvent(object sender, EventArgs e) 
        {
                tim.Stop();
                generationTour();
                afficherInfo();
        }


        private void OnTimedEvent2(object sender, EventArgs e)
        {
            timerFin.Stop();
            //Appel de l'écran de fin de partie
            //Utiliser un timer pour afficher l'ecran après 5 secondes.

            //va setter le score avec celui de fin de partie en globale pour y avoir accès dans le nouvel écran
            Globale.score.score = partieNormal.score;

            ecranMeilleurScore ecranM = new ecranMeilleurScore();
            ecranM.Show();
            timerFin = null;
            Close();
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
            if (partieEnCours == true)
            {
                deplacerHaut();
                afficherInfo();
            }
        }

        private void bas(object sender, RoutedEventArgs e)
        {
            if (partieEnCours == true)
            {
                deplacerBas();
                afficherInfo();
            }
        }

        private void droite(object sender, RoutedEventArgs e)
        {
            if (partieEnCours == true)
            {
                deplacerDroite();
                afficherInfo();
            }
        }

        private void gauche(object sender, RoutedEventArgs e)
        {
            if (partieEnCours == true)
            {
                deplacerGauche();
                afficherInfo();
            }
        }

        private void btnPasserTour_Click(object sender, RoutedEventArgs e)
        {
            if (partieEnCours == true)
            {
                if (Globale.j1.vitesse > 1)
                {
                    afficherEntiteGrille();
                }
                else
                {
                    generationTour();
                }
                afficherInfo();
            }
        }     

        private void grilleJeuWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
       
              //Vers le bas
              if(Keyboard.IsKeyDown(Key.Down))
              {
                  if (partieEnCours == true)
                  {
                      deplacerBas();
                      afficherInfo();
                  }
              }
            //Vers le Haut
              if(Keyboard.IsKeyDown(Key.Up))
              {
                  if (partieEnCours == true)
                  {
                      deplacerHaut();
                      afficherInfo();
                  }
              }
            //Vers la droite
            if(Keyboard.IsKeyDown(Key.Right))
            {
                if (partieEnCours == true)
                {
                    deplacerDroite();
                    afficherInfo();
                }
            }
            //Vers la gauche
            if(Keyboard.IsKeyDown(Key.Left))
            {
                if (partieEnCours == true)
                {
                    deplacerGauche();
                    afficherInfo();
                }
            }

            //Bouton X(item)
            if(Keyboard.IsKeyDown(Key.X))
            {
                if (partieEnCours == true)
                {
                    if (partieNormal.obj2 != null)
                    {
                        tim.Stop();
                        partieNormal.obj2.unEffet.action();
                        mouvement.Text = Globale.j1.vitesse.ToString();
                        partieNormal.obj2 = null;
                        validationVie();
                        item2.Background = null;
                        tim.Start();
                    }
                }
            }
            

            //Bouton Z(item)
            if(Keyboard.IsKeyDown(Key.Z))
            {
                if (partieEnCours == true)
                {
                    if (partieNormal.obj1 != null)
                    {
                        tim.Stop();
                        partieNormal.obj1.unEffet.action();
                        mouvement.Text = Globale.j1.vitesse.ToString();
                        partieNormal.obj1 = null;
                        validationVie();
                        item1.Background = null;
                        tim.Start();
                    }
                }
            } 
            //Bouton Enter(passer le tour)
            if(Keyboard.IsKeyDown(Key.Enter))
            {
                if(partieEnCours == true)
                {
                    if (Globale.j1.vitesse > 1)
                    {
                        afficherEntiteGrille();
                    }
                    else
                    {
                        generationTour();
                    }
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
                    if(Globale.j1.vitesse > 1)
                    {
                        afficherEntiteGrille();
                    }
                    else
                    {
                        generationTour();
                     }
                }
            }

            void deplacerGauche()
            {
                if (Globale.j1.positionJoueur.posX > 1)
                {
                    Globale.j1.positionJoueur.posX = Globale.j1.positionJoueur.posX - 1;
                    if (Globale.j1.vitesse > 1)
                    {
                        afficherEntiteGrille();
                    }
                    else
                    {
                        generationTour();
                    }
                }
            }

            void deplacerHaut()
            {
                if (Globale.j1.positionJoueur.posY > 1)
                {
                    Globale.j1.positionJoueur.posY = Globale.j1.positionJoueur.posY - 1;
                    if (Globale.j1.vitesse > 1)
                    {
                        afficherEntiteGrille();
                    }
                    else
                    {
                        generationTour();
                    }
                }
            }

            void deplacerBas()
            {
                 if (Globale.j1.positionJoueur.posY < Globale.tailleGrille - 2)
                  {
                      Globale.j1.positionJoueur.posY = Globale.j1.positionJoueur.posY + 1;
                      if (Globale.j1.vitesse > 1)
                      {
                          afficherEntiteGrille();
                      }
                      else
                      {
                          generationTour();
                      }
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
                grillePrincipale.Children.Clear();
                //va éffacer la grille a chaque déplacement et va réafficher le joueur à sa nouvelle position
                if(tim.Enabled)
                {
                    tim.Stop();
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
                if (partieEnCours != false)
                {
                    tim.Start();
                }

            }
			
			public void validationObjectifPartieNormal()
            {
                if (partieNormal.finDeTour() == false)
                {
                    tim = null;
                    timerFin.Interval = 1500;
                    timerFin.Tick += new EventHandler(OnTimedEvent2);

                    Globale.j1.pathImage=("/image/persoMort.png");
                    grillePrincipale.Children.Clear();
                    AfficherJoueur();
                    partieEnCours = false;
                    timerFin.Start();
                 }
             }


            private void item1_click(object sender, RoutedEventArgs e)
            {
                if (partieNormal.obj1 != null) 
                {
                    tim.Stop();
                    partieNormal.obj1.unEffet.action();
                    mouvement.Text = Globale.j1.vitesse.ToString();
                    partieNormal.obj1 = null;
                    validationVie();
                    item1.Background = null;
                    tim.Start();
                }

            }

            private void item2_click(object sender, RoutedEventArgs e)
            {
                if (partieNormal.obj2 != null)
                {
                    tim.Stop();
                    partieNormal.obj2.unEffet.action();
                    mouvement.Text = Globale.j1.vitesse.ToString();
                    partieNormal.obj2 = null;
                    validationVie();
                    item2.Background = null;
                    tim.Start();

                }

            }

            public void afficherEntiteGrille()
            {
                Globale.j1.vitesse -= 1;
                mouvement.Text = Globale.j1.vitesse.ToString();
                grillePrincipale.Children.Clear();
                AfficherJoueur();
                AfficherPoursuivant();
                AfficherObjet();
            }
    }
}
