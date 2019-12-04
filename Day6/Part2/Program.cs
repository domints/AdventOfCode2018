using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<(int x, int y)> coords = File.ReadAllLines("input.txt")
                .Select(l => l.Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => (int.Parse(l.Split(',')[0].Trim()), int.Parse(l.Split(',')[1].Trim())))
                .ToList();
            var maxX = coords.Max(c => c.x) + 2;
            var maxY = coords.Max(c => c.y) + 2;
            List<(int x, int y)> closeCoords = new List<(int x, int y)>();
            for(int x = 0; x < maxX; x++)
                for(int y = 0; y < maxY; y++)
                {
                    var sumDist = coords.Select((c, ix) => new { D = Dist((x, y), c), Ix = ix })
                        .Sum(c => c.D);
                    if(sumDist < 10000)
                        closeCoords.Add((x ,y));
                }

            Console.WriteLine(closeCoords.Count);
        }

        static int Dist((int x, int y) first, (int x, int y) second)
        {
            return Math.Abs(first.x - second.x) + Math.Abs(first.y - second.y);
        }
    }
}
