using System;
using System.IO;
using System.Linq;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = File.ReadAllLines("input.txt")
                .Select(l => l.Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(v => ParseValue(v))
                .Sum();
            
            Console.WriteLine(result);
        }

        static int ParseValue(string input)
        {
            var multiplier = 1;
            if(input[0] == '-') multiplier = -1;
            return int.Parse(input.Substring(1)) * multiplier;
        }
    }
}
