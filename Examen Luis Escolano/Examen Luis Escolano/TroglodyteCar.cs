using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    internal class TroglodyteCar : Car
    {

        public TroglodyteCar() : base(Utils.RandomRange(0.0, 3.0), 10, GenerateDrivers(), "TroglodyteCar")
        {

        }


        public override void Simulate(IRace race)
        {
            base.Simulate(race);

            if (IsEnabled() && Utils.Probability(30.0))
            {
                if (Utils.Probability(40.0))
                    Position += 20;
                else if (Utils.Probability(20))
                    TurnsDisabled += 1;
            }
        }

        static List<Driver> GenerateDrivers()
        {
            return new List<Driver> { new Human("Trog 1"), new Human("trog 2") };
        }
    }
}
