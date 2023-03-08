using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public static Position operator +(Position pos1, Position pos2)
        {
            int x = pos1.x + pos2.x;
            int y = pos1.y + pos2.y;
            return new Position(x, y);
        }

        public static bool operator == (Position pos1, Position pos2)
        {
            if (pos1.x == pos2.x && pos1.y == pos2.y)
                return true;
            return false;
        }
        public static bool operator !=(Position pos1, Position pos2)
        {
            return !(pos1 == pos2);
        }
        public override string ToString()
        {
            return "(" + this.x + ", " + this.y + ")";
        }
    }
}
