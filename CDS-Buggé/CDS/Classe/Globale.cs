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
       public static string mode;
       public static BdService bdCDS;
       public static int tailleGrille = 11;
       public static Vie vie;

        static Globale()
        {
            Joueur j0 = new Joueur();
            BdService bd = new BdService();
            Vie vie1 = new Vie();

            vie = vie1;
            bdCDS = bd;
            j1 = j0;
        }
    }
}
