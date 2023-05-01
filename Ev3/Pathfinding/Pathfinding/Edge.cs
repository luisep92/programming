namespace Pathfinding
{
    //Stores the information about the edges that connect nodes
    public class Edge
    {
        #region PROPERTIES
        public Node NodeA { get; init; }
        public Node NodeB { get; init; }
        public int Weight { get; init; }
        #endregion

        #region CONSTRUCTOR
        public Edge(Node nodeA, Node nodeB, int weight)
        {
            NodeA = nodeA;
            NodeB = nodeB;
            Weight = weight;

            NodeA.AddEdge(this);
            NodeB.AddEdge(this);
        }
        #endregion
    }
}
