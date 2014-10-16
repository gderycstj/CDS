using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    /// <summary>
    /// Classe qui va contenir toutes les variables globales qui seront utilisé dans le projet
    /// </summary>
    public static class Globale
    {
       public static Joueur j1;

        static Globale()
        {
            Joueur j0 = new Joueur();

            j1 = j0;
        }
    }
}
