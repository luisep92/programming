using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace Exercises
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            if (Exercises.isBetweenChars('a', 'z', 'b'))
                Console.WriteLine("T");
            else
                Console.WriteLine("F");
        }
    }
    
}