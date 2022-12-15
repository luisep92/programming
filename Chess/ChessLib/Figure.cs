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
        internal Position SetPosition
        {
            set
            {
                _position = value;
                LimitPosition(_position);
            }
        }
        internal Color Color => _color;

        public Figure(int x, int y)
        {
            SetPosition = new Position(x, y);
        }

        public abstract FigureType GetFigureType();
        public abstract List<Position> GetAvailablePositions();
        
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

    }
}
