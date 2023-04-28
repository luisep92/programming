namespace Pathfinding
{
    public class Edge
    {
        public Node NodeA { get; init; }
        public Node NodeB { get; init; }
        public int Weight { get; init; }

        public Edge(int weight, Node nodeA, Node nodeB)
        {
            Weight = weight;
            NodeA = nodeA;
            NodeB = nodeB;
        }
        public void teste()
        {

        }

    }
}
