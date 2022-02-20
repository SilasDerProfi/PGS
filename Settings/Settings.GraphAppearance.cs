using System.Drawing.Drawing2D;

namespace PGS
{
    internal static partial class Settings
    {
        internal static Font TextFont => new(TextFontFamily, Math.Max(NodeSize / 4, 5), FontStyle.Regular, GraphicsUnit.Point);
        internal static string TextFontFamily { get; set; } = "Segoe UI";
        internal static Color NodeFillColor { get; set; } = Color.White;
        internal static Color NodeBorderColor { get; set; } = Color.Black;
        internal static Color TextColor { get; set; } = Color.Black;
        internal static Color PebbleColor { get; set; } = Color.DarkGray;
        internal static Color EdgeColor { get; set; } = Color.Black;

        internal static Pen CreateNodeBorderPen(byte alphaValue) => new (Color.FromArgb(alphaValue, NodeBorderColor), LineSize);
        internal static Pen EdgePen
        {
            get
            {
                var pen = new Pen(new SolidBrush(EdgeColor), LineSize);
                GraphicsPath arrowPath = new();

                var height = (float)Math.Min(4, NodeSize * 0.05 + 1);
                var width = height * 2;
                var transform = 0;

                var rightDown = new PointF(-width / 2, -height + transform);
                var rightUp = new PointF(0, transform);
                var leftDown = new PointF(0,transform);
                var leftUp = new PointF(width / 2, -height + transform);

                arrowPath.AddLine(rightDown, rightUp);
                arrowPath.AddLine(leftDown, leftUp);

                pen.CustomEndCap = new CustomLineCap(null, arrowPath);

                return pen;
            }
        }
    }
}
