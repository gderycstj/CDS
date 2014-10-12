using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    public class Joueur
    {
        string nom {get;set;}
        private int idJoueur {get;set;}
        string pathImage { get;set;}
         public bool estConnecte;

        public Joueur()
        {
            nom="visiteur";
            idJoueur=-1;
            pathImage="..\\images\\pasdimage.png";
            estConnecte = false;
        }

        public Joueur(string nomJ, int id, string pathIm)
        {
            nom=nomJ;
            idJoueur=id;
            pathImage=pathIm;
            estConnecte = true;
        }

        public string getNom()
        {
            return nom;
        }
        /// <summary>
        /// Va mettre les infos du joueur connecté à la place de visiteur
        /// </summary>
        /// <param name="n">nom du joueur</param>
        /// <param name="id">id du joueur</param>
        /// <param name="pathIm">emplacement de l'image du joeur</param>
        /// <param name="connexion">vrai si est connecté</param>
        public void setJoueur(string n, int id, string pathIm,bool connexion)
        {
            nom = n;
            idJoueur = id;
            pathImage = pathIm;
            estConnecte = connexion;
        
        }

    }
}
