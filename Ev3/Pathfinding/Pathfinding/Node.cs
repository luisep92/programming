namespace Pathfinding
{
    //Stores the information about the nodes
    public class Node
    {
        #region ATTRIBUTES
        private List<Edge> _edges = new();
        #endregion
        #region PROPERTIES
        public string? Name { get; init; }
        #endregion

        #region FUNCTIONS
        //Returns a copy of the list of edges, as IEnumerable
        public IEnumerable<Edge> GetEdges => from e in _edges select e;

        //Adds an edge to the edge list
        public void AddEdge(Edge e) => _edges.Add(e);

        public override string ToString() => Name == null ? "_" : Name;
        #endregion
    }
}
