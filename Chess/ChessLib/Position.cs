using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Position
    {
        public int x; 
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool operator == (Position pos1, Position pos2)
        {

        }
    }
}
