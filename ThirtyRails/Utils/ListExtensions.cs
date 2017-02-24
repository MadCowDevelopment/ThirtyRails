using System;
using System.Collections.Generic;

namespace ThirtyRails.Utils
{
    public static class ListExtensions
    {
        public static void AddRangeDistinct<T>(this IList<T> obj, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                if (!obj.Contains(item)) obj.Add(item);
            }
        }

        public static void AddNotNull<T>(this IList<T> obj, T value)
        {
            if (value != null) obj.Add(value);
        }
    }

    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> func)
        {
            foreach (var item in enumerable)
            {
                func(item);
            }
        }
    }
}