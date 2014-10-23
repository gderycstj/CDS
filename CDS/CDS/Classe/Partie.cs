using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CDS
{
    public class Partie
    {
        GrilleDeJeu grille { get;set;}
        int score { get;set;}
        Vie vie { get; set; }
        Objectif objectif { get;set;}
        int qtyObjetsMax;
        List<Poursuivant> PoursuivantDansLaPartie;
        List<Objet> objetDansLaPartie;

        public Partie()
        {   
            score = 0;
            PoursuivantDansLaPartie = new List<Poursuivant>();
            objetDansLaPartie = new List<Objet>();
        }

        /*public Partie(Vie viedepart, Objectif objParti,int maxobjets, List<Objet> objetDepart)
        {
            vie=viedepart;
            objectif=objParti;
            qtyObjetsMax=maxobjets;
            objetDepart.CopyTo(objets);
        }*/

        /// <summary>
        /// initialisation des param de base de la partie
        /// (transfèr de donné BD dans des classes)
        /// Est lancer dès le départ de jouer
        /// </summary>
        /// <returns>Si tout fonctione et que l'on peu faire une partie</returns>
        public bool initialiser()
        {
            //Requête BD
            //-------------------------------------------------------------------------------------------------------------
            
            //-------------------------------------------------------------------------------------------------------------

            //Traitement Requête (Création d'objet)

            //-------------------------------------------------------------------------------------------------------------
            return true;
        }
        private bool finDeTour()
        {
            bool validation = true;
            if(!grille.finDeTour())
            {
                validation = false;
            }
            if(!vie.finDeTour())
            {
                validation = false;
            }
            if(objectif.finDeTour())
            {
                validation = false;
            }

            if(!validation)
            {return false;}

            else { return true;}
        }

        public void validationObjectifPartieNormal()
        {
            if(!finDeTour())
            {
                //Appel de l'écran de fin de partie
            }

        }

        public int GetScore(){
            int nouvScore;
            nouvScore = score;
            return nouvScore;
        }
    }
}
