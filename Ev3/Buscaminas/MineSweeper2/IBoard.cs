using Luisbreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper2
{

    public delegate void Visitor(Cell cell);
    public delegate bool CellFilter(Cell cell);
    public interface IBoard
    {
        int GetWidth();
        int GetHeight();
        void Init(Vector2 position);
        bool IsBombAt(Vector2 position);
        int GetBombsAround(Vector2 position);
        bool IsFlagAt(Vector2 position);
        void PutFlagAt(Vector2 position);
        void DeleteFlagAt(Vector2 position);
        bool HasWin()
        {
            for (int i = 0; i < GetWidth(); i++)
            {
                for (int j = 0; j < GetHeight(); j++)
                {
                    Cell c = GetCellAt(new Vector2(i, j));
                    if (c.Content != CellContent.BOMB && !c.IsOpen)
                        return false;
                }
            }
            return true;
        }
        Cell GetCellAt(Vector2 position);
        bool IsOpenCell(Vector2 position);
        void OpenCell(Vector2 position);
        void Visit(Visitor visitor);
        List<Cell> FilterCells(CellFilter filter)
        {
            List<Cell> list = new();

            for (int i = 0; i < GetWidth(); i++)
            {
                for (int j = 0; j < GetHeight(); j++)
                {
                    Cell c = GetCellAt(new Vector2(i, j));
                    if (filter(c))
                        list.Add(c);
                }
            }
            return list;
        }
    }
}
