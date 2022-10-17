namespace Carrera
{
    internal class Program
    {
        static void Main(string[] args)
        {
             for(int i = 0;i < 20; i++)
             {
                SimulateRace();
             }
        }

        public static void SimulateRace()
        {
            Racer winner = null;
            List<Racer> list = Race.generateRacers();

            while (winner == null)
            {
                Race.MoveRacers(list);
                winner = Race.CheckWinner(list);
            }
            Console.WriteLine(winner.name + " es el ganador");
        }
    }
    
}