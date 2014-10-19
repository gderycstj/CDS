using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    class Poursuivant:Entite
    {
        List<Effet> listeEffet;


        //lire la liste CMD et agire
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



            return true;
        }


        /// <summary>
        /// Lit la chaine de commande
        /// </summary>
        /// <param name="CMD">la chaine de commande</param>
        private void lire(string CMD, List<Effet> listeEffet )
        {
            char lettre;
            char lettre2;
            char lettre3;
            int numero;
            int iLecture = 0;
            while (CMD != "")
            {


                lettre = CMD[iLecture];
                iLecture++;
                switch (lettre)
                {
                    //=====Mouvement=====
                    case 'M':
                        lettre2 = CMD[iLecture];
                        iLecture++;

                        switch (lettre2)
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

                    //=====Effet=====
                    case 'E':
                        numero = CMD[iLecture];
                        iLecture++;

                        numero -= 48; //du code ascii au numero lui-même

                        //on lance l'effet commandé
                        listeEffet[numero].action();

                        break;

                    //=====If=====
                    case 'I':
                        lettre2 = CMD[iLecture];
                        iLecture++;

                        switch(lettre2)
                        {
                            //=====Joueur=====
                            case 'p':
                                lettre3 = CMD[iLecture];
                                iLecture++;

                                switch(lettre3)
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

                    //=====Check=====
                    case 'C':
                        //vérifie si le joueur est là, s'il ne marcher pas sur du feu, s'il active une mine, etc.
                        //bouger sans faire de check, c'est de la téléportation
                        break;
                }
            }
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
