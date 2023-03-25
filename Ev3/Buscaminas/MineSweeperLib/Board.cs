using Luisbreria;
using MineSweeper2;

namespace MineSweeperLib
{
    public class Board : IBoard
    {
        private Cell[,] _cells;
        private int _bombs;
        private int _openCells;

        public int OpenCells
        {
            get { return _openCells; }
            set { _openCells = value; }
        }

        public Board(int width, int height, int bombs)
        {
            if (width <= 0)
                width = 1;
            if(height <= 0)
                height = 1;

            _cells = new Cell[width, height];
            _bombs = bombs;
            _openCells = 0;
        }

        public void DeleteFlagAt(int x, int y)
        {
            _cells[x, y].HasFlag = false;
        }

        List<Cell> FilterCellsAround(CellFilter filter, int x, int y)
        {
            List<Cell> list = new();
            int xMax = x + 1;
            int yMax = y + 1;

            for (int i = x - 1; i <= xMax; i++)
            {
                for (int j = y - 1; j <= yMax; j++)
                {
                    if (IsInside(i, j))
                    {
                        if (x == i && y == j)
                            continue;

                        Cell c = GetCellAt(i, j);
                        if (filter(c))
                            list.Add(c);
                    }
                }
            }
            return list;
        }

        public int GetBombsAround(int x, int y)
        {
            var list = FilterCellsAround((c) =>
            {
                if (c.Content == CellContent.BOMB)
                    return true;
                return false;
            }, x, y);
            return list.Count;
        }


        public int GetHeight()
        {
            return _cells.GetLength(1);
        }

        public int GetWidth()
        {
            return _cells.GetLength(0);
        }

        //Al hacer click en la primera celda
        public void Init(int x, int y)
        {
            FillWithCells();
            int maxBombs = GetWidth() * GetHeight() - 1;
            if (_bombs < maxBombs)
                _bombs = maxBombs;
            if(IsFirstCell())
                FillBombs(x, y, _bombs);

            Visit((c) =>
            {
                if (c.Content != CellContent.BOMB)
                    c.SetBombsAround(x, y, this);
            });
        }

        public void Visit(Visitor visitor)
        {
            for (int i = 0; i < GetWidth(); i++)
            {
                for (int j = 0; j < GetHeight(); j++)
                {
                    visitor(GetCellAt(i, j));
                }
            }
        }

        private bool IsFirstCell()
        {
            foreach (Cell c in _cells)
            {
                if (c.IsOpen)
                    return false;
            }
            return true;
        }

        private void FillBombs(int x, int y, int bombCount)
        {
            for (int i = 0; i < bombCount; i++)
            {
                int rx = Utils.RandomRangeInt(0, GetWidth());
                int ry = Utils.RandomRangeInt(0, GetHeight());

                if (_cells[rx, ry].Content == CellContent.BOMB || (rx == x && ry == y))
                {
                    i--;
                    continue;
                }
                _cells[rx, ry].SetContent(CellContent.BOMB);
            }
        }

        public bool IsBombAt(int x, int y)
        {
            if(IsInside(x, y))
                return _cells[x, y].Content == CellContent.BOMB;
            return false;
        }

        public bool IsFlagAt(int x, int y)
        {
            if(IsInside(x,y))
                return _cells[x, y].HasFlag;
            return false;
        }

        public bool IsOpenCell(int x, int y)
        {
            if(IsInside(x,y))
                return _cells[x, y].IsOpen;
            return false;
        }

        public void OpenCell(int x, int y)
        {
            if(IsInside(x,y))
                _cells[x, y].Open(this);
        }

        public void PutFlagAt(int x, int y)
        {
            _cells[x, y].HasFlag = true;
        }

        private void FillWithCells()
        {
            int x = GetWidth();
            int y = GetHeight();

            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    _cells[i, j] = new Cell();
                }
            }
        }

        public bool IsInside(int x, int y)
        {
            return (x >= 0 && x < GetWidth() && y >= 0 && y < GetHeight());
        }

        public Cell GetCellAt(int x, int y)
        {
            return _cells[x, y];
        }
    }
}
