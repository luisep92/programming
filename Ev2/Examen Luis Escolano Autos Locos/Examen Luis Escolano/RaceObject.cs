using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    public enum ObjectType { CAR, OBSTACLE }
    internal abstract class RaceObject
    {
        private string _name;
        private double _position;
        protected bool Enabled;
        protected int TurnsDisabled;

        public string Name
        {
            get { return _name; }
        }
        public double Position
        {
            get { return _position; }
            set{ _position = value; }
        }


        protected RaceObject(string name, double position)
        {
            _name = name;
            _position = position;
            Enabled = true;
            TurnsDisabled = 0;
        }

        public abstract ObjectType GetObjectType();
        public abstract bool IsEnabled();
        public abstract void Simulate(IRace race);
        public void Disable(int turns)
        {
            TurnsDisabled += turns;
        }
    }
}
