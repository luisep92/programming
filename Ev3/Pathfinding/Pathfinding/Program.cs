namespace Pathfinding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region CREATE GRAPH INFORMATION
            List<Node> nodes = new List<Node>()
            {
                new Node(){Name = "A"}, //0
                new Node(){Name = "B"}, //1
                new Node(){Name = "C"}, //2
                new Node(){Name = "D"}, //3
                new Node(){Name = "E"}, //4
                new Node(){Name = "F"}, //5
                new Node(){Name = "G"}  //6
            };
            Edge ab = new(nodes[0], nodes[1], 1);
            Edge bf = new(nodes[1], nodes[5], 2);
            Edge bd = new(nodes[1], nodes[3], 50);
            Edge ac = new(nodes[0], nodes[2], 50);
            Edge cd = new(nodes[2], nodes[3], 51);
            Edge ce = new(nodes[2], nodes[4], 50);
            Edge eg = new(nodes[4], nodes[6], 10);
            Edge fg = new(nodes[5], nodes[6], 1);

            Graph graph = new(nodes);
            #endregion

            Pathfinder pf = new();

            var list = pf.GetPath(graph, nodes[4], nodes[1]);
            string path = "";
            foreach(var n in list)
            {
                path = n + " -> " + path;
            }

            Console.WriteLine(path);
        }
    }
}