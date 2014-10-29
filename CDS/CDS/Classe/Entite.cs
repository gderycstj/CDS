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
        public int age { get; set; }
        protected string urlImage { get; set; }
        protected int direction { get; set; }//1 à 4
        public Position positionEntite { get; set; }
		
		 protected Entite(string listeC,string image) 
        {
            positionEntite = new Position();
            listeCMD=listeC;
            urlImage=image;
            age = 1;
        }

        //lire la liste CMD et agire
        public abstract bool action();
        //Vérification et action effectuer à chaque fin de tour
        public abstract bool finDetour();

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
        public virtual bool inBoundary()
        {
            return true;
        }


        /// <summary>
        /// Verifier si sur la cas du jouer, sur un effet.
        /// </summary>
        /// <returns></returns>
        public virtual bool verification()
        {
            return true;
        }
    }
}
