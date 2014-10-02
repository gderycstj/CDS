using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCDLS.Classe
{
    class Objet:Entite
    {
        //lire la liste CMD et agire
        bool action()
        {
            return true;
        }
        //détruire l'entité et faire les modification associé
        bool mort()
        {
            return true;
        }
        //Vérification et action effectuer à chaque fin de tour
        bool finDetour()
        {
            age++;
            return true;
        }

    }
}
