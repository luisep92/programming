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
        public bool IsCheck(Figure fig, Position pos)
        {
            Position aux = fig.GetPosition;
            fig.SetPosition = pos;
            foreach(Figure f in _figures)
            {
                if(f.Color != fig.Color && f.IsInList(pos, this))
                {
                    fig.SetPosition = aux;
                    return true;
                }
            }
            fig.SetPosition = aux;
            return false;
        }
    }
}
