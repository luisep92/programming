using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Knight : Figure
    {
        public Knight(int x, int y, Color color) : base(x, y, color)
        {
        }
        public override FigureType GetFigureType()
        {
            return FigureType.KNIGHT;
        }
        public override List<Position> GetAvailablePositions(IBoard board)
        {
            List<Position> positions = new List<Position>();

            for(int i = 0; i < 8; i++)
            {
                Position pos = AvailablePosition(i);
                if (IsValidPosition(pos, board))
                    positions.Add(pos);
            }
            return positions;
        }

        Position AvailablePosition(int n)
        {
            int x, y;
            switch (n)
            {
                case 0:
                    x = this.GetPosition.x - 1;
                    y = this.GetPosition.y + 2;
                    return new Position(x, y);
                case 1:
                    x = this.GetPosition.x + 1;
                    y = this.GetPosition.y + 2;
                    return new Position(x, y);
                case 2:
                    x = this.GetPosition.x + 2;
                    y = this.GetPosition.y + 1;
                    return new Position(x, y);
                case 3:
                    x = this.GetPosition.x + 2;
                    y = this.GetPosition.y - 1;
                    return new Position(x, y);
                case 4:
                    x = this.GetPosition.x - 1;
                    y = this.GetPosition.y - 2;
                    return new Position(x, y);
                case 5:
                    x = this.GetPosition.x + 1;
                    y = this.GetPosition.y - 2;
                    return new Position(x, y);
                case 6:
                    x = this.GetPosition.x - 2;
                    y = this.GetPosition.y + 1;
                    return new Position(x, y);
                case 7:
                    x = this.GetPosition.x - 2;
                    y = this.GetPosition.y - 1;
                    return new Position(x, y);
            }
            return null;
        }
    }
}
