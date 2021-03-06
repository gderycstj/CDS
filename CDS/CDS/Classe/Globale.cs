﻿using System;
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
       public static int iNumeroDuNiveauAJouer;
       public static BdService bdCDS;
       public static int tailleGrille = 11;
       public static Vie vie;
       public static Score score;

       public static string titreMsg;
       public static string contenuMsg;
       public static string titrePMsg;

        static Globale()
        {
            Joueur j0 = new Joueur();
            BdService bd = new BdService();
            Vie vie1 = new Vie();
            Score s1 = new Score();

            vie = vie1;
            bdCDS = bd;
            j1 = j0;
            score = s1;
            iNumeroDuNiveauAJouer=0;

            titrePMsg="pop-up";
            titreMsg="Undefined";
            contenuMsg="No text have been initialised";
        }

    }
}
