using BuscaminasLib;
namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBoard board = new Board2(20, 15, 40);
             
            Board2 b = (Board2)board;
            board.Init(5, 0);
            board.OpenCell(0,0);
            board.PutFlagAt(0, 4);
            board.PutFlagAt(2, 5);
            board.PutFlagAt(5, 5);
            board.DrawOnConsole();
        }
    }
}