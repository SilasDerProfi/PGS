namespace PGS
{
    internal static partial class Settings
    {
        private static int _nodeSize = 40;

        internal static int NodeSize
        {
            get => _nodeSize;
            set => _nodeSize = Math.Min(Math.Max(value, 10), 200);
        }

        internal static int MaxDistanceForClick { get; set; } = 10;
        internal static int NodeConnectDistance => NodeSize;
        internal static int LineConnectDistance => LineSize + 10;
        internal static int LineSize => Math.Max(NodeSize / 20, 1);
    }
}
