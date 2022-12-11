using System.Collections.Generic;

namespace ConsoleApplication5
{
    public class Graph
    {
        private readonly ISet<Node> _nodes;

        public Graph(ISet<Node> nodes)
        {
            _nodes = nodes;
        }

        public ISet<Node> Nodes() => _nodes;
    }
}