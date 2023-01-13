using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public interface IBoard
    {
        Figure GetFigureAt(Position position);
        Figure GetFigureAt(int x, int y);
        void MoveFigures(Figure figure, Position position);
        bool IsOccupedBySameColor(Position position, Color color);
        bool IsOccuped(Position position);
        bool IsCheck(Position position, Color color);

    }
}
