using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    public class Effet:Entite
    {
           List<Effet> listeEffet;
           bool estDangereux = false;

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

            string sousCMD = ""; //Une sous liste pour savoir quoi faire pour le if
            string[] tabCMD = { "" };

            int numero;
            int iLecture = 0;
            int incrementation=0;// la profondeur et quantiter de if dans un if dans un if dans... etc.
            int iEcriture=0;//

            bool faitwhile = true;
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
                                       if (mouvementSud())
                                       {
                                           CMD = "";
                                           return false;
                                       }
                                       break;

                                   case 2:
                                       if (mouvementOuest())
                                       {
                                           CMD = "";
                                           return false;
                                       }
                                       break;

                                   case 3:
                                       if (mouvementNord())
                                       {
                                           CMD = "";
                                           return false;
                                       }
                                       break;

                                   case 4:
                                       if (mouvementEst())
                                       {
                                           CMD = "";
                                           return false;
                                       }
                                       break;
                               }
                               break;

                           //Droite
                           case 'd':
                               switch (direction)
                               {
                                   case 2:
                                       if (mouvementNord())
                                       {
                                           CMD = "";
                                           return false;
                                       }
                                       break;

                                   case 3:
                                       if (mouvementEst())
                                       {
                                           CMD = "";
                                           return false;
                                       }
                                       break;

                                   case 4:
                                       if (mouvementSud())
                                       {
                                           CMD = "";
                                           return false;
                                       }
                                       break;

                                   case 1:
                                       if (mouvementOuest())
                                       {
                                           CMD = "";
                                           return false;
                                       }
                                       break;
                               }
                               break;

                           //Bas
                           case 'b':
                               switch (direction)
                               {
                                   case 3:
                                       if (mouvementSud())
                                       {
                                           CMD = "";
                                           return false;
                                       }
                                       break;

                                   case 4:
                                       if (mouvementOuest())
                                       {
                                           CMD = "";
                                           return false;
                                       }
                                       break;

                                   case 1:
                                       if (mouvementNord())
                                       {
                                           CMD = "";
                                           return false;
                                       }
                                       break;

                                   case 2:
                                       if (mouvementEst())
                                       {
                                           CMD = "";
                                           return false;
                                       }
                                       break;
                               }
                               break;

                           //Gauche
                           case 'g':
                               switch (direction)
                               {
                                   case 4:
                                       if (mouvementNord())
                                       {
                                           CMD = "";
                                           return false;
                                       }
                                       break;

                                   case 1:
                                       if (mouvementEst())
                                       {
                                           CMD = "";
                                           return false;
                                       }
                                       break;

                                   case 2:
                                       if (mouvementSud())
                                       {
                                           CMD = "";
                                           return false;
                                       }
                                       break;

                                   case 3:
                                       if (mouvementOuest())
                                       {
                                           CMD = "";
                                           return false;
                                       }
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

                       lettre3 = CMD[iLecture];
                       iLecture++;

                       //...pouvoir isolet la/les actions en cas de true
                       incrementation = 0;
                       faitwhile = true;
                       iEcriture = 0;
                       sousCMD = "";
                       while (faitwhile)
                       {
                           switch (CMD[iLecture])
                           {
                               case '{':
                                   //Acolade qui ne viennent pas du if en cours de traitage
                                   //on veut l'acolade dans la sousliste
                                   if (incrementation != 0)
                                   {
                                       sousCMD = sousCMD.Insert(iEcriture, CMD.Substring(iLecture, 1));
                                       //sousCMD[iEcriture] = CMD[iLecture];
                                       iEcriture++;
                                   }
                                   incrementation++;
                                   break;

                               case '}':
                                   //idem de l'autre acolade
                                   if (incrementation != 1)
                                   {
                                       sousCMD = sousCMD.Insert(iEcriture, CMD.Substring(iLecture, 1));
                                       //sousCMD[iEcriture] = CMD[iLecture];
                                       iEcriture++;
                                   }
                                   incrementation--;
                                   break;

                               default:
                                   sousCMD = sousCMD.Insert(iEcriture, CMD.Substring(iLecture, 1));
                                   //sousCMD[iEcriture]=CMD[iLecture];
                                   iEcriture++;
                                   break;
                           }

                           iLecture++;
                           if (incrementation <= 0)
                               faitwhile = false;
                       }

                       //on lit la lettre prise en réserve plus tôt pour savoir quoi vérifier
                       switch (lettre2)
                       {
                           //=====Joueur=====
                           case 'j':


                               switch (lettre3)
                               {
                                   //haut
                                   case 'h':
                                       switch (direction)
                                       {
                                           case 1:
                                               if (ifJoueurSud())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;

                                           case 2:
                                               if (ifJoueurOuest())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;

                                           case 3:
                                               if (ifJoueurNord())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;

                                           case 4:
                                               if (ifJoueurEst())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;
                                       }
                                       break;
                                   //Droit
                                   case 'd':
                                       switch (direction)
                                       {
                                           case 4:
                                               if (ifJoueurSud())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;

                                           case 1:
                                               if (ifJoueurOuest())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;

                                           case 2:
                                               if (ifJoueurNord())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;

                                           case 3:
                                               if (ifJoueurEst())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;
                                       }
                                       break;
                                   //Bas
                                   case 'b':
                                       switch (direction)
                                       {
                                           case 3:
                                               if (ifJoueurSud())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;

                                           case 4:
                                               if (ifJoueurOuest())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;

                                           case 1:
                                               if (ifJoueurNord())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;

                                           case 2:
                                               if (ifJoueurEst())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;
                                       }
                                       break;
                                   //Gauche
                                   case 'g':
                                       switch (direction)
                                       {
                                           case 2:
                                               if (ifJoueurSud())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;

                                           case 3:
                                               if (ifJoueurOuest())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;

                                           case 4:
                                               if (ifJoueurNord())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;

                                           case 1:
                                               if (ifJoueurEst())
                                                   if (!lire(sousCMD))
                                                   {
                                                       CMD = "";
                                                       return false;
                                                   }
                                               break;
                                       }
                                       break;
                                   //Proximité
                                   case 'p':
                                       if (ifJoueurProche())
                                           if (!lire(sousCMD))
                                           {
                                               CMD = "";
                                               return false;
                                           }
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
                           case 'p':
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

                   //=====Random=====
                   case 'R':
                       Random Rdm = new Random();

                       numero = 0; //qty de possibilité
                       faitwhile = true;
                       iEcriture = 0;
                       sousCMD = "";
                       while (faitwhile)
                       {
                           switch (CMD[iLecture])
                           {
                               case '{':
                                   //Acolade qui ne viennent pas du Random en cours de traitage
                                   //on veut l'acolade dans la sousliste
                                   if (incrementation != 0)
                                   {
                                       sousCMD = sousCMD.Insert(iEcriture, CMD.Substring(iLecture, 1));
                                       iEcriture++;
                                   }
                                   else//acolade du random en cours
                                   {
                                       numero++;

                                   }
                                   iLecture++;
                                   incrementation++;
                                   break;

                               case '}':
                                   //idem de l'autre acolade
                                   if (incrementation != 1)
                                   {
                                       sousCMD = sousCMD.Insert(iEcriture, CMD.Substring(iLecture, 1));
                                       iEcriture++;
                                   }
                                   else//acolade du random en cours
                                   {
                                       //on ajoute un / pour séparer les chaines de sousCMD comme les actions en plusieur temps dans action()
                                       sousCMD = sousCMD.Insert(iEcriture, "/");
                                       iEcriture++;
                                   }
                                   iLecture++;
                                   incrementation--;
                                   break;

                               default:
                                   //si on n'est plus dans une des possiblillité du random, on veux pas avoir le début de la prochaine commande
                                   //le if a la fin vas terminer le while si on entre pas dans ce if
                                   if (incrementation > 0)
                                   {
                                       sousCMD = sousCMD.Insert(iEcriture, CMD.Substring(iLecture, 1));
                                       iEcriture++;
                                       iLecture++;
                                   }
                                   else
                                       faitwhile = false;
                                   break;
                           }


                           if (iLecture >= CMD.Length)
                               faitwhile = false;

                       }

                       //on cinde sousCMD en plusieur chaine
                       //un tableau de string avec toutes les possibilitées séparé
                       tabCMD = sousCMD.Split(new char[] { '/' });


                       //Mettre la section de listeCMD dans CMD
                       sousCMD = tabCMD[Rdm.Next(0, numero)];

                       if (!lire(sousCMD))
                       {
                           CMD = "";
                           return false;
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
                    case '*': 
                    Globale.vie.toursImmunite++;
                    break;
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
        public bool mouvementNord()
        {
            this.positionEntite.posY = positionEntite.posY - 1;
            return inBoundary();
        }

        /// <summary>
        /// WIP mouvement vers le bas
        /// </summary>
        public bool mouvementSud()
        {
            this.positionEntite.posY = positionEntite.posY + 1;
            return inBoundary();
        }

        /// <summary>
        /// WIP mouvement vers la droite
        /// </summary>
        public bool mouvementEst()
        {
            this.positionEntite.posX = positionEntite.posX + 1;
            return inBoundary();
        }

        /// <summary>
        /// WIP mouvement vers la gauche
        /// </summary>
        public bool mouvementOuest()
        {
            this.positionEntite.posX = positionEntite.posX - 1;
            return inBoundary();
        }

        /// <summary>
        /// Valide si l'entité est dans une zone interdite (rouge)
        /// </summary>
        /// <returns></returns>
        public override bool inBoundary()
        {
            if (positionEntite.posX == 0 || positionEntite.posX == 10 || positionEntite.posY == 0 || positionEntite.posY == 10)
            {
                return true;
            }
            else
            { return false; }
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
