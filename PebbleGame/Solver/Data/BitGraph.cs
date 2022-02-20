using PGS.Data;

namespace PGS.PebbleGame.Solver.Data
{
    public class BitGraph
    {
        // represents for each node (defined by the index) the direct parents by a Bit-Pattern
        private readonly int[] _parentsGraph;

        // represents for each node (defined by the index) the children (transitiv, a node is also itselfs child)
        private readonly int[] _allChildrenGraph;

        // represents for each node (defined by the index) all paths to the tatgetnode (include start (node itself) and end (targetnode))
        private readonly int[][] _pathsToTargetGraph;

        public BitGraph(Graph<PebbledNode> graph, byte targetNodePosition)
        {
            int nodePosition = 0;
            var nodePositionDict = graph.Nodes.ToDictionary(node => node as PGS.Data.Node, node => nodePosition++);

            _parentsGraph = new int[nodePositionDict.Count];

            foreach (var (node, position) in nodePositionDict)
            {
                var activationPattern = 0;
                node.DirectParents().ForEach(parent => activationPattern |= 1 << nodePositionDict[parent]);
                _parentsGraph[position] = activationPattern;
            }

            // Find and remove nodes that do not lead (transitiv) to the target node.
            int nodesLeadingToTheTargetNode = FindParents(targetNodePosition);

            // Remove nodes that do not lead (transitiv) to the target node.
            for (int i = 0; i < _parentsGraph.Length; i++)
            {
                var leadsToTargetNode = (nodesLeadingToTheTargetNode & (1 << i)) != 0;
                if (leadsToTargetNode)
                    _parentsGraph[i] = _parentsGraph[i] & nodesLeadingToTheTargetNode;
                else
                    _parentsGraph[i] = Int32.MinValue;
            }

            _pathsToTargetGraph = new int[nodePositionDict.Count][];
            for (byte currentNodePosition = 0; currentNodePosition < _parentsGraph.Length; currentNodePosition++)
                if (_parentsGraph[currentNodePosition] >= 0)
                    _pathsToTargetGraph[currentNodePosition] = FindPathsFromTo(currentNodePosition, targetNodePosition);
                else
                    _pathsToTargetGraph[currentNodePosition] = Array.Empty<int>();

            _allChildrenGraph = new int[nodePositionDict.Count];
            for (byte currentNodePosition = 0; currentNodePosition < _parentsGraph.Length; currentNodePosition++)
                if (_parentsGraph[currentNodePosition] >= 0)
                    _allChildrenGraph[currentNodePosition] = _pathsToTargetGraph[currentNodePosition].Aggregate(0, (a, b) => a | b);
        }

        internal int[] PathsToTarget(byte position) => _pathsToTargetGraph[position];

        /// <summary>
        /// Find all Paths from a Node to a targetNode.
        /// A Path is representes as Bit-Pattern (Bits for the Nodes that are on the Path are set to 1)
        /// </summary>
        private int[] FindPathsFromTo(byte currentNodePosition, byte targetNodePosition)
        {
            if (currentNodePosition == targetNodePosition)
                return new int[] { 1 << targetNodePosition };

            List<byte> directChildren = new();
            var currentNodePattern = 1 << currentNodePosition;

            for (byte nodePosition = 0; nodePosition < _parentsGraph.Length; nodePosition++)
                if (_parentsGraph[nodePosition] > 0 && (_parentsGraph[nodePosition] & currentNodePattern) > 0)
                    directChildren.Add(nodePosition);

            return directChildren
                .SelectMany(c => FindPathsFromTo(c, targetNodePosition))
                .Select(c => c | currentNodePattern)
                .ToArray();
        }

        public int this[int nodePosition] => _parentsGraph[nodePosition];

        public int NodeCount => _parentsGraph.Length;

        public int ChildrenOf(byte position) => _allChildrenGraph[position];

        private int FindParents(byte nodePosition)
        {
            // is his own parent
            int parents = 1 << nodePosition;
            
            // add parents of this node (transitiv)
            for(byte i = 0; i < _parentsGraph.Length; i++)
                if((_parentsGraph[nodePosition] & (1 << i)) != 0)
                    parents |= FindParents(i);

            return parents;
        }
    }
}
