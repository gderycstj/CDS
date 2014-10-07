using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    class Objectif
    {
        string  typeObjectif { get;set;}
        int valeurObjectif { get;set;}

        Objectif()
        {
            typeObjectif="point";
            valeurObjectif=1;
        }

        Objectif(string typeO, int O)
        {
            typeObjectif = typeO;
            valeurObjectif = O;
        }

        //retourne si le joueur a complète l'objectif
        public bool finDeTour()
        {
            switch(typeObjectif)
            {
                case "point":
                    if(testObjectifPoint())
                        return true;
                    break;

                case "tour":

                    break;

            }


            return false;
        }

        //Vérifie si le nombre de point à d'épasser l'objectif
        bool testObjectifPoint()
        {
            return false;
        }

    }
}
