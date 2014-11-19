using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    public class Objectif
    {
        public string  typeObjectif { get;set;}
        public int valeurObjectif { get;set;}

        public Objectif(string typeO, int O)
        {
            typeObjectif = typeO;
            valeurObjectif = O;
        }
 
    }
}
