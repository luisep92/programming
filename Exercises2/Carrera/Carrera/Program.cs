namespace Carrera
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Racer winner = null;
            List<Racer> list = Race.generateRacers();

            while(winner == null)
            {
                Race.MoveRacers(list);
                winner = Race.CheckWinner(list);
            }
            Console.WriteLine(winner.name + " es el ganador");
        }
    }
}