using System.Reflection.Metadata.Ecma335;

namespace Examen_2_Luis_Escolano
{
    public class Program
    {
        static void Main(string[] args)
        {
            Partido p = new Partido("Equipo A", "Equipo B");
            p.Start();
            p.Execute();
            
            Console.WriteLine(p.GetWinner().Name + " con " + p.GetWinner().Score + " puntos.");

            p.Visit((p) =>
            {
                Console.WriteLine(p);
            });

        }
    }
}