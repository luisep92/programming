using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class King : Figure
    {
        public King(int x, int y, Color color) : base(x, y, color)
        {
        }
        public override FigureType GetFigureType()
        {
            return FigureType.KING;
        }
        public override List<Position> GetAvailablePositions(IBoard board)
        {
            List<Position> positions = new List<Position>();

            for (int i = 0; i < 8; i++)
            {
                Position pos = AvailablePosition(i);
                if (IsValidPosition(pos, board) && !board.IsCheck(this,pos))
                    positions.Add(pos);
            }
            return positions;
        }
        Position AvailablePosition(int n)
        {
            int x = this.GetPosition.x;
            int y = this.GetPosition.y;
            switch (n)
            {
                case 0:
                    return new Position(x +1, y);
                case 1:
                    return new Position(x -1, y);
                case 2:
                    return new Position(x +1, y + 1);
                case 3:
                    return new Position(x -1, y + 1);
                case 4:
                    return new Position(x + 1, y - 1);
                case 5:
                    return new Position(x - 1, y - 1);
                case 6:
                    return new Position(x, y + 1);
                default:
                    return new Position(x, y - 1);
            }
        }
       
    }
}
