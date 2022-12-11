using System.Collections.Generic;

namespace ConsoleApplication5
{
    public static class GraphReader
    {
        private const char Separator = ';';
        private const char DestinationSeparator = '|';
        private const char SidesSeparator = '>';

        public static Graph Read(string fileName)
        {
            var input = ReadLine(fileName);
            return null;
        }

        private static string ReadLine(string fileName)
        {
            return System.IO.File.ReadAllLines(fileName)[0];
        }

        private static string[] ExtractNodesEdges(string input)
        {
            return input.Split(Separator);
        }

        /**
         * ex. A->B|C|D
         */
        private static ISet<Node> ExtractNodes(string nodeEdges)
        {
            var tokens = nodeEdges.Split(SidesSeparator);

            var source = tokens[0];

            var concatenatedDestinations = tokens[1];
            var destinations = ExtractDestinations(concatenatedDestinations);

            var nodes = new HashSet<Node>();
            return null;
        }

        private static string[] ExtractDestinations(string destination)
        {
            return destination.Split(DestinationSeparator);
        }
    }
}