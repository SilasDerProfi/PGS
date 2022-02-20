namespace PGS.Data
{
    public class PebbledNode : Node
    {
        public PebbledNode() : base() { }

        public PebbledNode(char identifier, Point position) : base(identifier, position) { }

        public uint Pebbles { get; private set; }

        public void AddPebble() => Pebbles += _inEdges.All(e => e.StartNode is PebbledNode p && p.Pebbles > 0).ToInt();

        public void RemovePebble() => Pebbles -= (Pebbles > 0).ToInt();

        internal override void Draw(Graphics graphics, Point fallbackPosition, bool isUnderCursor)
        {
            base.Draw(graphics, fallbackPosition, isUnderCursor);

            if (Pebbles > 0)
            {
                var x = (Position?.X ?? fallbackPosition.X) - Settings.NodeSize / 3;
                var y = (Position?.Y ?? fallbackPosition.Y) - Settings.NodeSize / 3;
                
                var pebbleSize = Settings.LineSize * 4;
                graphics.FillEllipse(new SolidBrush(Settings.PebbleColor), x, y, pebbleSize, pebbleSize);
            }
        }

        public List<Edge> OutEdges => _outEdges.ToList();
        public List<Edge> InEdges => _inEdges.ToList();
    }
}
