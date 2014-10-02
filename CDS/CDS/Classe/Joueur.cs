using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Joueur
    {
        string nom {get;set;}
        private int idJoueur {get;set;}
        string pathImage { get;set;}


        Joueur()
        {
            nom="Visiteur";
            idJoueur=-1;
            pathImage="..\\images\\pasdimage.png";
        }

        Joueur(string nomJ, int id, string pathIm)
        {
            nom=nomJ;
            idJoueur=id;
            pathImage=pathIm;

        }
    }
}
