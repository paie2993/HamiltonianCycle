using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication5
{
    public static class HamiltonianConditions
    {
        public static bool IsHamiltonianCycle(IList<Node> solution, ICollection<Node> nodes)
        {
            if (!FirstEqualsLast(solution))
            {
                return false;
            }

            if (!ContainsAll(nodes, solution) || !ContainsAll(solution, nodes))
            {
                return false;
            }

            var withoutLast = WithoutLast(solution);
            if (!UniqueNodes(withoutLast))
            {
                return false;
            }

            var isCorrect = CorrectSequence(solution);

            return isCorrect;
        }

        public static bool FirstEqualsLast(IList<Node> solution)
        {
            return solution.Count != 0 && Equals(solution.First(), solution.Last());
        }

        public static bool CorrectSequence(IList<Node> solution)
        {
            for (var index = 0; index < solution.Count - 1; index++)
            {
                var currentNode = solution.ElementAt(index);
                var nextNodeInSolution = solution.ElementAt(index + 1);

                if (!currentNode.IsNeighbour(nextNodeInSolution))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ContainsAll(ICollection<Node> baseCollection, ICollection<Node> containedCollection)
        {
            foreach (var node in containedCollection)
            {
                if (!baseCollection.Contains(node))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool UniqueNodes(ICollection<Node> collection)
        {
            var set = collection.ToHashSet();
            return set.Count == collection.Count;
        }

        private static IList<Node> WithoutLast(IList<Node> nodes)
        {
            var list = new List<Node>(nodes);
            return list.GetRange(0, list.Count - 1);
        }
    }
}