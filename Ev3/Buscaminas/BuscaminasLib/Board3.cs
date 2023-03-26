using Luisbreria;

namespace BuscaminasLib
{
    /// <summary>
    /// Board with 3 lists of position (bombs, flags and open cells)
    /// </summary>
    public class Board3 : IBoard
    {
        #region NESTED CLASSES
        private struct Position
        {
            public int x;
            public int y;

            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        #endregion

        #region VARIABLES
        private int _width;
        private int _height;
        private int _bombCount;
        private List<Position> _bombs;
        private List<Position> _flags;
        private List<Position> _openCells;
        #endregion

        #region CONSTRUCTOR
        public Board3(int width, int height, int bombs) 
        {
            _width = width;
            _height = height;
            _bombCount = bombs;
            _bombs = new List<Position>();
            _flags = new List<Position>();
            _openCells = new List<Position>();
        }
        #endregion
        
        #region FUNCTIONS
        /// <summary>
        /// Checks if a list contains a position
        /// </summary>
        /// <param name="x">The X coordinate of the position</param>
        /// <param name="y">The Y coordinate of the position</param>
        /// <param name="list">The list you want to check</param>
        /// <returns>If a list contains a position</returns>
        private bool IsPositionIn(int x, int y, List<Position> list)
        {
            foreach(Position p in list)
            {
                if (p.x == x && p.y == y)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a position is inside the board
        /// </summary>
        /// <param name="x">The X coordinate of the position</param>
        /// <param name="y">The Y coordinate of the position</param>
        /// <returns>If a position is inside the board</returns>
        private bool IsInside(int x, int y)
        {
            return (x >= 0 && x < GetWidth() && y >= 0 && y < GetHeight());
        }

        /// <summary>
        /// Open surrounding cells of a position
        /// </summary>
        /// <param name="x">The X coordinate of the position</param>
        /// <param name="y">The Y coordinate of the position</param>
        private void OpenAroundCells(int x, int y)
        {
            for (int i = x - 1; i <= x + 1; i++)
            {
                for(int j = y - 1; j <= y + 1; j++)
                {
                    OpenCell(i, j);
                }
            }
        }

        /// <summary>
        /// Spread bombs over the board
        /// </summary>
        /// <param name="x">The X coordinate of the position</param>
        /// <param name="y">The Y coordinate of the position</param>
        /// <param name="bombs">The number of bombs that will be spread</param>
        private void FillBombs(int x, int y, int bombs)
        {
            for (int i = 0; i < bombs; i++)
            {
                int rx = Utils.RandomRangeInt(0, GetWidth());
                int ry = Utils.RandomRangeInt(0, GetHeight());
                if (IsBombAt(rx, ry) || (rx == x && ry == y))
                {
                    i--;
                    continue;
                }
                _bombs.Add(new Position(rx, ry));
            }
        }

        public int GetHeight()
        {
            return _height;
        }

        public int GetWidth()
        {
            return _width;
        }

        public void Init(int x, int y)
        {
            if (_openCells.Count > 0 || !IsInside(x, y))
                return;
            int maxBombs = GetWidth() * GetHeight() - 1;
            if (_bombCount > maxBombs)
                _bombCount = maxBombs;
            FillBombs(x, y, _bombCount);
        }

        public bool IsBombAt(int x, int y)
        {
            return IsPositionIn(x, y, _bombs);
        }

        public bool IsFlagAt(int x, int y)
        {
            return IsPositionIn(x, y, _flags);
        }

        public bool IsOpenCell(int x, int y)
        {
            return IsPositionIn(x, y, _openCells);
        }

        public void OpenCell(int x, int y)
        {
            if (!IsInside(x, y) || IsOpenCell(x, y))
                return;
            _openCells.Add(new Position(x, y));
            IBoard b = (IBoard)this;
            if (b.GetBombsAround(x, y) == 0)
                OpenAroundCells(x, y);
        }

        public void PutFlagAt(int x, int y)
        {
            if (!IsPositionIn(x, y, _flags) && IsInside(x,y))
                _flags.Add(new Position(x, y));
        }

        public void RemoveFlagAt(int x, int y)
        {
            _flags.Remove(new Position(x, y));
        }
        #endregion
    }
}
