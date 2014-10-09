using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    class Partie
    {
        GrilleDeJeu grille { get;set;}
        Score score { get;set;}
        Vie vie { get;set;}
        Objectif objectif { get;set;}
        int qtyObjetsMax;
        Objet[] objets {get;set;}
        MemoireDEntite regleaparition { get;set;}

        Partie()
        {}

        Partie(Vie viedepart, Objectif objParti,int maxobjets, List<Objet> objetDepart)
        {
            vie=viedepart;
            objectif=objParti;
            qtyObjetsMax=maxobjets;
            objetDepart.CopyTo(objets);
        }

        /// <summary>
        /// initialisation des param de base de la partie
        /// (transfèr de donné BD dans des classes)
        /// Est lancer dès le départ de jouer
        /// </summary>
        /// <returns>Si tout fonctione et que l'on peu faire une partie</returns>
        private bool initialiser()
        {
            if(/*Erreur*/false)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Le jeu (une sorte de sous-main)
        /// </summary>
        /// <returns>retourne si la partie s'est effectué</returns>
        public bool jouer()
        {

            if(initialiser())
            {
            
               return true;
            }

            return false;
        }


        bool finDeTour()
        {
            grille.finDeTour();
            vie.finDeTour();
            objectif.finDeTour();
            return true;
        }
    }
}
