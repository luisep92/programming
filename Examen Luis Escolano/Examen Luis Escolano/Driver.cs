using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    internal abstract class Driver
    {
        string _name;

        public string Name { get { return _name; } }

        public Driver(string name)
        {

        }
        public abstract double GetVelocityExtra();
    }
}
