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
        public Figure GetFigureAt(int x, int y)
        {
            return GetFigureAt(new Position(x, y));
        }

        public void MoveFigures(Figure figure, Position position)
        {
            figure.SetPosition = position;
            Figure fig = GetFigureAt(position);
            if (fig != null)
                _figures.Remove(fig);
        }

        public bool IsOccupedBySameColor(Position position, Color color)
        {
            Figure fig = GetFigureAt(position);
            return GetFigureAt(position) != null && color == fig.Color;
        }

        public bool IsOccuped(Position position)
        {
            return GetFigureAt(position) != null;
        }

        ///////////////////////////////////////////////////////////////////
        public void AddFigure(Figure f)
        {
            _figures.Add(f);
        }
        public bool IsCheck(Position pos, Color color)
        {
            for(int i = 0; i < _figures.Count; i++)
            {
                Figure f = _figures[i];
                if (f.Color == color)
                    continue;

                List<Position> positions = _figures[i].GetAvailablePositions(this);
                for (int j = 0; j < positions.Count; j++)
                {
                    if(positions[j] == pos)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
