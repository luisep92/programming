using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    internal class Obstacle : RaceObject
    {
        protected Obstacle(string name, double position) : base(name, position)
        {

        }
        public override ObjectType GetObjectType()
        {
            return ObjectType.OBSTACLE;
        }

        public override bool IsEnabled()
        {
            return Enabled;
        }

        public override void Simulate(IRace race)
        {
            
        }
    }
}
