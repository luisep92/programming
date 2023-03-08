using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Pawn : Figure
    {
        int Direction
        {
            get
            {
                if (this.Color == Color.WHITE)
                    return 1;
                return -1;
            }
        }
        public Pawn(int x, int y, Color color) : base(x, y, color)
        {
        }
        public override FigureType GetFigureType()
        {
            return FigureType.PAWN;
        }
        public override List<Position> GetAvailablePositions(IBoard board)
        {
            List<Position> positions = new List<Position>();
            Position front = new Position(this.GetPosition.x, this.GetPosition.y + Direction);
            if(!board.IsOccuped(front))
                positions.Add(front);

            Figure side = board.GetFigureAt(front.x - 1, front.y);
            if (side != null && side.Color != this.Color)
                positions.Add(side.GetPosition);

            side = board.GetFigureAt(front.x + 1, front.y);
            if (side != null && side.Color != this.Color)
                positions.Add(side.GetPosition);

            Position moveDouble = new Position(front.x, front.y + Direction);
            if (IsAtStart() && !board.IsOccuped(moveDouble) && !board.IsOccuped(front))
                positions.Add(moveDouble);

            return positions;
        }

        bool IsAtStart()
        {
            return (this.GetPosition.y == 2 && this.Color == Color.WHITE) ||
                   (this.GetPosition.y == 7 && this.Color == Color.BLACK);
        }
    }
}
