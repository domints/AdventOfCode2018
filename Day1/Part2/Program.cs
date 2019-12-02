using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = File.ReadAllLines("input.txt")
                .Select(l => l.Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(v => ParseValue(v)).ToList();
            
            var result = FindDoubleFrequency(items);
            
            Console.WriteLine(result);
        }

        static int ParseValue(string input)
        {
            var multiplier = 1;
            if(input[0] == '-') multiplier = -1;
            return int.Parse(input.Substring(1)) * multiplier;
        }

        static int FindDoubleFrequency(List<int> input)
        {
            HashSet<int> seenValues = new HashSet<int>();
            seenValues.Add(0);
            int currentValue = 0;
            int listIndex = 0;
            while(true)
            {
                currentValue += input[listIndex++];
                if(listIndex >= input.Count) listIndex = 0;

                if(seenValues.Contains(currentValue))
                    break;

                seenValues.Add(currentValue);
            }

            return currentValue;
        }
    }
}
