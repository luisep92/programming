using Luisbreria;
using System.Xml.Serialization;

namespace MineSweeper2
{
    public enum CellContent { BOMB, EMPTY }
    public class Cell
    {
        public Vector2 Position;
        private CellContent _content;
        private int _bombsAround;
        public bool HasFlag;
        public bool IsOpen;

        public int BombsAround => _bombsAround;
        public CellContent Content => _content;

        public Cell(int x, int y)
        {
            Position = new Vector2(x, y);
            _content = CellContent.EMPTY;
        }

        public void Open(Board board)
        {
            if (HasFlag)
                return;

            IsOpen = true;
            board.OpenCells++;
            if (Content == CellContent.BOMB)
                Explode();
            else
            {
            }
        }

        public void SetBombsAround(IBoard board)
        {
            _bombsAround = GetBombsAround(board);
        }

        public int GetBombsAround(IBoard board)
        {
            int xMax = Position.x + 1;
            int yMax = Position.y + 1;
            int thisX = Position.x;
            int thisY = Position.y;
            int counter = 0;

            for (int i = Position.x - 1; i <= xMax; i++) 
            {
                for(int j = Position.y - 1; j <= yMax; j++)
                {
                    if (i == thisX && j == thisY)
                        continue;
                    if(board.GetCellAt(new Vector2(i, j)).Content == CellContent.BOMB)
                        counter++;
                }
            }
            return counter;
        }

        public void SetContent(CellContent c)
        {
            _content = c;
        }

        public int Distance(Cell c)
        {
            int disX = Math.Abs(c.Position.x - Position.x);
            int disY = Math.Abs(c.Position.y - Position.y);

            if (disX < disY)
                return disY;
            return disX;
        }

        private void Explode()
        {

        }
    }
}
