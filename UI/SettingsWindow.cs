using System.Drawing.Drawing2D;
using System.Reflection;
using PGS.Data;

namespace PGS.UI
{
    public partial class SettingsWindow : Form
    {
        private Graph<PebbledNode>? _settingsGraph;
        private bool _saveSettings;

        private readonly Dictionary<string, (object OriginalValue, Action ImportSetting, Action SaveSetting)> _settingsDict;
        public SettingsWindow()
        {
            InitializeComponent();
            cbFonts.DisplayMember = "Name";
            cbFonts.DataSource = FontFamily.Families.ToList();

            _settingsDict = new()
            {
                { nameof(Settings.NodeSize), (Settings.NodeSize, () => { }, () => { }) },
                { nameof(Settings.TextFontFamily), (Settings.TextFontFamily, () => cbFonts.SelectedItem = Settings.TextFont.FontFamily, () => Settings.TextFontFamily = SelectedFontName ?? Settings.TextFontFamily) },
                { nameof(Settings.TextColor), (Settings.TextColor, () => cpText.Color = Settings.TextColor, () => Settings.TextColor = cpText.Color ?? Settings.TextColor) },
                { nameof(Settings.EdgeColor), (Settings.EdgeColor, () => cpEdge.Color = Settings.EdgeColor, () => Settings.EdgeColor = cpEdge.Color ?? Settings.EdgeColor) },
                { nameof(Settings.NodeBorderColor), (Settings.NodeBorderColor, () => cpNodeBorder.Color = Settings.NodeBorderColor, () => Settings.NodeBorderColor = cpNodeBorder.Color ?? Settings.NodeBorderColor) },
                { nameof(Settings.NodeFillColor), (Settings.NodeFillColor, () => cpNodeFill.Color = Settings.NodeFillColor, () => Settings.NodeFillColor = cpNodeFill.Color ?? Settings.NodeFillColor) },
                { nameof(Settings.PebbleColor), (Settings.PebbleColor, () => cpPebble.Color = Settings.PebbleColor, () => Settings.PebbleColor = cpPebble.Color ?? Settings.PebbleColor) },

                { nameof(Settings.ScaleOnResize), (Settings.ScaleOnResize, () => cbScaleOnResize.Checked = Settings.ScaleOnResize, () => Settings.ScaleOnResize = cbScaleOnResize.Checked) },
                { nameof(Settings.ScaleOnLoad), (Settings.ScaleOnLoad, () => cbScaleOnLoad.Checked = Settings.ScaleOnLoad, () => Settings.ScaleOnLoad = cbScaleOnLoad.Checked) },
                { nameof(Settings.ScaleWhenPebblegameStarts), (Settings.ScaleWhenPebblegameStarts, () => cbRescalePebbleGame.Checked = Settings.ScaleWhenPebblegameStarts, () => Settings.ScaleWhenPebblegameStarts = cbRescalePebbleGame.Checked) },

                { nameof(Settings.UseAxiomOptimization), (Settings.UseAxiomOptimization, () => cbUseAxioms.Checked = Settings.UseAxiomOptimization, () => Settings.UseAxiomOptimization = cbUseAxioms.Checked) },
            };
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            _saveSettings = true;
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e) =>  Close();

        private void cbFonts_DrawItem(object sender, DrawItemEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.Items[e.Index];
            var font = new Font(fontFamily, comboBox.Font.SizeInPoints);
            e.DrawBackground();
            e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        private void cbFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.Items[comboBox.SelectedIndex];
            var font = new Font(fontFamily, comboBox.Font.SizeInPoints);
            comboBox.Font = font;
        }

        private string? SelectedFontName => (cbFonts.SelectedItem as FontFamily)?.Name;

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            ImportSettings();
            InitSettingsGraph();
        }

        private void InitSettingsGraph()
        {
            _settingsGraph = new();
            var posNodeA = new Point(50, 50);
            var posNodeB = new Point(350, 50);

            _settingsGraph.AddNodeAt(posNodeA);
            _settingsGraph.AddNodeAt(posNodeB);
            _settingsGraph.GetNearestNode(posNodeB)?.Node?.AddPebble();

            _settingsGraph.AddEdgeAt(posNodeA);
            if (_settingsGraph.CurrentEdge != null)
                _settingsGraph.CurrentEdge.TargetNode = _settingsGraph.GetNearestNode(posNodeB)?.Node;

            Settings.NodeSize = 80;

            pbSettingsDrawboard.Invalidate();
        }

        private void ImportSettings() => _settingsDict.ForEach(s => s.Value.ImportSetting());

        private void SettingsDrawboard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            _settingsGraph?.Draw(e.Graphics, new Point(0,0));
        }

        private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.NodeSize = (int)_settingsDict[nameof(Settings.NodeSize)].OriginalValue;

            if (_saveSettings)
                return;

            _settingsDict.ForEach(setting => typeof(Settings)
                .InvokeMember(setting.Key, BindingFlags.Static | BindingFlags.SetProperty | BindingFlags.NonPublic, Type.DefaultBinder, null, new object[] { setting.Value.OriginalValue }));
        }

        private void SettingChanged(object sender, EventArgs e)
        {
            if (_settingsGraph == null)
                return;

            _settingsDict.ForEach(s => s.Value.SaveSetting());
            pbSettingsDrawboard.Invalidate();
        }
    }
}
