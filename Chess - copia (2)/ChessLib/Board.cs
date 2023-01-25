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

        public List<Figure> Figures
        {
            get { return _figures; }
        }


        public Board()
        {
            GenerateFigures();
        }

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
            Figure fig = GetFigureAt(position);
            figure.SetPosition = position;
            if (fig != null)
                _figures.Remove(fig);
            CrownPawn(figure);
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
        
        void CrownPawn(Figure f)
        {
            if(f.GetFigureType() == FigureType.PAWN)
            {
                if(f.GetPosition.y == 1 || f.GetPosition.y == 8)
                {
                    Figure newFigure = new Queen(f.GetPosition.x, f.GetPosition.y, f.Color);
                    _figures.Add(new Queen(f.GetPosition.x, f.GetPosition.y, f.Color));
                    _figures.Remove(f);
                }
            }
        }
        void GenerateFigures()
        {
            _figures.Add(new Tower(1,1,Color.WHITE));
            _figures.Add(new Tower(8,1,Color.WHITE));
            _figures.Add(new Tower(1,8,Color.BLACK));
            _figures.Add(new Tower(8,8,Color.BLACK));
            _figures.Add(new Knight(2,1,Color.WHITE));
            _figures.Add(new Knight(7,1,Color.WHITE));
            _figures.Add(new Knight(2,8,Color.BLACK));
            _figures.Add(new Knight(7,8,Color.BLACK));
            _figures.Add(new Bishop(3,1,Color.WHITE));
            _figures.Add(new Bishop(6,1,Color.WHITE));
            _figures.Add(new Bishop(3,8,Color.BLACK));
            _figures.Add(new Bishop(6,8,Color.BLACK));
            _figures.Add(new Queen(4,1,Color.WHITE));
            _figures.Add(new Queen(5,8,Color.BLACK));
            _figures.Add(new King(5,1,Color.WHITE));
            _figures.Add(new King(4,8,Color.BLACK));
            GeneratePawns();
        }
        void GeneratePawns()
        {
            for(int i = 1; i < 9; i++)
            {
                _figures.Add(new Pawn(i, 2, Color.WHITE));
            }
            for (int i = 1; i < 9; i++)
            {
                _figures.Add(new Pawn(i, 7, Color.BLACK));
            }
        }
    }
}
