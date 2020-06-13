//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using System.Collections.Generic;

namespace Lumpn.Messaging
{
    internal static class ListExtensions
    {
        public static bool AddUnique<T>(this IList<T> list, T item)
        {
            if (list.Contains(item)) return false;
            list.Add(item);
            return true;
        }

        public static bool RemoveUnordered<T>(this IList<T> list, T item)
        {
            int idx = list.IndexOf(item);
            if (idx < 0) return false;

            int last = list.Count - 1;
            list[idx] = list[last];
            list.RemoveAt(last);
            return true;
        }
    }
}
