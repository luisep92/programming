using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public class Node
    {
        string _name;
        List<Edge> _edges = new();

        public void AddEdge(Edge edge)
        {
            if (edge != null)
                _edges.Add(edge);
        }

        public IEnumerable<Edge> Execute => from e in _edges
                                            select e;
        
        public override string ToString() => _name;
    }
}
