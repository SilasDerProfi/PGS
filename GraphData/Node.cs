namespace PGS.Data
{
    public partial class Node : IDisposable
    {
        private protected HashSet<Edge> _outEdges = new();
        private protected HashSet<Edge> _inEdges = new();
        private Point? _position;

        public char Identifier { get; set; }
        public Point? Position
        {
            get => _position;
            set
            {
                _position = value;

                if(_position.HasValue)
                {
                    var x = _position.Value.X - (_position.Value.X % Settings.GridSize);
                    var y = _position.Value.Y - (_position.Value.Y % Settings.GridSize);
                    _position = new Point(x, y);
                }
            }
        }
        public Node() { }
        public Node(char identifier, Point position)
        {
            Identifier = identifier;
            Position = position;           
        }

        public bool HasCurrentEdge => CurrentEdge is not null;
        public Edge? CurrentEdge => _outEdges.FirstOrDefault(e => e.IsCurrentEdge);

        internal (Edge Edge, double Distance)? GetNearestEdge(Point p, int maxDistance)
        {
            if (Position == null)
                return null;

            var distances =_outEdges.Where(e => e?.TargetNode?.Position != null)
                                    .Select(e => (Edge: e, Distance: p.Distance(e)))
                                    .Where(e => e.Distance < maxDistance);

            return distances.Any() ? distances.MinBy(d => d.Distance) : null;
        }

        public static void RemoveEdge(Edge edge)
        {
            edge.TargetNode?._inEdges?.Remove(edge);
            edge.StartNode._outEdges.Remove(edge);
        }

        internal static void AddEdge(Edge edge)
        {
            edge.StartNode._outEdges.Add(edge);
            edge.TargetNode?._inEdges?.Add(edge);
        }

        internal virtual void Draw(Graphics graphics, Point fallbackPosition, bool isUnderCursor)
        {
            fallbackPosition = new Point(fallbackPosition.X - (fallbackPosition.X % Settings.GridSize), fallbackPosition.Y - (fallbackPosition.Y % Settings.GridSize));

            byte colorAlphaValue = byte.MaxValue;
            if (TargetsTransitivTo(n => n._outEdges.Any(e => e.IsCurrentEdge)) || _inEdges.Any(e1 => e1.StartNode.HasCurrentEdge) || (Settings.SelectionMode && !isUnderCursor))
                colorAlphaValue = 32;

            using var nodePen = Settings.CreateNodeBorderPen(colorAlphaValue);
            var nodeFillBrush = new SolidBrush(Color.FromArgb(colorAlphaValue, Settings.NodeFillColor));
            var textFont = Settings.TextFont;
            var textBrush = new SolidBrush(Color.FromArgb(colorAlphaValue, Settings.TextColor));

            var nodeX = (Position?.X ?? fallbackPosition.X) - Settings.NodeSize / 2;
            var nodeY = (Position?.Y ?? fallbackPosition.Y) - Settings.NodeSize / 2;
            var nodeBoundings = new Rectangle(nodeX, nodeY, Settings.NodeSize, Settings.NodeSize);

            graphics.FillEllipse(nodeFillBrush, nodeBoundings);
            graphics.DrawEllipse(nodePen, nodeBoundings);

            using StringFormat stringFormat = new()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            graphics.DrawString($"{Identifier}", Settings.TextFont, textBrush, nodeBoundings, stringFormat);
        }

        internal void DrawEdges(Graphics graphics, Point fallbackPosition, Pen edgePen) => _outEdges.ToList().ForEach(edge => edge.Draw(graphics, fallbackPosition, edgePen));

        internal void Rename(char? newName) => Identifier = newName ?? Identifier;

        internal bool TargetsTransitivTo(Node endNode, Node? initialNode = null) => TargetsTransitivTo(n => n == endNode, initialNode);
        internal bool TargetsTransitivTo(Func<Node, bool> isTransitivCondition, Node? initialNode = null)
        {
            if (isTransitivCondition(this))
                return true;

            if (initialNode == this)
                return false;

            return _outEdges.Any(e => e.TargetNode != null && e.TargetNode.TargetsTransitivTo(isTransitivCondition, initialNode ?? this));
        }

        internal bool TargetsDirectTo(Node value) => _outEdges.Any(e => e.TargetNode == value);

        public void Dispose() => _inEdges.Concat(_outEdges).ToList().ForEach(edge => RemoveEdge(edge));
        internal List<Node> DirectParents() => _inEdges.Select(e => e.StartNode).ToList();
    }

}
