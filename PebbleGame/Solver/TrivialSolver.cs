using System.ComponentModel;

namespace PGS.PebbleGame.Solver
{
    internal class TrivialSolver : MinimizePebblesStepsSolver
    {
        public TrivialSolver(BackgroundWorker worker) : base(worker, byte.MaxValue) { }
    }
}
