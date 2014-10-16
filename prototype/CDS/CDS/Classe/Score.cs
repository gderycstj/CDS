using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    class Score
    {
        private int score { get;set;}
        private string nom{get;set;}

        public Score()
        {
            score=0;
            nom="nompardefaut";
        }

        public Score(int points, string nJoueur)
        {
            score=points;
            nom=nJoueur;
        }

        public void modifierScore(int changement)
        {
            score += changement;
        }

        public bool envoyerScore(Joueur quiafaitlescore)
        {
            if(false)
            {
                //Erreur
                return false;
            }
            //succès
            return true;
        }

        public List<Score> obtenirScore(int quantiter, Joueur qui, string mode)
        {
            List<Score> liste= null;

            return liste;
        }

        //affiche les scores qui sont dans la liste
        public void afficherScore(List<Score> listedescore)
        {

        }

    }
}
