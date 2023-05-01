using System.Xml.Linq;

namespace Pathfinding
{
    //Here is all the logic of the algorythm itself.
    public class Pathfinder
    {
        #region ATTRIBUTES
        List<Node> _nodes;
        Dictionary<Node, Way> _wayInfo = new();
        #endregion

        #region FUNCTIONS
        //Returns the current weight of a node, if there is no weight (at the start node, for example), returns 0.
        private int TotalWeight(Node n) => _wayInfo.ContainsKey(n) ? _wayInfo[n].Weight : 0;

        //Checks if there is a way to a node. If exist, compare to a new way and set the better one. If not, just set the new way to the node.
        private void SetWay(Node n, Way way)
        {
            if (_wayInfo.ContainsKey(n))
                _wayInfo[n] = Way.GetBest(_wayInfo[n], way);
            else
                _wayInfo[n] = way;
        }

        //Calculate all available ways from a node.
        private void SetWays(Node node)
        {
            var edges = from e in node.GetEdges
                        where _nodes.Contains(e.NodeA) &&
                              _nodes.Contains(e.NodeB)
                        select e;

            foreach (var e in edges)
            {
                Node dest = e.NodeA == node ? e.NodeB : e.NodeA;
                SetWay(dest, new Way(node, TotalWeight(node) + e.Weight));
            }

            _nodes.Remove(node);
        }


        //Returns the next node to be calculated.
        private Node NextNode()
        {
            var possibleWays = from e in _wayInfo
                               where _nodes.Contains(e.Key)
                               select e;

            return possibleWays.OrderByDescending((e) => e.Value).Reverse().First().Key;
        }

        //Returns a list with the nodes that represent the best way (first position -> start node, last position -> end node)
        public List<Node> GetPath(Graph graph, Node start, Node end)
        {
            List<Node> ret = new();
            Node currentNode = null;
            _nodes = graph.GetNodes();
            SetWays(start);

            while (currentNode != end)
            {
                currentNode = NextNode();
                SetWays(currentNode);
            }

            while (currentNode != start)
            {
                ret.Add(currentNode);
                currentNode = _wayInfo[currentNode].PreviousNode;
            }

            ret.Add(start);
            ret.Reverse();

            return ret;
        }
        #endregion
    }
}
