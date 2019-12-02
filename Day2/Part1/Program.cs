using System;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = File.ReadAllLines("input.txt")
                .Select(l => l.Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .ToList();

            var doubles = items.Where(i => HasNDuplicates(i, 2)).Count();
            var triples = items.Where(i => HasNDuplicates(i, 3)).Count();

            Console.WriteLine(doubles * triples);
        }

        static bool HasNDuplicates(string input, int n)
        {
            return input.GroupBy(x => x).Any(g => g.Count() == n);
        }
    }
}
