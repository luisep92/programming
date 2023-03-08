using ChessLib;

namespace ChessTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Figure f = new King(2, 2, Color.WHITE);
            Figure f2 = new Pawn(3, 3, Color.WHITE);
            Figure f3 = new Pawn(1, 3, Color.BLACK);
            Figure f4 = new Pawn(2, 3, Color.BLACK);
            board.AddFigure(f);
            board.AddFigure(f2);
            board.AddFigure(f3);
            board.AddFigure(f4);
            List<Position> positions = f.GetAvailablePositions(board);
            foreach(Position position in positions)
            {
                Console.WriteLine(position.ToString());
            }
            Console.WriteLine(f.GetPosition + "a");
            board.MoveFigures(f, f.GetAvailablePositions(board)[1]);
            Console.WriteLine(f.GetPosition + "a");
            positions = f.GetAvailablePositions(board);
            foreach (Position position in positions)
            {
                Console.WriteLine(position.ToString());
            }
        }
    }
}