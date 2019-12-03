using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = File.ReadAllLines("input.txt")
                .Select(l => l.Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => ParseLogEntry(l))
                .OrderBy(l => l.Time)
                .ToList();

            AssignGuardIds(items);
            Dictionary<int, List<GuardSleep>> sleepEntries = new Dictionary<int, List<GuardSleep>>();
            LoadSleepEntries(items, sleepEntries);
            var sleepestGuard = sleepEntries
                .OrderByDescending(se => se.Value.Sum(e => e.Length))
                .First();
            var bestMinute = Enumerable.Range(0, 60)
                .OrderByDescending(i => sleepestGuard.Value.Count(e => e.Contains(i))).First();
            Console.WriteLine(sleepestGuard.Key * bestMinute);
        }

        static GuardLog ParseLogEntry(string input)
        {
            var splitResult = input.Split(']');
            var time = DateTime.Parse(splitResult[0].Trim().Trim('['));
            GuardEventType eventType = GuardEventType.ShiftStart;
            int id = 0;
            if(splitResult[1].Trim() == "falls asleep")
                eventType = GuardEventType.FallAsleep;
            else if(splitResult[1].Trim() == "wakes up")
                eventType = GuardEventType.WakeUp;
            else 
            {
                var indexOfHash = splitResult[1].IndexOf('#');
                var endOfId = splitResult[1].IndexOf(' ', indexOfHash);
                id = int.Parse(splitResult[1].Substring(indexOfHash+1, endOfId - indexOfHash));
            }
            return new GuardLog 
            {
                Time = time,
                EventType = eventType,
                GuardId = id
            };
        }

        static void AssignGuardIds(List<GuardLog> entries)
        {
            int lastId = 0;
            foreach(var e in entries)
            {
                if(e.EventType == GuardEventType.ShiftStart) 
                    lastId = e.GuardId;
                else
                    e.GuardId = lastId;
            }
        }

        static void LoadSleepEntries(List<GuardLog> entries, Dictionary<int, List<GuardSleep>> sleepEntries)
        {
            var sleepStart = 0;
            foreach(var e in entries)
            {
                if(e.EventType == GuardEventType.FallAsleep)
                    sleepStart = e.Time.Minute;
                else if(e.EventType == GuardEventType.WakeUp)
                {
                    var se = new GuardSleep
                    {
                        MinuteStart = sleepStart,
                        MinuteStop = e.Time.Minute
                    };
                    if(sleepEntries.ContainsKey(e.GuardId))
                        sleepEntries[e.GuardId].Add(se);
                    else
                        sleepEntries.Add(e.GuardId, new List<GuardSleep>() { se });
                }
            }
        }
    }
}
