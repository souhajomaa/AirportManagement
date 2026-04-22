using System;
using System.Collections.Generic;

namespace AM.ApplicationCore
{
    public static class CoreExtensions
    {
        public static void ShowList<T>(this IEnumerable<T> source, string title, ShowLine showLine)
        {
            showLine($"\n=== {title} ===");
            foreach (var item in source)
            {
                showLine(item.ToString());
            }
        }
    }
}