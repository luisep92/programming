using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperLib
{
    public enum CellContent { EMPTY, BOMB }

    public class Cell
    {
        private CellContent _content;
        private int _bombsAround;
        public bool IsOpen;
        public bool HasFlag;

        public CellContent Content => _content;
        public int BombsAround => _bombsAround;

        public Cell()
        {
            _content = CellContent.EMPTY;
            HasFlag = false;
            IsOpen = false;
        }

        public Cell(CellContent content)
        {
            _content = content;
            HasFlag = false;
        }

        public void SetContent(CellContent c)
        {
            _content = c;
        }

        public void Open(Board board)
        {
            if (HasFlag)
                return;

            IsOpen = true;
            board.OpenCells++;
            if(Content == CellContent.BOMB)
            {
                Explode();
            }
            else
            {

            }
        }

        public void SetBombsAround(int x, int y, IBoard board)
        {
            _bombsAround = board.GetBombsAround(x, y);
        }

        private void Explode()
        {

        }
    }
}
