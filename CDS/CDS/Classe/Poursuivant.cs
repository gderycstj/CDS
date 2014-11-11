using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CDS
{
    public class Poursuivant:Entite
    {
		public int valeur { get; set; }
        public int rareté { get; set; }
        public int valeurScore { get; set; }

		
        /// <summary>
        /// Constructeur d'un poursuivant
        /// </summary>
        /// <param name="listeE">Liste d'effet qu'un poursuivant peut avoir</param>
        /// <param name="listC">liste de commande du poursuivant</param>
        /// <param name="url">url de l'image</param>
        public Poursuivant(int Pvaleur,int Prareté,string listC,string url,int valeurScoreP):base(listC,url)
        {
            
            valeur = Pvaleur;
            rareté = Prareté;
            valeurScore = valeurScoreP;
            int randomLosange = 2;
            positionEntite = new Position();
            Random lesPositions = new Random();
            direction = lesPositions.Next(1, 5);
        
            int memoireRdm ;
            memoireRdm = lesPositions.Next(1, 10);
            switch (direction)
            {
                case 1:
                    positionEntite.posX =  memoireRdm;
                    positionEntite.posY = 0;
                    break;
                case 2:
                    positionEntite.posX = 10;
                    positionEntite.posY = memoireRdm;
                    break;
                case 3:
                    positionEntite.posX = memoireRdm;
                    positionEntite.posY = 10;
                    //inverse les case 9->1, 8->2, 7->3, 6->4, 5->5, 4->6... Pour verification
                    memoireRdm = (memoireRdm - 10) * -1;
                    break;
                case 4:
                    positionEntite.posX = 0;
                    positionEntite.posY = memoireRdm;
                    //inverse les case 9->1, 8->2, 7->3, 6->4, 5->5, 4->6... Pour verification
                    memoireRdm = (memoireRdm - 10) * -1;
                    break;
                default://arrivera jamais mais pour que le compilateur me foute la paix
                    break;
            }

            //Validation Carrer(selon sa direction)
            if(urlImage == "/image/carreVert.png")
            {
                if(direction == 1 || direction == 3)
                {
                    urlImage = "/image/carreBleu.png";
                }
            }

            if(urlImage == "/image/carreBleu.png")
            {
                if (direction == 2 || direction == 4)
                {
                    urlImage = "/image/carreVert.png";
                }
            }
            //-----------------------------------------------------------
            //Validation Losange(selon son positionnement)
            if(urlImage == "/image/LosangeMauve.png")
            {
                  if(memoireRdm == 5)
                   {
                        randomLosange = lesPositions.Next(1, 3);
                        if (randomLosange == 2)
                        {
                            urlImage = "/image/LosangeJaune.png";
                            listeCMD = "MhMgC";
                        }
                    }
                   else if(memoireRdm <5)
                    {
                         urlImage = "/image/LosangeJaune.png";
                         listeCMD = "MhMgC";
                    }     
            }
            else if (urlImage == "/image/LosangeJaune.png")
            {
                if (memoireRdm == 5)
                {
                    randomLosange = lesPositions.Next(1, 3);
                    if (randomLosange == 1)
                    {
                        urlImage = "/image/LosangeMauve.png";
                        listeCMD = "MhMdC";
                    }
                }
                else if (memoireRdm > 5)
                {
                    urlImage = "/image/LosangeMauve.png";
                    listeCMD = "MhMdC";
                }
            }
            
            //-------------------------------------------------------------------------
        }

        /// <summary>
        /// lire la liste CMD et agir
        /// </summary>
        /// <returns> que tout est correct</returns>
        public override bool action()
        {
            int temps=0;
            int numAction=0;
            string[] tabCMD = { "" };
            string CMD = "";
            

            //Verifie si c'est en plusieur temps et prend la bonne partie de la chaine
            //Si c'est un seul temps, il prend la chaine au complet
            if (listeCMD.Contains('/'))
            {
                //Calculer en combien de tour il fait un cyle
                temps= listeCMD.Count(f => f== '/');


                /*Calculer a quel cycle on est rendu et quel partie chaine on doit mettre dans CMD*/
                numAction = age % temps;
                

                //un tableau de string avec tout les temps séparer
                tabCMD = listeCMD.Split(new char[] { '/' });


                //Mettre la section de listeCMD dans CMD
                CMD = tabCMD[numAction];
            }
            else
            {
                CMD = listeCMD;
            }

            //Lecture de CMD   
            lire(CMD);


            return true;
        }

        public Image obtenirImage() 
        {
            Image img = new Image();
            BitmapImage bImg = new BitmapImage();

            bImg.BeginInit();
            bImg.UriSource = new Uri(urlImage, UriKind.RelativeOrAbsolute);
            bImg.DecodePixelWidth = 60;
            bImg.EndInit();

            img.Source = bImg;

            return img;
        
         }

        private bool lire(char[] CMD)
        {
            string newCMD=CMD.ToString();

            return lire(newCMD);
        }

        /// <summary>
        /// Lit la chaine de commande
        /// </summary>
        /// <param name="CMD">la chaine de commande</param>
        private bool lire(string CMD)
        {
            char lettre;
            char lettre2;
            char lettre3;

            string sousCMD=""; //Une sous liste pour savoir quoi faire pour le if

            int numero;
            int iLecture = 0;
            int incrementation=0;// la profondeur et quantiter de if dans un if dans un if dans... etc.
            int iEcriture=0;//

            bool faitwhile=true;



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
                                switch(direction)
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
                                        mouvementNord();
                                        break;

                                    case 3:
                                        mouvementEst();
                                        break;

                                    case 4:
                                        mouvementSud();
                                        break;

                                    case 1:
                                        mouvementOuest();
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
                                        mouvementNord();
                                        break;

                                    case 1:
                                        mouvementEst();
                                        break;

                                    case 2:
                                        mouvementSud();
                                        break;

                                    case 3:
                                        mouvementOuest();
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
                        if(CMD[iLecture]>='0' && CMD[iLecture]<='9')
                        {
                            numero = numero*10;//le nombre précédent est a la position des dizaine
                            numero = numero + (CMD[iLecture]-'0');
                            iLecture++;
                        }

                       

                        //on lance l'effet commandé
                        

                        break;

                    //=====If=====
                    case 'I':
                        //on prend en note la lettre qui suit pour...
                        lettre2 = CMD[iLecture];
                        iLecture++;

                        lettre3 = CMD[iLecture];
                         iLecture++;

                        //...pouvoir isolet la/les actions en cas de true
                        faitwhile=true;
                        iEcriture=0;
                        sousCMD="";
                        while(faitwhile)
                        {
                            switch(CMD[iLecture])
                            {
                                case '{':
                                    //Acolade qui ne viennent pas du if en cours de traitage
                                    //on veut l'acolade dans la sousliste
                                    if(incrementation!=0)
                                    {
                                        sousCMD = sousCMD.Insert(iEcriture,CMD.Substring(iLecture,1));
                                    //sousCMD[iEcriture] = CMD[iLecture];
                                        iEcriture++;
                                    }
                                    incrementation++;
                                    break;

                                case '}':
                                    //idem de l'autre acolade
                                    if(incrementation!=1)
                                    {
                                        sousCMD = sousCMD.Insert(iEcriture,CMD.Substring(iLecture,1));
                                    //sousCMD[iEcriture] = CMD[iLecture];
                                        iEcriture++;
                                    }
                                    incrementation--;
                                    break;

                                default:
                                    sousCMD = sousCMD.Insert(iEcriture,CMD.Substring(iLecture,1));
                                    //sousCMD[iEcriture]=CMD[iLecture];
                                    iEcriture++;
                                    break;
                            }

                            iLecture++;
                            if(incrementation<=0)
                                faitwhile=false;
                        }

                        //on lit la lettre prise en réserve plus tôt pour savoir quoi vérifier
                        switch(lettre2)
                        {
                            //=====Joueur=====
                            case 'j':
                                

                                switch(lettre3)
                                {
                                    //haut
                                    case 'h':
                                        switch (direction)
                                        {
                                            case 1:
                                                if (ifJoueurSud())
                                                    if(!lire(sousCMD))
                                                    {
                                                        CMD="";
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
                                                if(ifJoueurSud())
                                                    if (!lire(sousCMD))
                                                    {
                                                        CMD = "";
                                                        return false;
                                                    }
                                                break;

                                            case 3:
                                                if(ifJoueurOuest())
                                                    if (!lire(sousCMD))
                                                    {
                                                        CMD = "";
                                                        return false;
                                                    }
                                                break;

                                            case 4:
                                                if(ifJoueurNord())
                                                    if (!lire(sousCMD))
                                                    {
                                                        CMD = "";
                                                        return false;
                                                    }
                                                break;

                                            case 1:
                                                if(ifJoueurEst())
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
                                        if(ifJoueurProche())
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

                    //=====Check=====
                    case 'C':
                        //vérifie si le joueur est là, s'il ne marcher pas sur du feu, s'il active une mine, etc.
                        //bouger sans faire de check, c'est de la téléportation
                        if (verification())
                        { 
                            CMD="";
                            return false;
                        }
                        break;
                }
                if (iLecture >= CMD.Length)
                {
                    CMD = "";
                }
            }
            return true;
        }

        
        public override bool finDetour()
        {
            age++;
            return true;
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


        /// <summary>
        /// Verifier si sur la cas du jouer, sur un effet.
        /// </summary>
        /// <returns></returns>
        public override bool verification()
        {
            if (positionEntite.posX == Globale.j1.positionJoueur.posX && positionEntite.posY == Globale.j1.positionJoueur.posY)
            {
                return true;
            }
            return false;
        }

    }
}
