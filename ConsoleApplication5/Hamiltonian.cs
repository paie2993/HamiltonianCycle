using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public static class Hamiltonian
    {
        /**
         * Returns ONE of the hamiltonian cycles of the graph, or an empty list if no such cycle exists in the graph
         */
        public static IList<Node> FindCycle(Graph graph)
        {
            var nodes = graph.Nodes();

            var startingNode = nodes.First();
            var startingSolution = new List<Node> { startingNode };

            var solution = Find(startingNode, startingSolution, nodes);

            return HamiltonianConditions.IsHamiltonianCycle(solution, nodes) ? solution : BadSolution();
        }


        /**
         * If [node] has occured a second time in [solution], returns solution if it is a hamiltonian cycle or
         * an [BadSolution] if it is not a hamiltonian cycle
         * If [node] has not occured twice in [solution], collects the results of the Parallel search for solutions
         */
        private static IList<Node> Find(Node node, IList<Node> solution, ISet<Node> nodes)
        {
            if (NodeOccurredTwice(node, solution)) // this means we either have a solution or a dead end
            {
                return HamiltonianConditions.IsHamiltonianCycle(solution, nodes) ? solution : BadSolution();
            }

            var searches = ParallelSearch(node, solution, nodes); // otherwise, keep searching

            foreach (var solutionOfSearch in searches)
            {
                if (HamiltonianConditions.IsHamiltonianCycle(solutionOfSearch, nodes))
                {
                    return solutionOfSearch;
                }
            }

            return BadSolution();
        }

        /**
         * Launches the parallel search and waits for the search tasks to complete
         */
        private static IList<Node>[] ParallelSearch(Node node, IList<Node> solution, ISet<Node> nodes)
        {
            var tasks = LaunchSearch(node, solution, nodes);
            var completionTask = Task.WhenAll(tasks);

            return completionTask.Result;
        }

        /**
         * For each neighbour of the given [node] tries to find if adding [node] to the end of [solution] leads
         * to an hamilton cycle
         */
        private static IList<Task<IList<Node>>> LaunchSearch(Node node, IList<Node> solution, ISet<Node> nodes)
        {
            return node.Nodes()
                .Select(
                    neighbour =>
                    {
                        var augmentedSolution = AugmentedSolution(solution, neighbour);
                        return Task.Run(() => Find(neighbour, augmentedSolution, nodes));
                    })
                .ToList();
        }


        /**
         * Checks if the given [node] appears more than one in the [solution]
         */
        private static bool NodeOccurredTwice(Node node, ICollection<Node> solution)
        {
            var occurrenceCount = solution.Count(node.Equals);
            return occurrenceCount > 1;
        }

        /**
         * Returns a new instance of an [IList] adding the given [node] to the [solution]
         */
        private static IList<Node> AugmentedSolution(IEnumerable<Node> solution, Node node)
        {
            return new List<Node>(solution) { node };
        }

        /**
         * Returns an empty [IList]
         */
        private static IList<Node> BadSolution()
        {
            return new List<Node>();
        }
    }
}