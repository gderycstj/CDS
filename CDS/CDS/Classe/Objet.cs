using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    class Objet:Entite
    {
        int valeur { get; set; }
        int rareté { get; set; }

		/// <summary>
        /// Constructeur d'un objet
        /// </summary>
        /// <param name="listeE">Liste d'effet qu'un objet peut avoir</param>
        /// <param name="listC">liste de commande de l'objet</param>
        /// <param name="url">url de l'image</param>
        /// <param name="Pvaleur">Puissance de l'objet</param>
        /// <param name="Prareté">Rareté de l'objet(selon sa puissance)</param>
        public Objet(string listeE,int Pvaleur,int Prareté,string listC,string url):base(listC,url)
        {
            listeEffet = new List<Effet>();
            valeur = Pvaleur;
            rareté = Prareté;
        }
		
        //lire la liste CMD et agire
        public override bool action()
        {
            // pas d'action
            return true;
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
