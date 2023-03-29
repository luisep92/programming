using Luisbreria;

namespace BuscaminasLib
{
    /// <summary>
    /// Boards that use cells as information source should inherit from this, then just have to define how to access a cell.
    /// </summary>
    public abstract class PrivateBoard : IBoard
    {
        #region VARIABLES
        protected delegate bool CellFilter(Cell cell);
        protected delegate void Visitor(int x, int y);

        private int _width;
        private int _height;
        private int _bombs;
        private int _openCells;
        #endregion

        #region CONSTRUCTOR
        public PrivateBoard(int width, int height, int bombs)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentOutOfRangeException("Invalid width or height.");
            _width = width;
            _height = height;
            _bombs = bombs;
        }
        #endregion

        #region CLASS_FUNCTIONS
        /// <summary>
        /// Get a cell from a position
        /// </summary>
        /// <param name="x">The X coordinate of the position</param>
        /// <param name="y">The Y coordinate of the position</param>
        /// <returns>Cell of selected position</returns>
        protected abstract Cell GetCellAt(int x, int y);

        /// <summary>
        /// Check if a position is inside the board
        /// </summary>
        /// <param name="x">The X coordinate of the position</param>
        /// <param name="y">The Y coordinate of the position</param>
        /// <returns>If a position is inside the board</returns>
        protected bool IsInside(int x, int y)
        {
            return (x >= 0 && x < GetWidth() && y >= 0 && y < GetHeight());
        }
        
        /// <summary>
        /// Checks if there is any open cell
        /// </summary>
        /// <returns>If any cell is open</returns>
        protected bool IsFirstCell()
        {
            return _openCells == 0;
        }

        /// <summary>
        /// Go through all the cells of the board and do something
        /// </summary>
        /// <param name="visitor">A void that receives the position (x, y) of a cell. It can be a lambda/delegate</param>
        protected void Visit(Visitor visitor)
        {
            for (int i = 0; i < GetWidth(); i++)
            {
                for (int j = 0; j < GetHeight(); j++)
                {
                    visitor(i, j);
                }
            }
        }

        /// <summary>
        /// Get a list of filtered cells of the board.
        /// </summary>
        /// <param name="filter">A delegate bool/lambda that filters anything you want. Receives a cell as parameter. No need to use but it's cool :D</param>
        /// <returns>A list of filtered cells</returns>
        protected List<Cell> FilterCells(CellFilter filter)
        {
            List<Cell> list = new();

            for (int i = 0; i < GetWidth(); i++)
            {
                for (int j = 0; j < GetHeight(); j++)
                {
                    Cell c = GetCellAt(i, j);
                    if (filter(c))
                        list.Add(c);
                }
            }
            return list;
        }

        /// <summary>
        /// Spread bombs over the board. Receives a coordinate to prevent putting a bomb on it.
        /// </summary>
        /// <param name="x">The X coordinate of the position of the opened cell</param>
        /// <param name="y">The Y coordinate of the position of the opened cell</param>
        /// <param name="bombs">The number of bombs to spread</param>
        protected void FillBombs(int x, int y, int bombs)
        {
            for (int i = 0; i < bombs; i++)
            {
                int rx = Utils.RandomRangeInt(0, GetWidth());
                int ry = Utils.RandomRangeInt(0, GetHeight());
                Cell c = GetCellAt(rx, ry);
                if (c.Content == CellContent.BOMB || (rx == x && ry == y))
                {
                    i--;
                    continue;
                }
                c.Content = CellContent.BOMB;
            }
        }

        /// <summary>
        /// Fill the board with cells. This cells are default empty.
        /// </summary>
        protected void FillCells()
        {
            Visit((x, y) =>
            {
                GetCellReference(x, y) = new Cell();
            });
        }

        /// <summary>
        /// Get the reference of a cell. Used to fill the cells in the different boards that inherit from this one.
        /// </summary>
        /// <param name="x">The X coordinate of the position</param>
        /// <param name="y">The Y coordinate of the position</param>
        /// <returns>The reference of a cell in a position.</returns>
        protected abstract ref Cell GetCellReference(int x, int y);

        protected void OpenAroundCells(int x, int y)
        {
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    OpenCell(i, j);
                }
            }
        }
        #endregion

        #region INTERFACE_FUNCTIONS
        public int GetWidth()
        {
            return _width;
        }

        public int GetHeight()
        {
            return _height;
        }

        public void Init(int x, int y)
        {
            if (!IsFirstCell()|| !IsInside(x,y))
                return;
            int maxBombs = GetWidth() * GetHeight() - 1;
            if (_bombs > maxBombs)
                _bombs = maxBombs;
            FillBombs(x, y, _bombs);

            Visit((xx, yy) =>
            {
                IBoard b = (IBoard)this;
                Cell c = GetCellAt(xx, yy);
                if (c.Content != CellContent.BOMB)
                    c.BombsAround = b.GetBombsAround(xx, yy);
            });
        }

        public bool IsBombAt(int x, int y)
        {
            if (IsInside(x, y))
                return GetCellAt(x, y).Content == CellContent.BOMB;
            return false;
        }


        public bool IsFlagAt(int x, int y)
        {
            if (IsInside(x, y))
                return GetCellAt(x, y).HasFlag;
            return false;
        }

        public void PutFlagAt(int x, int y)
        {
            if (IsInside(x, y))
                GetCellAt(x, y).HasFlag = true;
        }

        public void RemoveFlagAt(int x, int y)
        {
            if (IsInside(x, y))
                GetCellAt(x, y).HasFlag = false;
        }

        public bool IsOpenCell(int x, int y)
        {
            if (IsInside(x, y))
                return GetCellAt(x, y).IsOpen;
            return false;
        }

        public void OpenCell(int x, int y)
        {
            if (!IsInside(x, y) || IsOpenCell(x, y) || IsFlagAt(x, y))
                return;
            GetCellAt(x, y).IsOpen = true;
            _openCells++;

            if(GetCellAt(x, y).BombsAround == 0 && !IsBombAt(x, y))
                OpenAroundCells(x, y);
        }
        #endregion
    } 
}
