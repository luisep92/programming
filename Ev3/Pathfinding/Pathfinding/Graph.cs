namespace Pathfinding
{
    //Stores the information about the graph
    public class Graph
    {
        #region ATTRIBUTES
        private List<Node> _nodes = new();
        #endregion

        #region CONSTRUCTOR
        public Graph (List<Node> nodes)
        {
            _nodes = nodes;
        }
        #endregion

        #region FUNCTIONS
        //Returns a copy of the list of nodes
        public List<Node> GetNodes() => (from n in _nodes select n).ToList();
        #endregion
    }
}
