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
        public Case positionEntite { get; set; }
		
		 protected Entite(string listeC,string image) 
        {
            positionEntite = new Case();
            listeCMD=listeC;
            urlImage=image;
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
        /// Valide si l'entité est dans une zone interdite (rouge)
        /// </summary>
        /// <returns></returns>
        protected bool inBoundary()
        {
            if(positionEntite.pos.posX == 0 || positionEntite.pos.posX == 10 || positionEntite.pos.posY == 0 || positionEntite.pos.posY == 10)
            {
                return false;
            }
            else
            {return true;}
        }

        /// <summary>
        /// Verifier si sur la cas du jouer, sur un effet.
        /// </summary>
        /// <returns></returns>
        protected bool verification()
        {
            if(positionEntite.pos.posX == Globale.j1.positionJoueur.pos.posX && positionEntite.pos.posY == Globale.j1.positionJoueur.pos.posY)
            {
                //L'entité est sur la case du joueur
                return true;
            }
            return false;
        }

    }
}
