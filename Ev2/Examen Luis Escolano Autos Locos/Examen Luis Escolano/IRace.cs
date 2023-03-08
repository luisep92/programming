using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Luis_Escolano
{
    internal interface IRace
    {
        public void Start(double distance);
        public List<RaceObject> Simulate();
        public List<RaceObject> GetRacers();
        public void PrintObjects();
        public void VisitDrivers(Visitor visitor);
        int GetObjecCount();
        RaceObject GetObejctAt(int index);
    }
}
