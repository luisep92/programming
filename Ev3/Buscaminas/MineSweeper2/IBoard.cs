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
        /// <summary>
        /// Width of the board
        /// </summary>
        /// <returns>Returns the width of the board</returns>
        int GetWidth();
        /// <summary>
        /// Height of the board
        /// </summary>
        /// <returns>Returns the height of the board</returns>
        int GetHeight();
        /// <summary>
        /// Sets the content for each cell. It should be called after first click.
        /// </summary>
        /// <param name="position">Position of first open cell, so no bomb is put there</param>
        void Init(Vector2 position);
        /// <summary>
        /// Used to know if a cell contents a bomb
        /// </summary>
        /// <param name="position">Position of the cell</param>
        /// <returns>If a cell contains a bomb or not</returns>
        bool IsBombAt(Vector2 position);
        /// <summary>
        /// The number of bombs around a cell
        /// </summary>
        /// <param name="position">Position of the cell</param>
        /// <returns>Number of bombs around a cell</returns>
        int GetBombsAround(Vector2 position);
        /// <summary>
        /// Used to know if a cell is marked with a flag
        /// </summary>
        /// <param name="position">The position of the cell</param>
        /// <returns>If the cell is marked with a flag</returns>
        bool IsFlagAt(Vector2 position);
        /// <summary>
        /// Puts a flag in a specified cell
        /// </summary>
        /// <param name="position">The position of the cell</param>
        void PutFlagAt(Vector2 position);
        /// <summary>
        /// Removes the flag from a cell
        /// </summary>
        /// <param name="position">The position of the cell</param>
        void DeleteFlagAt(Vector2 position);
        /// <summary>
        /// Used to know if the usesr has won the game
        /// </summary>
        /// <returns>Returns if the user has won the game</returns>
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
        /// <summary>
        /// Get a cell from a position
        /// </summary>
        /// <param name="position">Position of the cell that we want to get</param>
        /// <returns>Return the cell object</returns>
        Cell GetCellAt(Vector2 position);
        /// <summary>
        /// Used to know if a cell is open
        /// </summary>
        /// <param name="position">The position of the cell</param>
        /// <returns>Returns if a cell is open or not</returns>
        bool IsOpenCell(Vector2 position);
        /// <summary>
        /// Used to open a cell
        /// </summary>
        /// <param name="position">The position of the cell</param>
        void OpenCell(Vector2 position);

        public bool IsInside(Vector2 position)
        {
            return position.x >= 0 && position.x < GetWidth() && position.y >= 0 && position.y < GetHeight();
        }
        /// <summary>
        /// Visits all the cells to do something
        /// </summary>
        /// <param name="visitor">Lambda that do something in each cell</param>
        void Visit(Visitor visitor);
        /// <summary>
        /// Used to get cells using a filter
        /// </summary>
        /// <param name="filter">Lambda that is a boolean with the condition of the cell that you want to filter</param>
        /// <returns>A list of the cells with the filter condition</returns>
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
