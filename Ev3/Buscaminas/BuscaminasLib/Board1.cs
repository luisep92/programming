using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasLib
{
    /// <summary>
    /// Board with a bidimensional array.
    /// </summary>
    public class Board1 : PrivateBoard
    {
        #region VARIABLES
        public Cell[,] _cells;
        #endregion

        #region CONSTRUCTOR
        public Board1(int width, int height, int bombs) :base(width, height, bombs)
        {
            _cells = new Cell[width, height];
            FillCells();
        }
        #endregion

        #region FUNCTIONS
        protected override Cell GetCellAt(int x, int y)
        {
            return _cells[x, y];
        }

        protected override ref Cell GetCellReference(int x, int y)
        {
            return ref _cells[x, y];
        }
        #endregion
    }
}
