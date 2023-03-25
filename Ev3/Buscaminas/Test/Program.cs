using MineSweeper2;
using Luisbreria;
namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board(4, 4, 1);
            b.Init(new Vector2(0, 0));
            Console.WriteLine(b.GetCellAt(new Vector2(2,2)).Position);

        }
    }
}