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
            var stepsRaw = File.ReadAllLines("input.txt")
                .Select(l => l.Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => new { After = l[36], Before = l[5]})
                .ToList();
            Dictionary<char, Step> steps = new Dictionary<char, Step>();
            foreach(var s in stepsRaw)
            {
                steps.TryAdd(s.Before, new Step { Id = s.Before });
                steps.TryAdd(s.After, new Step { Id = s.After });
            }
        }
    }

    class Step
    {
        public char Id { get; set; }
        public List<Step> Before { get; set; }
        public List<Step> After { get; set; }
    }
}
