using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    internal interface IPathfinder
    {
        List<T> GetPath<T>(T origin, T end);
    }
}
