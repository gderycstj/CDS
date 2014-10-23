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
            direction = 0;
            age = 0;
        }
		
        //lire la liste CMD et agire
        public abstract bool action();
        //détruire l'entité et faire les modification associé
        public abstract bool mort();
        //Vérification et action effectuer à chaque fin de tour
        public abstract bool finDetour();

    }
}
