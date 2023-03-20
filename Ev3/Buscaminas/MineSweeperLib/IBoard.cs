using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperLib
{
    public delegate bool CellFilter(Cell cell);
    public delegate void Visitor(Cell cell);
    public interface IBoard
    {
        int GetWidth();
        int GetHeight();
        void Init(int x, int y);
        bool IsBombAt(int x, int y);
        int GetBombsAround(int x, int y);
        bool IsFlagAt(int x, int y);
        void PutFlagAt(int x, int y);
        void DeleteFlagAt(int x, int y);
        bool HasWin()
        {
            for (int i = 0; i < GetWidth(); i++)
            {
                for (int j = 0; j < GetHeight(); j++)
                {
                    Cell c = GetCellAt(i, j);
                    if (c.Content != CellContent.BOMB && !c.IsOpen)
                        return false;
                }
            }
            return true;
        }
        Cell GetCellAt(int x, int y);
        bool IsOpenCell(int x, int y);
        void OpenCell(int x, int y);
        void Visit(Visitor visitor);
        List<Cell> FilterCells(CellFilter filter)
        {
            List<Cell> list = new();

            for(int i = 0; i < GetWidth(); i++)
            {
                for(int j = 0; j < GetHeight(); j++)
                {
                    Cell c = GetCellAt(i, j);
                    if (filter(c))
                        list.Add(c);
                }
            }
            return list;
        }
    }
}
