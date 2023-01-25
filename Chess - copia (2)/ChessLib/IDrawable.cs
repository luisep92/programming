using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public interface IDrawable
    {
        public void RenderFigure(Figure figure);
    }
}
