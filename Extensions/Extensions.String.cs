namespace PGS
{
    public static partial class Extensions
    {
        public static char? FirstChar(this string s) => s.Any() ? s[0] : null;
    }
}