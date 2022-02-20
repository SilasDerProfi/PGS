namespace PGS.Data
{
    public partial class Graph<T> where T : Node, new()
    {
        private readonly List<T> _nodes = new();

        public (T Node, double Distance)? GetNearestNode(Point p)
        {
            var distances = _nodes.Select(n => (n, n.Position?.Distance(p) ?? Settings.NodeConnectDistance))
                                  .Where(n => n.Item2 < Settings.NodeConnectDistance);

            return distances.Any() ? distances.MinBy(n => n.Item2) : null;
        }

        public (Edge Edge, double Distance)? GetNearestEdge(Point p)
        {
            var distances = _nodes.Select(n => n.GetNearestEdge(p, Settings.LineConnectDistance));
            return distances.Any() ? distances.MinBy(n => n?.Distance) : null;
        }

        internal void RemoveNodeOrEdgeAt(Point location)
        {
            var nextNode = GetNearestNode(location);
            var nextEdge = GetNearestEdge(location);

            if (nextNode.HasValue && nextNode?.Distance < (Settings.NodeSize / 2))
                RemoveNode(nextNode.Value.Node);
            else if (nextEdge.HasValue)
                Node.RemoveEdge(nextEdge.Value.Edge);
        }

        private void RemoveNode(T node)
        {
            _nodes.Remove(node);
            node.Dispose();
        }

        internal void RenameNodeAt(Point location, char? newName) => GetNearestNode(location)?.Node?.Rename(newName);

        internal void Draw(Graphics graphics, Point fallbackPosition)
        {
            using var edgePen = Settings.EdgePen;
            _nodes.ForEach(node => node.DrawEdges(graphics, fallbackPosition, edgePen));
            _nodes.ForEach(node => node.Draw(graphics, fallbackPosition, GetNearestNode(fallbackPosition)?.Node == node));
        }

        internal void Rescale(Rectangle newBoundings)
        {
            // transform, so that the center of the current boundingbox and the center of the new bounding box are the same
            var currentBoundings = Nodes.Select(n => n.Position).CalculateBoundingBox();
            var deltaPositionX = newBoundings.Center().X - currentBoundings.Center().X;
            var deltaPositionY = newBoundings.Center().Y - currentBoundings.Center().Y;
            Nodes.ForEach(n => n.Position = n.Position?.Transform(deltaPositionX, deltaPositionY));

            if (Nodes.Count < 2)
                return;

            // rescale center-based so that the width and height of the Boxes are the same
            var scaleFactorX = newBoundings.Width / (double)currentBoundings.Width;
            var scaleFactorY = newBoundings.Height / (double)currentBoundings.Height;
            Nodes.ForEach(n =>
            {
                if (n.Position.HasValue)
                {
                    n.Position = new Point(
                        (int)(newBoundings.Center().X + (n.Position.Value.X - newBoundings.Center().X) * scaleFactorX),
                        (int)(newBoundings.Center().Y + (n.Position.Value.Y - newBoundings.Center().Y) * scaleFactorY));
                }
            });
        }

        internal Edge? CurrentEdge => _nodes.FirstOrDefault(n => n.HasCurrentEdge)?.CurrentEdge;
        internal Node? CurrentNode => _nodes.FirstOrDefault(n => !n.Position.HasValue);

        internal void AddNodeAt(Point location) => _nodes.Add(new T() { Identifier = (char)('A' + _nodes.Count), Position = location });

        internal bool AddEdgeAt(Point location)
        {
            var nextNode = GetNearestNode(location)?.Node;
            if (nextNode != null)
                Node.AddEdge(new Edge(nextNode));

            return nextNode != null;
        }

        internal List<T> Nodes => _nodes;
    }
}
