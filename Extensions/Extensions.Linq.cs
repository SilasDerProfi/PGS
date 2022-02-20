namespace PGS
{
    public static partial class Extensions
    {
        public static void ForEach<TKey, TValue>(this Dictionary<TKey, TValue> source, Action<KeyValuePair<TKey, TValue>> action) where TKey : notnull
        {
            foreach (var item in source)
                action(item);
        }

        public static T Pop<T>(this List<T> source)
        {
            var value = source.First();
            source.RemoveAt(0);
            return value;
        }

        public static bool NotAny<T>(this IEnumerable<T> source) => !source.Any();
    }
}