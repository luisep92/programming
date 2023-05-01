using System.Data.Common;

namespace Pathfinding
{
    //Store information about the way to a node. Stores previous node and the accumulated weight to get to it.
    public struct Way : IComparable<Way>
    {
        #region ATTRIBUTES
        public int Weight;
        public Node PreviousNode;
        #endregion

        #region CONSTRUCTOR
        public Way(Node previous, int weight)
        {
            PreviousNode = previous;
            Weight = weight;
        }
        #endregion

        #region OPERATORS
        public static bool operator <(Way a, Way b) => (a.Weight < b.Weight);
        public static bool operator >(Way a, Way b) => (a.Weight > b.Weight);
        #endregion

        #region STATIC FUNCTIONS
        //Compares 2 ways and return the one with less weight
        public static Way GetBest(Way a, Way b) => a.Weight < b.Weight ? a : b;
        #endregion

        #region FUNCTIONS
        //Needed to put this to get an ordered dictionary
        public int CompareTo(Way w)
        {
            if (this.Weight < w.Weight) return -1;
            if(this.Weight > w.Weight) return 1;
            return 0;
        }
        #endregion
    }
}
