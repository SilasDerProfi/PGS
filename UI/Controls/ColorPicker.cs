namespace PGS.UI
{
    public partial class ColorPicker : UserControl
    {
        private Color? _currentColor;

        public ColorPicker() => InitializeComponent();

        public string Label
        {
            get => lbl.Text;
            set => lbl.Text = value;
        }

        public Color? Color
        {
            get => _currentColor;
            set
            {
                var changed = value != _currentColor;

                _currentColor = value;
                pbColor.BackColor = value ?? SystemColors.Control;

                if (changed)
                    ColorChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            if(cd.ShowDialog() == DialogResult.OK)
                Color = cd.Color;
        }

        public event EventHandler? ColorChanged;
    }
}
