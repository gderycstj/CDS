﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    class Poursuivant:Entite
    {
        //lire la liste CMD et agire
        public override bool action()
        {
            return true;
        }
        //détruire l'entité et faire les modification associé
        public override bool mort()
        {
            return true;
        }
        //Vérification et action effectuer à chaque fin de tour
        public override bool finDetour()
        {
            age++;
            return true;
        }

    }
}