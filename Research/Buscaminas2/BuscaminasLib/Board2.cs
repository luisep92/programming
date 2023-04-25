namespace BuscaminasLib
{
    /// <summary>
    /// Board with an unique dimension array
    /// </summary>
    public class Board2 : PrivateBoard
    {
        #region VARIABLES
        public Cell[] _cells;
        #endregion

        #region CONSTRUCTOR
        public Board2(int width, int height, int bombs) : base(width, height, bombs)
        {
            _cells = new Cell[width * height];
            FillCells();
        }
        #endregion

        #region FUNCTIONS
        protected override Cell GetCellAt(int x, int y)
        {
            return _cells[x + (y * GetWidth())];
        }

        protected override ref Cell GetCellReference(int x, int y)
        {
            return ref _cells[x + (y * GetWidth())];
        }
        #endregion
    }
}
