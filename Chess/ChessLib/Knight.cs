using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    internal class Knight : Figure
    {
        public Knight(int x, int Y, FigureType type) : base(x, Y)
        {
        }
        public override FigureType GetFigureType()
        {
            return FigureType.KNIGHT;
        }
        public override List<Position> GetAvailablePositions()
        {
            return new List<Position>();
        }
    }
}
