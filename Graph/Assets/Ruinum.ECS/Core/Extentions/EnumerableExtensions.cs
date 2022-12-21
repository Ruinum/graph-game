using System.Collections.Generic;

namespace Ruinum.ECS.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool TryGetFirst<T>(this IEnumerable<T> enumerable, out T first)
        {
            foreach (var value in enumerable)
            {
                first = value;
                return true;
            }
            first = default;
            return false;
        }
    }
}