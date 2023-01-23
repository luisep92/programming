namespace Carrera
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Punt2D puntoA = new Punt2D(1,1);
            Punt2D puntoB = new Punt2D(2, 2);

            Segment2D segment = new Segment2D(puntoA, puntoB);
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