using System.Collections.Generic;

namespace ConsoleApplication5
{
    public class Node
    {
        private readonly string _label;
        private readonly IList<Node> _nodes;

        public Node(string label)
        {
            _label = label;
            _nodes = new List<Node>();
        }

        public Node(string label, IList<Node> nodes)
        {
            _label = label;
            _nodes = nodes;
        }

        public string Label() => _label;
        public IList<Node> Nodes() => _nodes;

        public void AddNeighbour(Node neighbour)
        {
            _nodes.Add(neighbour);
        }

        public void AddNeighbours(params Node[] neighbours)
        {
            foreach (var neighbour in neighbours)
            {
                _nodes.Add(neighbour);
            }
        }

        public bool IsNeighbour(Node potentialNeighbour)
        {
            return _nodes.Contains(potentialNeighbour);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Node other))
            {
                return false;
            }

            return other._label == _label;
        }
    }
}