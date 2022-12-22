using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Board : IBoard
    {
        List<Figure> _figures = new List<Figure>();

        public Figure GetFigureAt(Position position)
        {
            for(int i = 0; i < _figures.Count; i++)
            {
                if(position == _figures[i].GetPosition)
                    return _figures[i];
            }
            return null;
        }

        public void MoveFigures(Figure figure, Position position)
        {
            throw new NotImplementedException();
        }

        public bool IsValidPosition(Position nextPos, Color color)
        {
            Figure figureAtPos = GetFigureAt(nextPos);
            if (nextPos.x < 1 || nextPos.y < 1 || nextPos.x > 8 || nextPos.y > 8)
                return false;
            if (IsOccupedBySameColor(nextPos, color))
                return false;

            return true;
        }

        private bool IsOccupedBySameColor(Position position, Color color)
        {
            Figure fig = GetFigureAt(position);
            return GetFigureAt(position) != null && color == fig.Color;
        }
    }
}
