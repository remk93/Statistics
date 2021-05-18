using System;
using System.Collections.Generic;
using System.Linq;

namespace Statistics.Core.Extensions
{
    public static class EnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            if (enumeration == null) throw new ArgumentNullException(nameof(enumeration));
            if (action == null) throw new ArgumentNullException(nameof(action));

            foreach (T item in enumeration)
            {
                action(item);
            }
        }

        public static bool IsEmpty<T>(this IEnumerable<T>? source)
        {
            if (source == null) return true;
            return !source.Any();
        }
    }
}
