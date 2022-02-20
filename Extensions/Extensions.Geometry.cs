using PGS.Data;

namespace PGS
{
    public static partial class Extensions
    {
        public static double Distance(this Point a, Point? b)
        {
            if (b == null)
                throw new ArgumentNullException(nameof(b));

            var squareOfA = Math.Pow(a.X - b.Value.X, 2);
            var squareOfB = Math.Pow(a.Y - b.Value.Y, 2);
            var squareOfC = squareOfA + squareOfB;

            return Math.Sqrt(squareOfC);
        }

        public static double Distance(this Point pt, Edge edge)
        {
            if (edge.StartNode.Position == null || edge.TargetNode?.Position == null)
                throw new ArgumentNullException(nameof(edge), "Start end Endpoint of an Enge must be defined to calculate the distance to a Point");

            PointF p1 = edge.StartNode.Position.Value;
            PointF p2 = edge.TargetNode.Position.Value;

            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            if ((dx == 0) && (dy == 0))
            {
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            float t = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) /
                (dx * dx + dy * dy);

            if (t < 0)
            {
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
            }
            else if (t > 1)
            {
                dx = pt.X - p2.X;
                dy = pt.Y - p2.Y;
            }
            else
            {
                var closest = new PointF(p1.X + t * dx, p1.Y + t * dy);
                dx = pt.X - closest.X;
                dy = pt.Y - closest.Y;
            }

            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static Point TransformLineEndposition(this (Point startPoint, Point endPoint) line, int deltaLength)
        {
            if (line.startPoint.Equals(line.endPoint))
                return line.endPoint;

            double dx = line.endPoint.X - line.startPoint.X;
            double dy = line.endPoint.Y - line.startPoint.Y;

            double length = Math.Sqrt(dx * dx + dy * dy);
            double scale = (length + deltaLength) / length;
            dx *= scale;
            dy *= scale;
            return new Point(line.startPoint.X + (int)dx, line.startPoint.Y + (int)dy);
        }

        public static Rectangle CalculateBoundingBox(this IEnumerable<Point?> source)
        {
            int left = source.Min(p => p?.X) ?? int.MinValue;
            int top = source.Min(p => p?.Y) ?? int.MinValue;
            int right = source.Max(p => p?.X) ?? int.MaxValue;
            int bottom = source.Max(p => p?.Y) ?? int.MaxValue;

            return new Rectangle(left, top, right - left, bottom - top);
        }

        public static Point Center(this Rectangle rect) => new(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);

        public static Point Transform(this Point position, int deltaX, int deltaY) => new(position.X + deltaX, position.Y + deltaY);
    }
}
