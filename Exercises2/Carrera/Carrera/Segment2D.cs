using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrera
{
    internal class Segment2D
    {
        Punt2D _puntA;
        Punt2D _puntB;

        public Segment2D()
        {
        }

        public Segment2D(Punt2D a, Punt2D b)
        {
            _puntA = a;
            _puntB = b;
        }
    }
}
