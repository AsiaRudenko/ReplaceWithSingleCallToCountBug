using System.Linq;

namespace KeLi.ReplaceWithSingleCallToCountBug.App
{
    public static class LinqExtension
    {
        public static bool In<T>(this T value, params T[] ranges)
        {
            return ranges.Contains(value);
        }
    }
}