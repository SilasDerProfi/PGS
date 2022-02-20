using PGS.PebbleGame.Solver.Data;
using System.Collections;
using System.ComponentModel;

namespace PGS.PebbleGame.Solver
{
    public class MinimizeStepsSolver : IPebbleGameSolver
    {
        private readonly BackgroundWorker _worker;
        private readonly byte _upperPebbleLimit;

        public MinimizeStepsSolver(BackgroundWorker worker, byte upperPebbleLimit)
        {
            _worker = worker;
            _upperPebbleLimit = upperPebbleLimit;
        }

        public PebbleStrategy Solve(BitGraph graph, byte targetNodePosition)
        {
            BitArray availablePattern = new((int)Math.Pow(2, graph.NodeCount), true);
            var leafs = new List<Data.TreeNode>() { new Data.TreeNode(0, ref availablePattern) };

            Data.TreeNode? targetTreeNode = null;
            double progressedPatterns = 0;
            while (targetTreeNode == null)
            {
                if (leafs.NotAny())
                    return new(); // not solvable

                if (++progressedPatterns % 1000 == 0)
                    _worker.ReportProgress((int)((progressedPatterns / availablePattern.Count) * 10000));

                // always continue searching where the fewest steps have been needed so far
                Data.TreeNode nextOrigin = leafs.Pop();

                (List<Data.TreeNode> childrenThatDontNeedMorePebbles, List<Data.TreeNode> childrenThatNeedOneMorePebble) = nextOrigin.GenerateChildren(graph, targetNodePosition, ref availablePattern);
                
                if(_upperPebbleLimit < graph.NodeCount)
                    leafs.AddRange(childrenThatDontNeedMorePebbles);

                if(childrenThatNeedOneMorePebble.Any() && childrenThatNeedOneMorePebble.First().MaxPebbleCount <= _upperPebbleLimit)
                    leafs.AddRange(childrenThatNeedOneMorePebble);

                if (_worker.CancellationPending)
                    return new();

                targetTreeNode ??= leafs.FirstOrDefault(n => n.HasPebbleOnPostion(targetNodePosition));
            }

            return targetTreeNode.GeneratePebbleStrategy();
        }
    }
}
