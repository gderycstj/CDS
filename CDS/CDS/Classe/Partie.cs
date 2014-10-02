using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCDLS.Classe
{
    class Partie
    {
        GrilleDeJeu grille { get;set;}
        Score score { get;set;}
        Vie vie { get;set;}
        Objectif objectif { get;set;}
        int qtyObjetsMax;
        Objet[] objets {get;set;}

        Partie()
        {}

        Partie(Vie viedepart, Objectif objParti,int maxobjets, List<Objet> objetDepart)
        {
            vie=viedepart;
            objectif=objParti;
            objetDepart.CopyTo(objets);
        }

        bool finDeTour()
        {
            grille.finDeTour();
            vie.finDeTour();
            objectif.finDeTour();
            return true;
        }
    }
}
