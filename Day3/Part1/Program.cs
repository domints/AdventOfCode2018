using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = File.ReadAllLines("input.txt")
                .Select(l => l.Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => ParseFabricEntry(l)).ToList();
            Dictionary<string, int> claimsDict = new Dictionary<string, int>();
            foreach(var item in items) ClaimFabric(item, claimsDict);

            Console.WriteLine(claimsDict.Count(kvp => kvp.Value > 1));
        }

        static FabricPart ParseFabricEntry(string input)
        {
            var split1 = input.Split('@');
            var id = int.Parse(split1[0].Trim().Trim('#'));
            var split2 = split1[1].Split(':');
            var position = split2[0].Trim();
            var size = split2[1].Trim();
            return new FabricPart 
            {
                Id = id,
                Left = int.Parse(position.Split(',')[0].Trim()),
                Top = int.Parse(position.Split(',')[1].Trim()),
                Width = int.Parse(size.Split('x')[0].Trim()),
                Height = int.Parse(size.Split('x')[1].Trim())
            };
        }

        static void ClaimFabric(FabricPart part, Dictionary<string, int> claimsDict)
        {
            for(int x = 0; x < part.Width; x++)
                for(int y = 0; y < part.Height; y++)
                {
                    if(!claimsDict.ContainsKey(GetKey(part, x, y)))
                    {
                        claimsDict.Add(GetKey(part, x, y), 1);
                    }
                    else 
                    {
                        claimsDict[GetKey(part, x, y)]++;
                    }
                }
        }

        static string GetKey(FabricPart part, int x, int y)
        {
            return $"{x + part.Left}&&{y + part.Top}";
        }
    }
}
