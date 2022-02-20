using PGS.PebbleGame.Solver.Data;
using System.Collections;
using System.ComponentModel;

namespace PGS.PebbleGame.Solver
{
    internal class MinimizePebblesSolver : IPebbleGameSolver
    {
        private readonly BackgroundWorker _worker;

        public MinimizePebblesSolver(BackgroundWorker worker) => _worker = worker;

        public PebbleStrategy Solve(BitGraph graph, byte targetNodePosition)
        {
            BitArray availablePattern = new((int)Math.Pow(2, graph.NodeCount), true);

            // list of leafs that need 1, 2, ... n Pebbles 
            var neededPebblesForLeaf = Enumerable.Range(0, graph.NodeCount + 1).Select(i => new { pebbles = i, leafs = new List<Data.TreeNode>() }).ToList();
            Enumerable.First(neededPebblesForLeaf).leafs.Add(new Data.TreeNode(0, ref availablePattern));

            Data.TreeNode? targetTreeNode = null;
            double progressedPatterns = 0;
            while (targetTreeNode == null)
            {
                if (neededPebblesForLeaf.First().leafs.NotAny())
                    return new(); // not solvable

                if (++progressedPatterns % 1000 == 0)
                    _worker.ReportProgress((int)((progressedPatterns / availablePattern.Count)*10000));

                // always continue searching where the fewest pebbles have been needed so far
                Data.TreeNode nextOrigin = neededPebblesForLeaf.First().leafs.Pop();

                (List<Data.TreeNode> childrenThatDontNeedMorePebbles, List<Data.TreeNode> childrenThatNeedOneMorePebble) = nextOrigin.GenerateChildren(graph, targetNodePosition, ref availablePattern);
                neededPebblesForLeaf.First().leafs.AddRange(childrenThatDontNeedMorePebbles);
                neededPebblesForLeaf.Skip(1).First().leafs.AddRange(childrenThatNeedOneMorePebble);

                if (_worker.CancellationPending)
                    return new();

                if (neededPebblesForLeaf.First().leafs.NotAny())
                    neededPebblesForLeaf.RemoveAt(0);

                targetTreeNode ??= neededPebblesForLeaf.First().leafs.FirstOrDefault(n => n.HasPebbleOnPostion(targetNodePosition));
            }

            return targetTreeNode.GeneratePebbleStrategy();
        }
    }
}
