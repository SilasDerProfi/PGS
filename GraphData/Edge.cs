namespace PGS.Data
{
    public partial class Edge
    {
        private Node? _targetNode;

        public Edge(Node startNode)
        {
            StartNode = startNode;
        }

        public readonly Node StartNode;

        public Node? TargetNode
        {
            get =>  _targetNode;
            set
            {
                if (value == null || value.TargetsTransitivTo(StartNode) || StartNode.TargetsDirectTo(value))
                    Node.RemoveEdge(this);
                else
                {
                    _targetNode = value;
                    Node.AddEdge(this);
                }
            }
        }

        public bool IsCurrentEdge => TargetNode == null;

        internal void Draw(Graphics graphics, Point fallbackPosition, Pen pen)
        {
            var startPosition = StartNode.Position ?? fallbackPosition;

            var targetPosition = fallbackPosition;

            if (TargetNode != null)
            {
                targetPosition = TargetNode.Position ?? targetPosition;
                targetPosition = (startPosition, targetPosition).TransformLineEndposition(-(Settings.NodeSize / 2 + Settings.LineSize));
            }

            startPosition = (targetPosition, startPosition).TransformLineEndposition(-(Settings.NodeSize / 2 + 1));

            graphics.DrawLine(pen, startPosition, targetPosition);
        }
    }
}
