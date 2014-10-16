using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
   public class Case
    {
       public Position pos;
        List<Entite> listeHabitants;

       public Case()
        {
            pos.set(0,0);
            listeHabitants=null;
        }

        public Case(int X, int Y)
        {
            Position p1 = new Position();
            pos = p1;
            pos.set(X,Y);
            listeHabitants = null;
        }

        public Case(Position P)
        {
            pos.set(P);
            listeHabitants = null;
        }
    }
}
