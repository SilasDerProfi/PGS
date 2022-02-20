using System.ComponentModel;
using PGS.Data;
using PGS.PebbleGame.Solver;
using PGS.PebbleGame.Solver.Data;
using PGS.UI;
using static PGS.PebbleGame.Engine.WorkerStateData;

namespace PGS.PebbleGame
{
    internal class Engine
    {
        private Graph<PebbledNode>? _graph;
        private byte? _targetNodeIndex;
        private readonly GraphDrawboard _drawboard;
        private readonly BackgroundWorker _worker;
        private readonly PebbleGameDataViewer _pebbleCounter;

        public Engine(GraphDrawboard drawboard)
        {
            _drawboard = drawboard;
            _pebbleCounter = new PebbleGameDataViewer() { Location = new Point(10, 10), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            _worker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };

            _pebbleCounter.AddStrategyItem(new PebbleStrategyItem("Minimize pebbles, then minimize steps", "Minimize pebbles, steps", () => new MinimizePebblesStepsSolver(_worker)));
            _pebbleCounter.AddStrategyItem(new PebbleStrategyItem("Minimize pebbles only", "Minimize pebbles", () => new MinimizePebblesSolver(_worker)));
            _pebbleCounter.AddStrategyItem(new PebbleStrategyItem("trivial (minimize steps)", "trivial", () => new MinimizeStepsSolver(_worker, byte.MaxValue)));
            Enumerable.Range(2, 30).Select(
                n => new PebbleStrategyItem($"Minimize steps for up to {n} pebbles", $"Minimize steps ({n} pebbles)", () => new MinimizeStepsSolver(_worker, (byte)n)))
                .ToList().ForEach(i => _pebbleCounter.AddStrategyItem(i));

            _worker.ProgressChanged += ProgressChanged;
            _worker.DoWork += Run;
        }

        public event EventHandler<RunningStateChangedEventArgs>? RunningStateChanged;
        public bool IsStarted => _drawboard.Controls.Contains(_pebbleCounter);

        private void ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            var workerData = e.UserState as WorkerStateData;

            if (workerData?.State is WorkerState.StartedSelectionMode)
            {
                _pebbleCounter.AddStatus("Please select the target node with a left click");
                RunningStateChanged?.Invoke(this, new RunningStateChangedEventArgs(RunningStateChangedEventArgs.RunningState.SelectionMode));
            }
            else if (workerData?.State is WorkerState.StartedSolving)
            {
                _pebbleCounter.AddStatus("Started solving");
                RunningStateChanged?.Invoke(this, new RunningStateChangedEventArgs(RunningStateChangedEventArgs.RunningState.Running));
            }
            else if (workerData?.State is WorkerState.Finished)
                _pebbleCounter.AddStatus("Finished simulation");
            else if (workerData?.State is WorkerState.AddPebble)
                _pebbleCounter.AddPebble(workerData.Data as char? ?? '?');
            else if (workerData?.State is WorkerState.RemovePebble)
                _pebbleCounter.RemovePebble(workerData.Data as char? ?? '?');
            else if (e.ProgressPercentage > 0)
                _pebbleCounter.AddStatus($"Pebbled patterns: {e.ProgressPercentage / 100d:00.00} %", true);

            _drawboard.Repaint();
        }

        public void StartStop(Graph<PebbledNode>? graph = null)
        {
            _graph = graph;

            if (IsStarted || _graph == null)
            {
                Settings.SelectionMode = false;
                _drawboard.UserSelectedNode -= Drawboard_UserSelectedNode;
                _drawboard.Controls.Remove(_pebbleCounter);
                _graph?.Nodes?.ForEach(n => n.RemovePebble());
                _worker.CancelAsync();
                RunningStateChanged?.Invoke(this, new RunningStateChangedEventArgs(RunningStateChangedEventArgs.RunningState.NotRunning));
            }
            else
            {
                _targetNodeIndex = null;
                Settings.SelectionMode = true;
                _drawboard.UserSelectedNode += Drawboard_UserSelectedNode;

                _pebbleCounter.Reset();
                _pebbleCounter.Width = _drawboard.Width - 20;
                _drawboard.Controls.Add(_pebbleCounter);
                if (Settings.ScaleWhenPebblegameStarts)
                    _drawboard.Graph.Rescale(new Rectangle(Settings.NodeSize, Settings.NodeSize + _pebbleCounter.Height, _drawboard.Width - Settings.NodeSize * 2, _drawboard.Height - Settings.NodeSize * 2 - _pebbleCounter.Height));

                _pebbleCounter.BringToFront();
                _worker.RunWorkerAsync();
            }

            _drawboard.Repaint();
        }

        private void Drawboard_UserSelectedNode(object? sender, EventArgs e)
        {
            if (sender is PebbledNode node)
                _targetNodeIndex = (byte?)_graph?.Nodes?.IndexOf(node);
        }

        public class WorkerStateData
        {
            public WorkerStateData(WorkerState state, object? data = null)
            {
                State = state;
                Data = data;
            }
            public WorkerState State { get; private set; }
            public object? Data { get; private set; }
            public enum WorkerState
            {
                StartedSelectionMode,
                StartedSolving,
                AddPebble,
                RemovePebble,
                Finished
            }
        }

        public void Run(object? sender, DoWorkEventArgs e)
        {
            if (_graph is null)
                throw new NullReferenceException("Graph must be set to do the pebble game.");

            if (_graph.Nodes.Count < 1 || _graph.Nodes.Count > 31)
                throw new ArgumentException("Min 1 Node; Max 31 Nodes");

            _worker.ReportProgress(0, new WorkerStateData(WorkerState.StartedSelectionMode));
            while (!_targetNodeIndex.HasValue && Settings.SelectionMode)
                Thread.Sleep(100);

            if (_targetNodeIndex.HasValue && !_worker.CancellationPending)
            {
                _worker.ReportProgress(0, new WorkerStateData(WorkerState.StartedSolving));

                IPebbleGameSolver solver = new MinimizePebblesStepsSolver(_worker);
                _pebbleCounter.Invoke(new Action(() =>
                {
                    solver = _pebbleCounter.SelectedSolver ?? solver;
                    _pebbleCounter.StartedGame();
                }));

                var strategy = solver.Solve(new BitGraph(_graph, _targetNodeIndex.Value), _targetNodeIndex.Value);

                if(strategy.NotAny())
                    _drawboard.Invoke(new Action(() => _pebbleCounter.AddStatus("### The target node cannot be reached with the selected solver.")));
                else
                    ExecutePebbleStrategy(strategy, _graph);
            }

            if (_worker.CancellationPending)
            {
                e.Cancel = true;
                _graph.Nodes.ForEach(n => n.RemovePebble());
            }
            _worker.ReportProgress(100, new WorkerStateData(WorkerState.Finished));
        }

        private void ExecutePebbleStrategy(PebbleStrategy strategy, Graph<PebbledNode> _graph)
        {
            foreach (var step in strategy)
            {
                if (_worker.CancellationPending)
                    return;

                if (step.Operation == PebbleStrategy.Move.Action.Place)
                {
                    _graph.Nodes[step.AffectedPosition].AddPebble();
                    _worker.ReportProgress(50, new WorkerStateData(WorkerState.AddPebble, _graph.Nodes[step.AffectedPosition].Identifier));
                }
                else if (step.Operation == PebbleStrategy.Move.Action.Remove)
                {
                    _graph.Nodes[step.AffectedPosition].RemovePebble();
                    _worker.ReportProgress(50, new WorkerStateData(WorkerState.RemovePebble, _graph.Nodes[step.AffectedPosition].Identifier));
                }

                for (int i = 0; i < Settings.PebbleSolverStepDelay; i += 50)
                {
                    if (_worker.CancellationPending)
                        return;

                    Thread.Sleep(50);
                }
            }
        }
    }

    public class RunningStateChangedEventArgs : EventArgs
    {
        public RunningStateChangedEventArgs(RunningState state) => State = state;
        public RunningState State{ get;}

        public enum RunningState
        {
            NotRunning,
            SelectionMode,
            Running
        }
    }
}
