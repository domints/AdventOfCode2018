using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<(int x, int y)> coords = File.ReadAllLines("input.txt")
                .Select(l => l.Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => new { Step = l[36], Before = l[5]})
                .ToList();
        }
    }
}
