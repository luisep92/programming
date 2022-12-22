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
        void MoveFigures(Figure figure, Position position);
        bool IsValidPosition(Position position, Color color);

    }
}
