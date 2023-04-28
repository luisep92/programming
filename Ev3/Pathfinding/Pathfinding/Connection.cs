using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public struct Connection
    {
        public Node PreviousNode;
        public int Weight;

        public Connection(Node previousNode, int weight)
        {
            PreviousNode = previousNode;
            Weight = weight;
        }
    }
}
