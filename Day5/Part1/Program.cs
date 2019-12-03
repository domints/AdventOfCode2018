using System;
using System.Collections.Generic;
using System.IO;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("bootUp");
            var start = File.ReadAllText("input.txt").Trim();
            LinkedList<char> polymer = new LinkedList<char>(start);
            while(CleanUp(polymer)) ;
            Console.WriteLine(polymer.Count);
        }

        static bool CleanUp(LinkedList<char> input)
        {
            bool changed = false;
            LinkedListNode<char> lastNode = input.First;
            while(lastNode != null && lastNode.Next != null)
            {
                if(ShouldRemove(lastNode.Value, lastNode.Next.Value))
                {
                    changed = true;
                    var newLastNode = lastNode.Next.Next;
                    input.Remove(lastNode.Next);
                    input.Remove(lastNode);
                    lastNode = newLastNode;
                }
                else
                {
                    lastNode = lastNode.Next;
                }
            }

            return changed;
        }

        static bool ShouldRemove(char current, char next)
        {
            return (char.IsUpper(current) && char.IsLower(next) && current == char.ToUpper(next))
                || (char.IsUpper(next) && char.IsLower(current) && next == char.ToUpper(current));
        }
    }
}
