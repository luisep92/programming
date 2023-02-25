using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    internal class Human : Driver
    {
        public Human(string name) : base(name)
        {

        }
        public override double GetVelocityExtra()
        {
            return 0;
        }
    }
}
