using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CDS
{
    public abstract class Entite
    {
        protected string listeCMD {get;set;}
        protected int age { get; set; }
        protected string urlImage { get; set; }
        protected int direction { get; set; }//1 à 4
        public Position positionEntite { get; set; }
		
		 protected Entite(string listeC,string image) 
        {
            positionEntite = new Position();
            listeCMD=listeC;
            urlImage=image;
            age = 0;
        }

        //lire la liste CMD et agire
        public abstract bool action();
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
        /// Valide si l'entité est dans une zone interdite (rouge)
        /// </summary>
        /// <returns></returns>
        public bool inBoundary()
        {
            if(positionEntite.posX == 0 || positionEntite.posX == 10 || positionEntite.posY == 0 || positionEntite.posY == 10)
            {
                return true;
            }
            else
            {return false;}
        }

        /// <summary>
        /// Verifier si sur la cas du jouer, sur un effet.
        /// </summary>
        /// <returns></returns>
        public bool verification()
        {
            if (positionEntite.posX == Globale.j1.positionJoueur.posX && positionEntite.posY == Globale.j1.positionJoueur.posY)
            {
                return true;
            }
            return false;
        }
    }
}
