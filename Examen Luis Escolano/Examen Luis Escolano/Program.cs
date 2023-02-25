namespace Examen_Luis_Escolano
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Race race = new();
            race.Start(1000);
            List<RaceObject> Winners = new List<RaceObject>();
            while(Winners.Count == 0)
            {
                Winners = race.Simulate();
            }

            foreach(RaceObject r in Winners)
            {
                Console.WriteLine(r.Name);
            }
            /*
            race.VisitDrivers((v) =>
            {
                Console.WriteLine(v.Name);
            });*/

        }
    }
}