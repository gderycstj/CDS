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

        Score()
        {
            score=0;
            nom="nompardefaut";
        }

        Score(int points,string nJoueur)
        {
            score=points;
            nom=nJoueur;
        }

        void modifierScore(int changement)
        {
            score += changement;
        }

        bool envoyerScore(Joueur quiafaitlescore)
        {
            if(false)
            {
                //Erreur
                return false;
            }
            //succès
            return true;
        }

       /* List<Score> obtenirScore(int? quantiter, Joueur? qui, string? mode)
        {
            List<Score> liste= null;

            return liste;
        }*/

        //affiche les scores qui sont dans la liste
        void afficherScore(List <Score> listedescore)
        {

        }

    }
}
