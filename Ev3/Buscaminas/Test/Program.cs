using MineSweeperLib;
namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board(4, 4, 15);
            b.Init(1, 1);
            Console.WriteLine(b.GetBombsAround(3,3));

        }
    }
}