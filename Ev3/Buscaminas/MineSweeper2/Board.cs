using Luisbreria;
using System;

namespace MineSweeper2
{
    public class Board : IBoard
    {
        List<Cell> _cells;
        private int _width;
        private int _heigth;
        private int _bombCount;
        private int _openCells;

        public int OpenCells
        {
            get { return _openCells; }
            set { _openCells = value; }
        }

        public Board(int width, int heigth, int bombCount)
        {
            _cells = new();
            _width = width;
            _heigth = heigth;
            _bombCount = bombCount;
            _openCells = 0;
            CreateCells();
        }

        private void CreateCells()
        {
            for(int i = 0; i < GetWidth(); i++)
            {
                for (int j = 0; j < GetHeight(); j++)
                {
                    _cells.Add(new Cell(j, i));
                }
            }
        }

        public void DeleteFlagAt(Vector2 position)
        {
            GetCellAt(position).HasFlag = false;
        }

        public Cell GetCellAt(Vector2 position)
        {
            return _cells[position.x + (position.y * _width)];
        }

        public int GetHeight()
        {
            return _heigth;
        }

        public int GetWidth()
        {
            return _width;
        }

        public void Init(Vector2 firstClick)
        {
            int maxBombs = GetWidth() * GetHeight() - 1;
            if (_bombCount < maxBombs)
                _bombCount = maxBombs;
            if (IsFirstCell())
                FillBombs(firstClick, _bombCount);

            Visit((c) =>
            {
                if (c.Content != CellContent.BOMB)
                    c.SetBombsAround(this);
            });
        }

        public bool IsBombAt(Vector2 position)
        {
            return GetCellAt(position).Content == CellContent.BOMB;
        }

        public bool IsFlagAt(Vector2 position)
        {
            return GetCellAt(position).HasFlag;
        }

        public bool IsOpenCell(Vector2 position)
        {
            return GetCellAt(position).IsOpen;
        }

        public void OpenCell(Vector2 position)
        {
            GetCellAt(position).Open(this);
        }

        public void PutFlagAt(Vector2 position)
        {
            GetCellAt(position).HasFlag = true;
        }

        public int GetBombsAround(Vector2 pos)
        {
            return GetCellAt(pos).GetBombsAround(this);
        }

        public void Visit(Visitor visitor)
        {
            foreach (Cell c in _cells)
            {
                visitor(c);
            }
        }

        private bool IsFirstCell()
        {
            return OpenCells > 0;
        }

        private void FillBombs(Vector2 firstClick, int bombCount)
        {
            int x = firstClick.x;
            int y = firstClick.y;

            for (int i = 0; i < bombCount; i++)
            {
                int rx = Utils.RandomRangeInt(0, GetWidth());
                int ry = Utils.RandomRangeInt(0, GetHeight());
                Cell c = GetCellAt(new Vector2(rx, ry));
                if (c.Content == CellContent.BOMB || (rx == x && ry == y))
                {
                    i--;
                    continue;
                }
                c.SetContent(CellContent.BOMB);
            }
        }
    }
}
