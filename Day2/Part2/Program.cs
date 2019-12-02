using System;
using System.IO;
using System.Linq;
using System.Text;

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

            Console.WriteLine(items.Join(items, _ => true, _ => true, FindDifferences).First(j => j.differences == 1).commonLetters);
        }

        static (int differences, string commonLetters) FindDifferences(string first, string second)
        {
            int diffCount = 0;
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < first.Length; i++)
            {
                if(first[i] == second[i])
                {
                    sb.Append(first[i]);
                }
                else diffCount++;
            }

            return (diffCount, sb.ToString());
        }
    }
}
