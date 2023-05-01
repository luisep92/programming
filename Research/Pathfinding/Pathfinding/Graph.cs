using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public class Graph
    {
        private List<Node> _nodes = new();

        public Graph(List<Node> nodes)
        {
            _nodes = nodes;
        }

        public IEnumerable<Node> GetNodes(Predicate<Node> filter) => from n in _nodes
                                                                     where filter(n)
                                                                     select n;
    }
}
