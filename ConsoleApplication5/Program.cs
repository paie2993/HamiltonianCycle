using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApplication5
{
    internal class Program
    {
        public static void Main()
        {
            var graph = DefinedGraphs.FourthGraph();
            var cycle = SearchHamiltonianCycle(graph);
            PrintSolution(cycle);
        }

        private static IList<Node> SearchHamiltonianCycle(Graph graph)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var cycle = Hamiltonian.FindCycle(graph);
            stopwatch.Stop();

            PrintElapsedTime(stopwatch);

            return cycle;
        }

        private static void PrintElapsedTime(Stopwatch stopwatch)
        {
            var elapsed = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("The search took {0} ms", elapsed);
        }

        /**
         * A method for printing a solution of the search
         */
        private static void PrintSolution(IList<Node> solution)
        {
            if (solution.Count == 0)
            {
                Console.WriteLine("No cycle found");
            }
            else
            {
                foreach (var node in solution)
                {
                    Console.Write(node.Label());
                    Console.Write(" ");
                }
            }

            Console.WriteLine(" ");
        }
    }
}