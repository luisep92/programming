using ChessLib;

namespace ChessTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Position pos1 = new Position(2, 2);
            Position pos2 = new Position(2, 2);

            Console.WriteLine(pos1 == pos2);
        }
    }
}