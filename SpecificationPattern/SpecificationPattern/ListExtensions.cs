using System;
using System.Collections.Generic;

namespace SpecificationPattern
{
    public static class ListExtensions
    {
        public static void Print<T>(this IEnumerable<T> enummerable, string header = null)
        {
            if (header != null)
                Console.WriteLine($" --- {header} ---");

            foreach (var e in enummerable)
                Console.WriteLine(e);

            Console.WriteLine();
        }
    }
}
