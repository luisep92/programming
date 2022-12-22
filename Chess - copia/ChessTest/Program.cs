using ChessLib;

namespace ChessTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Figure f = new Knight(1, 1, Color.WHITE);

            List<Position> positions = f.GetAvailablePositions(board.IsValidPosition);
            foreach(Position position in positions)
            {
                Console.WriteLine(position.ToString());
            }

        }
    }
}