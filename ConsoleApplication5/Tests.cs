using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApplication5
{
    public static class Tests
    {
        public static void RunTests()
        {
            Tests.TestsFirstEqualsLast();
            Tests.TestsFirstEqualsLastFalse();
            Tests.CorrectSequence();
            Tests.CorrectSequenceFalse();
            Tests.IsHamiltonianCycle();
            Tests.IsHamiltonianCycleFalseFirst();
            Tests.IsHamiltonianCycleFalseSecond();
            Tests.IsHamiltonianCycleFalseThird();
        }

        public static void TestsFirstEqualsLast()
        {
            var a = new Node("A");
            var b = new Node("B");

            var list = new List<Node> { a, b, a };
            Debug.Assert(HamiltonianConditions.FirstEqualsLast(list));
        }

        public static void TestsFirstEqualsLastFalse()
        {
            var a = new Node("A");
            var b = new Node("B");

            var list = new List<Node> { a, b, b };
            Debug.Assert(!HamiltonianConditions.FirstEqualsLast(list));
        }


        public static void CorrectSequence()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            a.AddNeighbour(b);
            b.AddNeighbour(c);
            c.AddNeighbour(d);
            d.AddNeighbour(a);

            var list = new List<Node> { a, b, c, d };
            Debug.Assert(HamiltonianConditions.CorrectSequence(list));
        }

        public static void CorrectSequenceFalse()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            a.AddNeighbour(b);
            b.AddNeighbour(c);
            c.AddNeighbour(d);
            d.AddNeighbour(a);

            var list = new List<Node> { a, b, c, d, c };
            Debug.Assert(!HamiltonianConditions.CorrectSequence(list));
        }

        public static void IsHamiltonianCycle()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            a.AddNeighbour(b);
            b.AddNeighbour(c);
            c.AddNeighbour(d);
            d.AddNeighbour(a);

            var nodes = new List<Node> { a, b, c, d };
            var solution = new List<Node> { a, b, c, d, a };

            Debug.Assert(HamiltonianConditions.IsHamiltonianCycle(solution, nodes));
        }

        public static void IsHamiltonianCycleFalseFirst()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            a.AddNeighbour(b);
            b.AddNeighbour(c);
            c.AddNeighbour(d);
            d.AddNeighbour(a);

            var nodes = new List<Node> { a, b, c, d };
            var solution = new List<Node> { a, b, c, d };

            Debug.Assert(!HamiltonianConditions.IsHamiltonianCycle(solution, nodes));
        }

        public static void IsHamiltonianCycleFalseSecond()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");
            var e = new Node("E");

            a.AddNeighbour(b);
            b.AddNeighbour(c);
            c.AddNeighbour(d);
            d.AddNeighbour(a);

            var nodes = new List<Node> { a, b, c, d };
            var solution = new List<Node> { a, b, c, d, e, a };

            Debug.Assert(!HamiltonianConditions.IsHamiltonianCycle(solution, nodes));
        }

        public static void IsHamiltonianCycleFalseThird()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");

            a.AddNeighbour(b);
            b.AddNeighbour(c);
            c.AddNeighbour(d);
            d.AddNeighbour(a);

            var nodes = new List<Node> { a, b, c, d };
            var solution = new List<Node> { a, b, c, b, d, a };

            Debug.Assert(!HamiltonianConditions.IsHamiltonianCycle(solution, nodes));
        }
    }
}