using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public enum FigureType { BISHOP, PAWN, TOWER, KNIGHT, QUEEN, KING }
    public enum Color { BLACK, WHITE }
    public abstract class Figure
    {
        private Position _position;
        private Color _color;
        
        public Position GetPosition => _position;
        internal Color Color => _color;
        internal Position SetPosition
        {
            set
            {
                _position = value;
                LimitPosition(_position);
            }
        }
        public Figure(int x, int y, Color color)
        {
            SetPosition = new Position(x, y);
            _color = color;
        }
        public abstract FigureType GetFigureType();
        public delegate bool Validator(Position position, Color color);
        public abstract List<Position> GetAvailablePositions(IBoard board);
        void LimitPosition(Position pos)
        {
            if (pos.x < 1)
                pos.x = 1;
            else if (pos.x > 8)
                pos.y = 8;
            if (pos.y < 1)
                pos.y = 1;
            else if (pos.y > 8)
                pos.y = 8;
        }

        public virtual bool IsValidPosition(Position nextPos, IBoard board)
        {
            Figure figureAtPos = board.GetFigureAt(nextPos);
            if (nextPos.x < 1 || nextPos.y < 1 || nextPos.x > 8 || nextPos.y > 8)
                return false;
            if (board.IsOccupedBySameColor(nextPos, this.Color))
                return false;

            return true;
        }
    }
}
