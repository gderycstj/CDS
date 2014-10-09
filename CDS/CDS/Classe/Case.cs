using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    class Case
    {
        Position pos;
        List<Entite> listeHabitants;

        Case()
        {
            pos.set(0,0);
            listeHabitants=null;
        }

        public Case(int X, int Y)
        {
            pos.set(0,0);
            listeHabitants = null;
        }

        public Case(Position P)
        {
            pos.set(P);
            listeHabitants = null;
        }
    }
}
