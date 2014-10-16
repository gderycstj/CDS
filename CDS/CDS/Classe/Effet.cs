using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    class Effet:Entite
    {
        /// <summary>
        /// lire la liste CMD et agire
        /// </summary>
        /// <returns> que tout est correct</returns>
        public override bool action()
        {
            string [] tabCMD={""};
            string CMD="";
            char lettre;
            char lettre2;
            int  iLecture=0;

            //Verifie si c'est en plusieur temps et prend la bonne partie de la chaine
            //Si c'est un seul temps, il prend la chaine au complet
            if (listeCMD.Contains('/'))
            {
                //Calculer en combien de tour il fait un cyle



                //Calculer a quel cycle on est rendu et quel partie chaine on doit mettre dans CMD

                //un tableau de string avec tout les temps séparer
                tabCMD= listeCMD.Split(new char [] {'/'} );


                //Mettre la section de listeCMD dans CMD

            }
            else
            {
                CMD = listeCMD;
            }

            //Lecture de CMD
            while(CMD!="")
            {
               

               lettre= CMD[iLecture];
               iLecture++;
               switch(lettre)
               {
                    //=====Mouvement=====
                    case 'M':
                        lettre2= CMD[iLecture];
                        iLecture++;
                        
                        switch(lettre2)
                        {
                            //Haut
                            case 'h':
                                break;
                            
                            //Droite
                            case 'd':
                                break;
                            
                            //Bas
                            case 'b':
                                break;
                            
                            //Gauche
                            case 'g':
                                break;
                        }
                    break;
                    
                    //
                   case 'D':
                    break;

               }

            }






            return true;
        }
        //détruire l'entité et faire les modification associé
        public override bool mort()
        {
            return true;
        }
        //Vérification et action effectuer à chaque fin de tour
        public override bool finDetour()
        {
            age++;
            return true;
        }

    }
}
