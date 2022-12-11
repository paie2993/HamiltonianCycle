using System.Collections.Generic;

namespace ConsoleApplication5
{
    public static class DefinedGraphs
    {
        public static Graph FirstGraph() // has cycle
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            a.AddNeighbour(b);
            b.AddNeighbour(c);
            c.AddNeighbour(d);
            d.AddNeighbour(a);

            var nodes = new HashSet<Node> { a, b, c, d };
            return new Graph(nodes);
        }

        public static Graph SecondGraph() // has cycle, but contains a non cycle path
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            a.AddNeighbour(b);
            a.AddNeighbour(c);
            b.AddNeighbour(c);
            c.AddNeighbour(d);
            d.AddNeighbour(a);

            var nodes = new HashSet<Node> { a, b, c, d };
            return new Graph(nodes);
        }

        public static Graph ThirdGraph() // does not contain cycle
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            a.AddNeighbour(b);
            b.AddNeighbour(c);
            c.AddNeighbour(d);

            var nodes = new HashSet<Node> { a, b, c, d };
            return new Graph(nodes);
        }

        public static Graph FourthGraph()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");
            var e = new Node("E");

            a.AddNeighbours(c, e);
            b.AddNeighbours(a, c, d);
            c.AddNeighbours(d, e);
            d.AddNeighbour(a);
            e.AddNeighbours(b, d);

            var nodes = new HashSet<Node> { a, b, c, d, e };
            return new Graph(nodes);
        }
    }
}