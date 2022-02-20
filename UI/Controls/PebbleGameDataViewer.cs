using PGS.PebbleGame.Solver;

namespace PGS.UI
{
    public partial class PebbleGameDataViewer : UserControl
    {
        public PebbleGameDataViewer() => InitializeComponent();

        private int CurrentPebbles
        {
            get => int.Parse(tbCurrentPebbles.Text);
            set
            {
                tbCurrentPebbles.Text = $"{value}";
                tbMaxPebbles.Text = $"{Math.Max(value, MaxPebbles)}";
                tbStepNumber.Text = $"{Steps + 1}";
            }
        }

        public int Steps => int.Parse(tbStepNumber.Text);

        public int MaxPebbles => int.Parse(tbMaxPebbles.Text);

        internal IPebbleGameSolver? SelectedSolver => (cbStrategy.SelectedItem as PebbleStrategyItem)?.Solver;

        internal void AddStrategyItem(PebbleStrategyItem item) => cbStrategy.Items.Add(item);

        public void AddStatus(string message, bool overwriteLastLine = false)
        {
            if (overwriteLastLine && rtbLog.Lines.Any())
                rtbLog.Lines = rtbLog.Lines.Take(rtbLog.Lines.Length - 1).ToArray();

            if (rtbLog.Text.Any())
                rtbLog.Text += Environment.NewLine;

            rtbLog.Text += message;
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }

        /// <summary>
        /// Increases the number of pebbles currently in use by 1.
        /// This may also affect the maximum number of pebbles.
        /// Adds a new Log-Message.
        /// </summary>
        /// <returns>The new number of pebbles</returns>
        public int AddPebble(char nodeIdentifier)
        {
            CurrentPebbles++;
            AddStatus($"Step {Steps}: Add Pebble on '{nodeIdentifier}'");
            return CurrentPebbles;
        }

        /// <summary>
        /// Decreases the number of pebbles currently in use by 1.
        /// Adds a new Log-Message.
        /// </summary>
        /// <returns>The new number of pebbles</returns>
            public int RemovePebble(char nodeIdentifier)
        {
            CurrentPebbles--;
            AddStatus($"Step {Steps}: Remove Pebble on '{nodeIdentifier}'");
            return CurrentPebbles;
        }

        internal void Reset()
        {
            tbCurrentPebbles.Text = "0";
            tbMaxPebbles.Text = "0";
            tbStepNumber.Text = "0";
            rtbLog.Text = "";
            cbStrategy.SelectedIndex = 0;
            trackBarSimulationSpeed.Value = 10;
            cbStrategy.Enabled = true;

            if(btnMinMax.Text == "maximize")
                MinMax_Click(btnMinMax, EventArgs.Empty);
        }

        private void TrackBarSimulationSpeed_ValueChanged(object sender, EventArgs e)
        {
            var speed = trackBarSimulationSpeed.Value;

            if (speed < 10)
                Settings.PebbleSolverStepDelay = 5000 - speed * 400;
            else
                Settings.PebbleSolverStepDelay = 1000 - (speed - 10) * 100;
        }

        private void MinMax_Click(object sender, EventArgs e)
        {
            if (groupBoxSettings.Visible)
            {
                groupBoxSettings.Visible = false;
                Height = 56;
                groupBoxLog.Location = new Point(3, groupBoxSettings.Location.Y);
                groupBoxLog.Width += 397;
                btnMinMax.Text = "maximize";
            }
            else
            {
                groupBoxSettings.Visible = true;
                Height = 200;
                groupBoxLog.Width -= 397;
                groupBoxLog.Location = new Point(400, groupBoxSettings.Location.Y);
                btnMinMax.Text = "minimize";
            }
        }

        internal void StartedGame() => cbStrategy.Enabled = false;
    }

    internal class PebbleStrategyItem
    {
        private string _fullDescription;
        private string _shortDescription;
        private Func<IPebbleGameSolver> _getSolverFunc;

        public PebbleStrategyItem(string fulldescription, string shortDescription, Func<IPebbleGameSolver> getSolverFunc)
        {
            _fullDescription = fulldescription;
            _shortDescription = shortDescription;
            _getSolverFunc = getSolverFunc;
        }

        public IPebbleGameSolver Solver => _getSolverFunc();

        public override string ToString() => _shortDescription;
    }
}
