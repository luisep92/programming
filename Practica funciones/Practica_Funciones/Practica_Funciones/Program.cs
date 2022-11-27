namespace Practica_Funciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Functions.QuitaArroba("@@aa@@@@", true, true));
            Console.WriteLine(Functions.QuitaArroba("@@aa@@@@", true, false));
            Console.WriteLine(Functions.QuitaArroba("@@aa@@@@", false, true));
            Console.WriteLine(Functions.QuitaArroba("@@aa@@@@", false, false));
            Console.WriteLine(Functions.QuitaArroba("@@@@@@", true, true));
            Console.WriteLine(Functions.QuitaArroba("@a", true, true));
            Console.WriteLine(Functions.QuitaArroba("", true, true));
        }
    }
}