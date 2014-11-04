﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    public class Effet:Entite
    {
           List<Effet> listeEffet;
		public Effet(string listC,string url):base(listC,url)
        {
        }
		
        /// <summary>
        /// lire la liste CMD et agire
        /// </summary>
        /// <returns> que tout est correct</returns>
        public override bool action()
        {
            string[] tabCMD = { "" };
            string CMD = "";
            

            //Verifie si c'est en plusieur temps et prend la bonne partie de la chaine
            //Si c'est un seul temps, il prend la chaine au complet
            if (listeCMD.Contains('/'))
            {
                //Calculer en combien de tour il fait un cyle



                //Calculer a quel cycle on est rendu et quel partie chaine on doit mettre dans CMD

                //un tableau de string avec tout les temps séparer
                tabCMD = listeCMD.Split(new char[] { '/' });


                //Mettre la section de listeCMD dans CMD

            }
            else
            {
                CMD = listeCMD;
            }

            //Lecture de CMD   
            lire(CMD);


            return true;
        }

        private bool lire(char[] CMD)
        {
            string newCMD=CMD.ToString();

            return lire(newCMD);
        }


        private bool lire(string CMD)
        {
            char lettre;
            char lettre2;
            char lettre3;

            char[] sousCMD={'\0'}; //Une sous liste pour savoir quoi faire pour le if

            int numero;
            int iLecture = 0;
            int incrementation=0;// la profondeur et quantiter de if dans un if dans un if dans... etc.
            int iEcriture=0;//

            bool endif=false;
            //Lecture de CMD
            while(CMD!="")
            {

               lettre= CMD[iLecture];
               iLecture++;
               switch(lettre)
               {
                   //=====Mouvement=====
                   case 'M':
                       lettre2 = CMD[iLecture];
                       iLecture++;

                       switch (lettre2)
                       {
                           //Haut
                           case 'h':
                               switch (direction)
                               {
                                   case 1:
                                       mouvementSud();
                                       break;

                                   case 2:
                                       mouvementOuest();
                                       break;

                                   case 3:
                                       mouvementNord();
                                       break;

                                   case 4:
                                       mouvementEst();
                                       break;
                               }
                               break;

                           //Droite
                           case 'd':
                               switch (direction)
                               {
                                   case 2:
                                       mouvementSud();
                                       break;

                                   case 3:
                                       mouvementOuest();
                                       break;

                                   case 4:
                                       mouvementNord();
                                       break;

                                   case 1:
                                       mouvementEst();
                                       break;
                               }
                               break;

                           //Bas
                           case 'b':
                               switch (direction)
                               {
                                   case 3:
                                       mouvementSud();
                                       break;

                                   case 4:
                                       mouvementOuest();
                                       break;

                                   case 1:
                                       mouvementNord();
                                       break;

                                   case 2:
                                       mouvementEst();
                                       break;
                               }
                               break;

                           //Gauche
                           case 'g':
                               switch (direction)
                               {
                                   case 4:
                                       mouvementSud();
                                       break;

                                   case 1:
                                       mouvementOuest();
                                       break;

                                   case 2:
                                       mouvementNord();
                                       break;

                                   case 3:
                                       mouvementEst();
                                       break;
                               }
                               break;
                       }
                       break;

                   //=====Effet=====
                   case 'E':
                       numero = CMD[iLecture];
                       iLecture++;
                       numero -= '0'; //du code ascii au numero lui-même

                       //si c'est un effet entre 10 et 99
                       if (CMD[iLecture] >= '0' && CMD[iLecture] <= '9')
                       {
                           numero = numero * 10;//le nombre précédent est a la position des dizaine
                           numero = numero + (CMD[iLecture] - '0');
                           iLecture++;
                       }



                       //on lance l'effet commandé
                       listeEffet[numero].action();

                       break;

                   //=====If=====
                   case 'I':
                       //on prend en note la lettre qui suit pour...
                       lettre2 = CMD[iLecture];
                       iLecture++;

                       //...pouvoir isolet la/les actions en cas de true
                       endif = false;
                       iEcriture = 0;
                       while (endif)
                       {
                           switch (CMD[iLecture])
                           {
                               case '{':
                                   //Acolade qui ne viennent pas du if en cours de traitage
                                   //on veut l'acolade dans la sousliste
                                   if (incrementation != 0)
                                   {
                                       sousCMD[iEcriture] = CMD[iLecture];
                                       iEcriture++;
                                   }
                                   incrementation++;
                                   break;

                               case '}':
                                   //idem de l'autre acolade
                                   if (incrementation != 1)
                                   {
                                       sousCMD[iEcriture] = CMD[iLecture];
                                       iEcriture++;
                                   }
                                   incrementation--;
                                   break;

                               default:
                                   sousCMD[iEcriture] = CMD[iLecture];
                                   iEcriture++;
                                   break;
                           }

                           iLecture++;
                           if (incrementation <= 0)
                               endif = true;
                       }

                       //on lit la lettre prise en réserve plus tôt pour savoir quoi vérifier
                       switch (lettre2)
                       {
                           //=====Joueur=====
                           case 'p':
                               lettre3 = CMD[iLecture];
                               iLecture++;

                               switch (lettre3)
                               {
                                   //haut
                                   case 'h':
                                       switch (direction)
                                       {
                                           case 1:
                                               if (ifJoueurSud())
                                                   lire(sousCMD);
                                               break;

                                           case 2:
                                               if (ifJoueurOuest())
                                                   lire(sousCMD);
                                               break;

                                           case 3:
                                               if (ifJoueurNord())
                                                   lire(sousCMD);
                                               break;

                                           case 4:
                                               if (ifJoueurEst())
                                                   lire(sousCMD);
                                               break;
                                       }
                                       break;
                                   //Droit
                                   case 'd':
                                       switch (direction)
                                       {
                                           case 2:
                                               if (ifJoueurSud())
                                                   lire(sousCMD);
                                               break;

                                           case 3:
                                               if (ifJoueurOuest())
                                                   lire(sousCMD);
                                               break;

                                           case 4:
                                               if (ifJoueurNord())
                                                   lire(sousCMD);
                                               break;

                                           case 1:
                                               if (ifJoueurEst())
                                                   lire(sousCMD);
                                               break;
                                       }
                                       break;
                                   //Bas
                                   case 'b':
                                       switch (direction)
                                       {
                                           case 3:
                                               if (ifJoueurSud())
                                                   lire(sousCMD);
                                               break;

                                           case 4:
                                               if (ifJoueurOuest())
                                                   lire(sousCMD);
                                               break;

                                           case 1:
                                               if (ifJoueurNord())
                                                   lire(sousCMD);
                                               break;

                                           case 2:
                                               if (ifJoueurEst())
                                                   lire(sousCMD);
                                               break;
                                       }
                                       break;
                                   //Gauche
                                   case 'g':
                                       switch (direction)
                                       {
                                           case 4:
                                               if (ifJoueurSud())
                                                   lire(sousCMD);
                                               break;

                                           case 1:
                                               if (ifJoueurOuest())
                                                   lire(sousCMD);
                                               break;

                                           case 2:
                                               if (ifJoueurNord())
                                                   lire(sousCMD);
                                               break;

                                           case 3:
                                               if (ifJoueurEst())
                                                   lire(sousCMD);
                                               break;
                                       }
                                       break;
                                   //Proximité
                                   case 'p':
                                       if (ifJoueurProche())
                                           lire(sousCMD);
                                       break;
                               }
                               break;
                           //=====Danger=====
                           case 'd':
                               lettre3 = CMD[iLecture];
                               iLecture++;
                               switch (lettre3)
                               {
                                   //haut
                                   case 'h':
                                       break;
                                   //Droit
                                   case 'd':
                                       break;
                                   //Bas
                                   case 'b':
                                       break;
                                   //Gauche
                                   case 'g':
                                       break;
                                   //Proximité
                                   case 'p':
                                       break;
                               }
                               break;
                           //=====Poursuivant=====
                           case 'e':
                               lettre3 = CMD[iLecture];
                               iLecture++;
                               switch (lettre3)
                               {
                                   //haut
                                   case 'h':
                                       break;
                                   //Droit
                                   case 'd':
                                       break;
                                   //Bas
                                   case 'b':
                                       break;
                                   //Gauche
                                   case 'g':
                                       break;
                                   //Proximité
                                   case 'p':
                                       break;
                               }
                               break;
                       }

                       break;

                    //Degat
                    case 'D': break;
                    //Soin    
                    case 'S': 
                    Globale.vie.soin(1);
                    break;
                    //Armure
                    case 'A': 
                    if(Globale.vie.nbArmure != Globale.vie.nbArmureMax)
                    { 
                        Globale.vie.nbArmure++;
                    }
                    break;
                    //Vitesse
                    case 'V':
                    Globale.j1.vitesse++; 
                    break;
                    //Pousse
                    case 'P': break;
                    //Invincibilité
                    case '*': break;
                }
               if (iLecture >= CMD.Length)
               {
                   CMD = "";
               }
        }
            return true;
        }
       
        //Vérification et action effectuer à chaque fin de tour
        public override bool finDetour()
        {
            age++;
            return true;
        }

        /// <summary>
        /// WIP mouvement vers le haut
        /// </summary>
        public void mouvementNord()
        {
            this.positionEntite.posY = positionEntite.posY - 1;
        }

        /// <summary>
        /// WIP mouvement vers le bas
        /// </summary>
        public void mouvementSud()
        {
            this.positionEntite.posY = positionEntite.posY + 1;
        }

        /// <summary>
        /// WIP mouvement vers la droite
        /// </summary>
        public void mouvementEst()
        {
            this.positionEntite.posX = positionEntite.posX + 1;
        }

        /// <summary>
        /// WIP mouvement vers la gauche
        /// </summary>
        public void mouvementOuest()
        {
            this.positionEntite.posX = positionEntite.posX - 1;
        }
        //Get nécéssaire
        public string getUrlImage()
        {
            return urlImage;
        }
        public string getListeCMD()
        {
            return listeCMD;
        }

    }
}
