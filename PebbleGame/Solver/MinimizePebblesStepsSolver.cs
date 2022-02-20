using PGS.PebbleGame.Solver.Data;
using System.ComponentModel;

namespace PGS.PebbleGame.Solver
{
    internal class MinimizePebblesStepsSolver : IPebbleGameSolver
    {
        private readonly BackgroundWorker _worker;
        private byte? _upperPebbleLimit;

        public MinimizePebblesStepsSolver(BackgroundWorker worker, byte? upperPebbleLimit = null)
        {
            _worker = worker;
            _upperPebbleLimit = upperPebbleLimit;
        }

        public PebbleStrategy Solve(BitGraph graph, byte targetNodePosition)
        {
            _upperPebbleLimit ??= new MinimizePebblesSolver(_worker).Solve(graph, targetNodePosition).MaxPebbles;
            return new MinimizeStepsSolver(_worker, _upperPebbleLimit.Value).Solve(graph, targetNodePosition);
        }
    }
}
