using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    

    class Position
    {
        public int posX{get;set;}
        public int posY {get;set;}

        Position()
        {
            posX=0;
            posY=0;
        }

        Position(int X, int Y)
        {
            posX=X;
            posY=Y;
        }


        public void set(int X, int Y)
        {
            posX=X;
            posY=Y;
        }

        public void set(Position P)
        {
            posX = P.posX;
            posY = P.posY;
        }
    }
}
