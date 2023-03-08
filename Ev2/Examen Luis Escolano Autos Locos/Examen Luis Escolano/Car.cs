using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    internal class Car : RaceObject
    {
        protected double Finetunning;
        protected double Speed;
        public List<Driver> Drivers;

        protected Car(double finetunning, double speed, List<Driver> drivers, string name) : base(name, 0)
        {
            Finetunning = finetunning;
            Speed = speed;
            Drivers = drivers;
        }

        public override ObjectType GetObjectType()
        {
            return ObjectType.CAR;
        }

        public override bool IsEnabled()
        {
            return Enabled;
        }

        public override void Simulate(IRace race)
        {
            if (TurnsDisabled > 0)
                Position += Speed + Finetunning;
            else
                TurnsDisabled -= 1;
        }

    }
}
