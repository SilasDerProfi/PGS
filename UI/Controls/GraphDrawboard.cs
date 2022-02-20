using System.Drawing.Drawing2D;
using PGS.Data;

namespace PGS.UI
{
    public partial class GraphDrawboard : UserControl
    {
        private readonly MouseDownState _mouseDownState = new();
        private Point MousePos => this.PointToClient(MousePosition);

        private Graph<PebbledNode> _graph = new();

        public GraphDrawboard()
        {
            InitializeComponent();

            _mouseDownState.ClickedLeft += DrawBoardClickedLeft;
            _mouseDownState.ClickedRight += DrawBoardClickedRight;
            _mouseDownState.BeginHoldLeft += DrawBoardBeginHoldLeft;
            _mouseDownState.EndHoldLeft += DrawBoardEndHoldLeft;
            _mouseDownState.BeginHoldRight += DrawBoardBeginHoldRight;
            _mouseDownState.EndHoldRight += DrawBoardEndHoldRight;
            drawboard.MouseDown += _mouseDownState.MouseDown;
            drawboard.MouseMove += _mouseDownState.MouseMove;
            drawboard.MouseUp += _mouseDownState.MouseUp;
            drawboard.Focus();
        }

        internal void Repaint() => drawboard.Invalidate();

        public Graph<PebbledNode> Graph
        {
            get
            {
                return _graph;
            }
            set
            {
                _graph = value;

                if (Settings.ScaleOnLoad)
                    Graph.Rescale(new Rectangle(Settings.NodeSize, Settings.NodeSize, drawboard.Width - Settings.NodeSize * 2, drawboard.Height - Settings.NodeSize * 2));

                drawboard.Invalidate();
            }
        }

        public event EventHandler? ZoomvalueChanged;

        private void DrawBoardClickedRight(object? sender, MouseEventArgs e)
        {
            var nextNode = _graph.GetNearestNode(_mouseDownState.Location);
            var nextEdge = _graph.GetNearestEdge(_mouseDownState.Location);

            cmaDeleteNodeOrEdge.Enabled = nextNode.HasValue && nextNode?.Distance < (Settings.NodeSize / 2) || nextEdge.HasValue;
            cmaRename.Enabled = nextNode.HasValue;
            cmtbNewName.Text = String.Empty;
            contextMenu.Show(MousePosition);
        }


        private void DrawBoardBeginHoldLeft(object? sender, MouseEventArgs e)
        {
            if (_graph.AddEdgeAt(_mouseDownState.Location))
                Cursor.Current = Cursors.Cross;
        }

        private void DrawBoardEndHoldLeft(object? sender, MouseEventArgs e)
        {
            if (_graph.CurrentEdge != null)
                _graph.CurrentEdge.TargetNode = _graph.GetNearestNode(MousePos)?.Node;

            drawboard.Invalidate();
        }

        private void DrawBoardBeginHoldRight(object? sender, MouseEventArgs e)
        {
            var nextNode = _graph.GetNearestNode(_mouseDownState.Location)?.Node;

            if (nextNode != null)
            {
                nextNode.Position = null;
                Cursor.Current = Cursors.Hand;
            }
        }

        private void DrawBoardEndHoldRight(object? sender, MouseEventArgs e)
        {
            if (_graph.CurrentNode != null)
                _graph.CurrentNode.Position = MousePos;

            drawboard.Invalidate();
        }

        public event EventHandler? UserSelectedNode;
        private void DrawBoardClickedLeft(object? sender, MouseEventArgs e)
        {
            if (!Settings.SelectionMode)
                return;

            var nextNode = _graph.GetNearestNode(_mouseDownState.Location)?.Node;

            if (nextNode is not null)
            {
                Settings.SelectionMode = false;
                UserSelectedNode?.Invoke(nextNode, EventArgs.Empty);
            }
        }

        private void Drawboard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (Settings.DrawGrid)
                GridHelper.Draw(e.Graphics, Width, Height);

            _graph.Draw(e.Graphics, MousePos);
        }

        private void Drawboard_MouseMove(object sender, MouseEventArgs e) => drawboard.Invalidate();

        internal void SetInteractionEnabled(bool enabled) => _mouseDownState.SetInteractionEnabled(enabled);

        private void AddNode(object? sender = null, EventArgs? e = null)
        {
            _graph.AddNodeAt(_mouseDownState.Location);
            drawboard.Invalidate();
        }

        private void DeleteNodeOrEdge(object sender, EventArgs e)
        {
            _graph.RemoveNodeOrEdgeAt(_mouseDownState.Location);
            drawboard.Invalidate();
        }

        private void RenameNode(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            _graph.RenameNodeAt(_mouseDownState.Location, cmtbNewName.Text.FirstChar());
            contextMenu.Close();
            drawboard.Invalidate();
        }

        internal void ResizeTo(int value)
        {
            Settings.NodeSize = value;
            ZoomvalueChanged?.Invoke(this, new EventArgs());
            drawboard.Invalidate();
        }

        private void Drawboard_Scroll(object sender, MouseEventArgs e)
        {
            if (_mouseDownState.IsInteractionEnabled)
                ResizeTo(Settings.NodeSize + Math.Sign(e.Delta));
        }

        public void Clear()
        {
            _graph = new Graph<PebbledNode>();
            drawboard.Invalidate();
        }
    }
}


