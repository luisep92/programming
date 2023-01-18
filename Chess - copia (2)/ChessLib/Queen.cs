using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Queen : Figure
    {
        public Queen(int x, int y, Color color) : base(x, y, color)
        {
        }
        public override FigureType GetFigureType()
        {
            return FigureType.QUEEN;
        }
        public override List<Position> GetAvailablePositions(IBoard board)
        {
            List<Position> positions = new List<Position>();

            for (int i = 0; i < 8; i++)
            {
                Position pos = new Position(this.GetPosition.x, this.GetPosition.y);
                while (IsValidPosition(pos + Direction(i), board))
                {
                    pos = pos + Direction(i);
                    positions.Add(pos);
                    if (board.IsOccuped(pos))
                        break;
                }
            }
            return positions;
        }


        private Position Direction(int n)
        {
            switch (n)
            {
                case 0:
                    return new Position(1, 1);
                case 1:
                    return new Position(1, -1);
                case 2:
                    return new Position(-1, 1);
                case 3:
                    return new Position(-1, -1);
                case 4:
                    return new Position(0, 1);
                case 5:
                    return new Position(0, -1);
                case 6:
                    return new Position(1, 0);
                default:
                    return new Position(-1, 0);
            }
        }
    }
}
