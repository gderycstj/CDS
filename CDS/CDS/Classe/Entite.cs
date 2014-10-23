using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    abstract class Entite
    {
        protected string listeCMD {get;set;}
        protected int age { get; set; }
        protected string urlImage { get; set; }
        protected int direction { get; set; }//1 à 4
		
		 protected Entite(string listeC,string image) 
        {
            listeCMD=listeC;
            urlImage=image;
            direction = 0;
            age = 0;
        }
		
        //lire la liste CMD et agire
        public abstract bool action();
        //détruire l'entité et faire les modification associé
        public abstract bool mort();
        //Vérification et action effectuer à chaque fin de tour
        public abstract bool finDetour();

        /// <summary>
        /// WIP mouvement vers le haut
        /// </summary>
        protected void mouvementNord()
        {

        }

        /// <summary>
        /// WIP mouvement vers le bas
        /// </summary>
        protected void mouvementSud()
        {

        }

        /// <summary>
        /// WIP mouvement vers la droite
        /// </summary>
        protected void mouvementEst()
        {

        }

        /// <summary>
        /// WIP mouvement vers la gauche
        /// </summary>
        protected void mouvementOuest()
        {

        }

        /// <summary>
        /// Teste si le joueur est au nord de l'entite
        /// </summary>
        /// <returns>Si le joueur est au nord de l'entite</returns>
        protected bool ifJoueurNord()
        {
            return true;
        }

        /// <summary>
        /// Teste si le joueur est au sud de l'entite
        /// </summary>
        /// <returns>Si le joueur est au sud de l'entite</returns>
        protected bool ifJoueurSud()
        {
            return true;
        }

        /// <summary>
        /// Teste si le joueur est à l'est de l'entite
        /// </summary>
        /// <returns>Si le joueur est à l'est de l'entite</returns>
        protected bool ifJoueurEst()
        {
            return true;
        }

        /// <summary>
        /// Teste si le joueur est à l'ouest de l'entite
        /// </summary>
        /// <returns>Si le joueur est à l'ouest de l'entite</returns>
        protected bool ifJoueurOuest()
        {
            return true;
        }

        protected bool ifJoueurProche()
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected bool inBoundary()
        {
            return false;
        }

        /// <summary>
        /// Verifier si sur la cas du jouer, sur un effet.
        /// </summary>
        /// <returns></returns>
        protected bool verification()
        {
            return true;
        }

    }
}
