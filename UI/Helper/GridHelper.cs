namespace PGS.UI
{
    internal static class GridHelper
    {
        internal static void Draw(Graphics g, int width, int height)
        {
            using var gridPen = new Pen(Settings.GridColor);

            for (int y = Settings.GridSize; y < height; y += Settings.GridSize)
                g.DrawLine(gridPen, 0, y, width, y);

            for (int x = Settings.GridSize; x < width; x += Settings.GridSize)
                g.DrawLine(gridPen, x, 0, x, height);
        }
    }
}
