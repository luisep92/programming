using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    internal class PiereCar : Car
    {
        public PiereCar() : base(Utils.RandomRange(0.0, 3.0), 18, GenerateDrivers(), "PiereCar")
        {

        }

        static List<Driver> GenerateDrivers()
        {
            return new List<Driver> { new Human("No da una"), new Animal("Patán") };
        }


        public override void Simulate(IRace race)
        {
            if (Utils.Probability(20))
            {
                Car? car = GetNextCar(race);
                if(car != null)
                {
                    if (Utils.Probability(30.0))
                    {
                        car.Disable(1);
                    }
                    else
                    {
                        if (Drivers.Count == 2)
                            Drivers.RemoveAt(1); //Siempre es el perro eso segundo
                    }
                }
            }
        }

        Car? GetNextCar(IRace race)
        {
            Car car = GetSlowestCar(race);

            if (car == this)
                return null;

            foreach (RaceObject c in race.GetRacers())
            {
                if(c.GetObjectType() == ObjectType.CAR)
                {
                    Car ca = (Car)c;
                    if (ca.Position < this.Position && ca.Position > car.Position)
                    {
                        car = ca;
                    }
                }
                
            }
            return null;
        }

        Car GetSlowestCar(IRace race)
        {
            List<RaceObject> cars = race.GetRacers();
            Car car = null;

            foreach(RaceObject raceObject in cars)
            {
                if (raceObject.GetObjectType() == ObjectType.CAR)
                {
                    if (car == null)
                        car = (Car)raceObject;
                    else if (car.Position < raceObject.Position)
                        car = (Car)raceObject;
                }
            }
            return car;
        }
    }
}
