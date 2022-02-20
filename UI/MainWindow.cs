using System.Text;
using PGS.IO;
using PGS.PebbleGame;

namespace PGS.UI
{
    public partial class MainWindow : Form
    {
        private readonly Engine _pebbleSolver;

        public MainWindow()
        {
            InitializeComponent();
            _pebbleSolver = new Engine(drawboard);
            _pebbleSolver.RunningStateChanged += PebbleSovlerStartedOrStopped;
        }

        private void Drawboard_ZoomvalueChanged(object sender, EventArgs e) => zoomBar.Value = Settings.NodeSize;

        private void ZoomBar_ValueChanged(object sender, EventArgs e)
        {
            if (Settings.NodeSize != zoomBar.TrackBar.Value)
                drawboard.ResizeTo(zoomBar.TrackBar.Value);
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            new SettingsWindow().ShowDialog();
            drawboard.Repaint();
        }

        private void SaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new()
            {
                Filter = "graph files (*.graph)|*.graph|All files (*.*)|*.*",
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                GraphIOManager.Save(dialog.FileName, drawboard.Graph);
        }

        private void Clear_Click(object sender, EventArgs e) => drawboard.Clear();

        private void LoadFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Filter = "graph files (*.graph)|*.graph|All files (*.*)|*.*",
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            drawboard.Graph = GraphIOManager.Load(dialog.FileName);
        }

        private void Help_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("a) Click right on the drawboard to add or rename nodes and to delete nodes or edges.");
            sb.AppendLine();
            sb.AppendLine("b) Click and hold left to drag and drop an edge from one node to another node.");
            sb.AppendLine();
            sb.AppendLine("c) Click and holg right on a node to move this node.");
            sb.AppendLine();
            sb.AppendLine("d) Scroll on the drawboard or use the trackbar (bottom right) to change the size of the nodes.");
            sb.AppendLine();
            sb.AppendLine("Copyright 2022 Silas Mario Schnurr. Icons by https://icons8.de");

            MessageBox.Show($"{sb}", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Click_Run(object sender, EventArgs e)
        {
            if (!_pebbleSolver.IsStarted && drawboard.Graph.Nodes.Count < 1)
                MessageBox.Show("The simulation cannot be started because there must be at least one node.", "Can't start the Simulation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!_pebbleSolver.IsStarted && drawboard.Graph.Nodes.Count > 31)
                MessageBox.Show("The simulation cannot be started because the maximum number of nodes allowed for the simulation is 31.", "Can't start the Simulation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                _pebbleSolver.StartStop(drawboard.Graph);
        }

        private void PebbleSovlerStartedOrStopped(object? sender, RunningStateChangedEventArgs e)
        {
            var isRunning = e.State == RunningStateChangedEventArgs.RunningState.Running;
            var isSelectionMode = e.State == RunningStateChangedEventArgs.RunningState.SelectionMode;
            var isStopped = e.State == RunningStateChangedEventArgs.RunningState.NotRunning;

            menuitemFile.Enabled = isStopped;
            tsbSettings.Enabled = isStopped;
            tsbHelp.Enabled = !isRunning;
            zoomBar.Enabled = !isRunning;
            drawboard.SetInteractionEnabled(!isRunning);

            tsbRun.Image = isRunning || isSelectionMode ? Properties.Resources.stop : Properties.Resources.play;
            tsbRun.Text = isRunning || isSelectionMode ? "Stop Pebble game" : "Run Pebble game";
            menu.Refresh();
        }

        private void OpenPredefinedGraph(object sender, EventArgs e)
        {
            var predefinedGraphNumber = Int32.Parse($"{(sender as ToolStripMenuItem)?.Tag}");
            drawboard.Graph = GraphIOManager.Load(predefinedGraphNumber);
        }

        private void Rescale(object sender, EventArgs e)
        {
            drawboard.Graph.Rescale(new Rectangle(Settings.NodeSize, Settings.NodeSize, drawboard.Width - Settings.NodeSize * 2, drawboard.Height - Settings.NodeSize * 2));
            drawboard.Repaint();
        }

        private void Drawboard_SizeChanged(object sender, EventArgs e)
        {
            if (Settings.ScaleOnResize)
                Rescale(sender, e);
        }
    }
}