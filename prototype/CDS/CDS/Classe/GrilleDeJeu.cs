﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    class GrilleDeJeu
    {
        Case[][] grille{get;set;}
        public List<Position> ouetesvous{get;set;}

        public static int TailleGrille=11;

        public GrilleDeJeu()
        {
            for (int y = TailleGrille - 1; y <= 0; y--)
            {
                for (int x = TailleGrille - 1; x <= 0; x--)
                {
                    grille[x][y]= new Case(x,y);
                }
            }

            ouetesvous=null;
        }
        //parcour la liste de position d'ou se trouve les entiter pour les faire leurs actions/mouvement
        //retourne true si tout est correct
        public bool action()
        {

            return true;
        }

        //parcour la liste de position d'ou se trouve les entiter pour les faire les changement de fin de tour
        //retourne true si tout est correct
        public bool finDeTour()
        {

            return true;
        }

    }
}