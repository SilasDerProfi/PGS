using System.Windows.Forms.Design;

namespace PGS.UI
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
    public class ToolStripTraceBarItem : ToolStripControlHost
    {
        public ToolStripTraceBarItem() : base(new TrackBar())
        {
            TrackBar.TickStyle = TickStyle.None;
            TrackBar.MaximumSize = new Size(500, 25);
            TrackBar.ValueChanged += TrackBar_ValueChanged;
        }

        public event EventHandler? ValueChanged;

        private void TrackBar_ValueChanged(object? sender, EventArgs e) => ValueChanged?.Invoke(this, e);

        public TrackBar TrackBar => (TrackBar)this.Control;

        public int Minimum
        {
            get => TrackBar.Minimum;
            set => TrackBar.Minimum = value;
        }

        public int Maximum
        {
            get => TrackBar.Maximum;
            set => TrackBar.Maximum = value;
        }

        public int Value
        {
            get => TrackBar.Value;
            set => TrackBar.Value = value >= Minimum && value <= Maximum ? value : Value;
        }
    }
}
