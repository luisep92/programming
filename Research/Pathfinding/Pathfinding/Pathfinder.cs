using System.Linq;
using System.Runtime.CompilerServices;

namespace Pathfinding
{
    public class Pathfinder //: IPathfinder
    {
        Graph Graph;
        Dictionary<Node, Connection> connections = new();

        private Connection GetBestConnection(Connection a, Connection b) => a.Weight < b.Weight ? a : b;
        private void SetConnection(Node n, Connection c) => connections[n] = connections.ContainsKey(n) ? GetBestConnection(connections[n], c) : c;
        private void SetConnections(IEnumerable<Edge> edges, Node sender) => 
                            edges.ToList().ForEach((e) => 
                                SetConnection(e.NodeA == sender ? e.NodeB : e.NodeA, new Connection(sender, connections[sender].Weight + e.Weight)));
        

        //public List<Node> GetPath<Node>(Node origin, Node end) where Node : Pathfinding.Node
        //{
        //    Graph.GetNodes((n) => !(n == origin || n == end)).ToList().ForEach((n)=> n.Execute())

        //}        
    }
}
