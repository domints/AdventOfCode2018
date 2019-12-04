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
            Dictionary<(int x, int y), int> closestCoord = new Dictionary<(int x, int y), int>();
            for(int x = 0; x < maxX; x++)
                for(int y = 0; y < maxY; y++)
                {
                    var best = coords.Select((c, ix) => new { D = Dist((x, y), c), Ix = ix })
                        .OrderBy(c => c.D)
                        .Take(2).ToList();
                    var id = best[0].D == best[1].D ? -1 : best[0].Ix;
                    closestCoord.Add((x, y), id);
                }

            HashSet<int> infinite = new HashSet<int>();
            for(int x = 0; x < maxX; x++)
            {
                infinite.Add(closestCoord[(x, 0)]);
                infinite.Add(closestCoord[(x, maxY - 1)]);
            }

            for(int y = 0; y < maxY; y++)
            {
                infinite.Add(closestCoord[(0, y)]);
                infinite.Add(closestCoord[(maxX - 1, y)]);
            }

            for(int x = 0; x < maxX; x++)
                for(int y = 0; y < maxY; y++)
                {
                    if(infinite.Contains(closestCoord[(x, y)]))
                        closestCoord.Remove((x, y));
                }

            Console.WriteLine(closestCoord.Values.GroupBy(v => v).Max(g => g.Count()));
        }

        static int Dist((int x, int y) first, (int x, int y) second)
        {
            return Math.Abs(first.x - second.x) + Math.Abs(first.y - second.y);
        }
    }
}
