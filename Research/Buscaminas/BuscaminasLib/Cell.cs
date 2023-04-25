namespace BuscaminasLib
{
    public enum CellContent { BOMB, EMPTY }

    /// <summary>
    /// The information about a cell of the board
    /// </summary>
    public class Cell
    {
        #region VARIABLES
        public int BombsAround;
        public  CellContent Content;
        public bool IsOpen;
        public bool HasFlag;
        #endregion

        #region CONSTRUCTOR
        public Cell()
        {
            BombsAround = 0;
            Content = CellContent.EMPTY;
            IsOpen = false;
            HasFlag = false;
        }
        #endregion
    }
}
