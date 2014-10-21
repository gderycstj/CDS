using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    public class Partie
    {
        GrilleDeJeu grille { get;set;}
        int score { get;set;}
        Vie vie { get; set; }
        Objectif objectif { get;set;}
        int qtyObjetsMax;
        Objet[] objets {get;set;}
        MemoireDEntite regleaparition { get;set;}

        public Partie()
        {   
            score = 0;
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
        bool finDeTour()
        {
            grille.finDeTour();
            vie.finDeTour();
            objectif.finDeTour();
            return true;
        }

        public int GetScore(){
            int nouvScore;
            nouvScore = score;
            return nouvScore;
        }
    }
}
