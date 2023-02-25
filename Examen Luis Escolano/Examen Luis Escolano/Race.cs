using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    internal delegate void Visitor(Driver d);
    internal class Race : IRace
    {
        private double _distance;
        public List<RaceObject> RaceObjects = new List<RaceObject>();
        
        
        public RaceObject GetObejctAt(int index)
        {
            if (index >= 0 && index < RaceObjects.Count)
                return RaceObjects[index];
            return null;
        }

        public int GetObjecCount()
        {
            return RaceObjects.Count;
        }

        public void PrintObjects()
        {
            foreach(RaceObject obj in RaceObjects)
            {
                Console.WriteLine(obj.Name);
            }
        }

        public List<RaceObject> Simulate()
        {
            List<RaceObject> list = new List<RaceObject>();
            RaceObject? disabledBomb = null;

            foreach(RaceObject r in RaceObjects)
            {
                if (r.Name == "Bomb" && !r.IsEnabled())
                    disabledBomb = r;
                if (!r.IsEnabled()) { }
                    r.Simulate(this);

                if (r.Position > _distance)
                    list.Add(r);
            }
            if(disabledBomb != null)
                RaceObjects.Remove(disabledBomb);
            return list;
        }

        public void Start(double distance)
        {
            _distance = distance;
            RaceObjects.Add(new PiereCar());
            RaceObjects.Add(new TroglodyteCar());
            RaceObjects.Add(new GlamourCar());
            RaceObjects.Add(new WoodCar());

            int obs = (int)Utils.RandomRange(2, 5);
            for(int i = 0; i < obs; i++)
            {
                RaceObjects.Add(SelectObstacle((int)Utils.RandomRange(0, 3.0)));
            }

        }

        public List<RaceObject> GetRacers()
        {
            return RaceObjects;
        }

        public void VisitDrivers(Visitor visitor)
        {
            foreach(RaceObject r in RaceObjects)
            {
                if(r.GetObjectType() == ObjectType.CAR)
                {
                    Car c = (Car)r;
                    foreach (Driver d in (c.Drivers))
                    {
                        visitor(d);
                    }
                }
            }
        }

        Obstacle SelectObstacle(int n)
        {
            double position = Utils.RandomRange(0.0, _distance);
            if (n == 0)
                return new Rock(position);
            else if (n == 1)
                return new Charco(position);
            else
                return new Bomb((int)Utils.RandomRange(0.0, 5), position);
        }
    }
}
