using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    public class Score
    {
        public int score { get;set;}

        public Score()
        {
            score=0;
        }

        public Score(int points)
        {
            score=points;
        }

        public bool envoyerScore()
        {
            string req = "INSERT INTO Scores(idUtilisateur,idModeDeJeu,score)VALUES " +
                             "((SELECT idUtilisateur FROM Utilisateurs WHERE nom = '" + Globale.j1.getNom() + "')" +
                             ",(SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = '" + Globale.mode + "')" +
                             "," + score + ");COMMIT;";

            Globale.bdCDS.Insertion(req);
            return true;
        }
        /// <summary>
        /// Va obtenir les 10 meilleurs scores pour un mode
        /// </summary>
        /// <returns>Retourne une liste qui contient les 10 meilleurs scores</returns>
        public List<string>[] obtenirScore()
        {
            List<string>[] tabScore;
            int num = 0;
            string req = "SELECT nom,score FROM Scores s " +
                         "INNER JOIN Utilisateurs u ON s.idUtilisateur = u.idUtilisateur " +
                         "WHERE idModeDeJeu = (SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = '" + Globale.mode + "') " +
                          "ORDER BY score DESC LIMIT 10; ";

           
          tabScore =  Globale.bdCDS.selection(req, 2, ref num);
          return tabScore;
        }


    }
}
