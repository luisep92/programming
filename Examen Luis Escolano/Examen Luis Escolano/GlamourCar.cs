using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    internal class GlamourCar : Car
    {
        public GlamourCar() : base(Utils.RandomRange(0.0, 3.0) , 20, GenerateDrivers(), "GlamourCar")
        {

        }
        static List<Driver> GenerateDrivers()
        {
            return new List<Driver> { new Human("Chica") };
        }
    }
}
