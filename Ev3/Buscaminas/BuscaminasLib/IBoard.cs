namespace BuscaminasLib
{
    public interface IBoard
    {
        /// <summary>
        /// The width of the board
        /// </summary>
        /// <returns>The width of the board</returns>
        public int GetWidth();

        /// <summary>
        /// The height of the board
        /// </summary>
        /// <returns>The height of the board</returns>
        public int GetHeight();

        /// <summary>
        /// Spread the bombs on the board after the first open cell. Never put a bomb into the cell that you have clicked.
        /// Recieves the first open cell position as parameter.
        /// </summary>
        /// <param name="x">The X coordinate of your selected cell</param>
        /// <param name="y">The y coordinate of your selected cell</param>
        public void Init(int x, int y);

        /// <summary>
        /// Tells if a specified cell contains a bomb.
        /// </summary>
        /// <param name="x">The X coordinate of your selected cell</param>
        /// <param name="y">The y coordinate of your selected cell</param>
        /// <returns>If a cell contains a bomb</returns>
        public bool IsBombAt(int x, int y);

        /// <summary>
        /// The number of bombs around a cell
        /// </summary>
        /// <param name="x">The X coordinate of your selected cell</param>
        /// <param name="y">The y coordinate of your selected cell</param>
        /// <returns>The number of bombs around a cell</returns>
        public int GetBombsAround(int x, int y)
        {
            int xMax = x + 1;
            int yMax = y + 1;
            int counter = 0;

            for (int i = x - 1; i <= xMax; i++)
            {
                for (int j = y - 1; j <= yMax; j++)
                {
                    if (i == x && j == y)
                        continue;
                    if (IsBombAt(i, j))
                        counter++;
                }
            }
            return counter;
        }

        /// <summary>
        /// Tells if a cell is marked with a flag
        /// </summary>
        /// <param name="x">The X coordinate of your selected cell</param>
        /// <param name="y">The y coordinate of your selected cell</param>
        /// <returns>If a cell is marked with a flag</returns>
        public bool IsFlagAt(int x, int y);

        /// <summary>
        /// Put a flag on a cell
        /// </summary>
        /// <param name="x">The X coordinate of your selected cell</param>
        /// <param name="y">The y coordinate of your selected cell</param>
        public void PutFlagAt(int x, int y);

        /// <summary>
        /// Removes a flag of a cell
        /// </summary>
        /// <param name="x">The X coordinate of your selected cell</param>
        /// <param name="y">The y coordinate of your selected cell</param>
        public void RemoveFlagAt(int x, int y);

        /// <summary>
        /// Tells if the player won the game
        /// </summary>
        /// <returns>If the player won the game</returns>
        public bool HasWin()
        {
            for (int i = 0; i < GetWidth(); i++)
            {
                for (int j = 0; j < GetHeight(); j++)
                {
                    if (IsBombAt(i, j) && !IsOpenCell(i, j))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Tells if a cell is open
        /// </summary>
        /// <param name="x">The X coordinate of your selected cell</param>
        /// <param name="y">The y coordinate of your selected cell</param>
        /// <returns>If a cell is open</returns>
        public bool IsOpenCell(int x, int y);

        /// <summary>
        /// Opens a cell. If the cell is not a bomb and there is no bombs around it, opens its surrounding cells.
        /// </summary>
        /// <param name="x">The X coordinate of your selected cell</param>
        /// <param name="y">The y coordinate of your selected cell</param>
        public void OpenCell(int x, int y);

        /// <summary>
        /// Draws the board on console
        /// </summary>
        public void DrawOnConsole()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            for(int i = 0; i < GetWidth(); i++)
            {
                for(int j = 0; j < GetHeight(); j++)
                {
                    if (IsFlagAt(i, j))
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write("P");
                    }
                    else if (IsBombAt(i, j))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("O");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        if (IsOpenCell(i, j))
                        {
                            int bombs = GetBombsAround(i, j);
                            if (bombs > 0)
                                Console.Write(bombs);
                            else
                                Console.Write(' ');
                        }
                        else
                            Console.Write("X");
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
