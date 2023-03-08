using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    internal class WoodCar : Car
    {
        public WoodCar() : base(Utils.RandomRange(0.0, 3.0), 15, GenerateDrivers(), "WoodCar")
        {
        }

        public override void Simulate(IRace race)
        {
            if (!IsEnabled() && Utils.Probability(60.0))
            {
                TurnsDisabled = 0;
                base.Simulate(race);
            }
            else
            {
                base.Simulate(race);
            }
        }

        static List<Driver> GenerateDrivers()
        {
            return new List<Driver> { new Human("Fuertaco"), new Animal("Castor") };
        }
    }
}
