using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    internal class Animal : Driver
    {
        public Animal(string name) : base(name)
        {

        }
        public override double GetVelocityExtra()
        {
            return 3;
        }
    }
}
