using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    internal class Board : IBoard
    {
        List<Figure> _figures;

        public Figure GetFigureAt(Position position)
        {
            return null;
            /*
            for(int i = 0; i < _figures.Count; i++)
            {
                if (_figures[i].GetPosition. == position)
            }*/
        }

        public void MoveFigures(Figure figure, Position position)
        {
            throw new NotImplementedException();
        }

        public bool IsValidPosition(Position pos)
        {
            Figure figureAtPos = GetFigureAt(pos);
            if (pos.x < 1 || pos.y < 1 || pos.x > 8 || pos.y > 8)
            {
                return false;
            }

            return true;
        }

        private bool IsOccupedBySameColor(Position position)////////////////////////////////////////
        {
            Figure fig = GetFigureAt(position);
            if (fig == null)
                return false;
            return GetFigureAt(position) != null;
        }
    }
}
