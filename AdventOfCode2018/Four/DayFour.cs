using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018.Four
{
    public class DayFour : IAdventProblemSet
    {
        public string Description()
        {
            return "Repose Record";
        }

        public int SortOrder()
        {
            return 4;
        }

        public string PartA()
        {
            string filePath = @"Four\DayFourInput.txt";
            int factor = DetermineMostAsleepGuardFactor(filePath);
            return factor.ToString();
        }

        public string PartB()
        {
            string filePath = @"Four\DayFourInput.txt";
            int factor = DetermineMinuteMostAsleepFactor(filePath);
            return factor.ToString();
        }

        public int DetermineMinuteMostAsleepFactor(string filePath)
        {
            List<Guard> guards = CreateGuardsFromLogs(filePath);
            List<Guard> sortedGuards = guards.OrderByDescending(g => g.NumberOfTimesAsleepAtMinute).ToList();

            Guard selectedGuard = sortedGuards[0];
            return selectedGuard.Id * selectedGuard.MinuteMostAsleep;
        }

        public int DetermineMostAsleepGuardFactor(string filePath)
        {
            List<Guard> guards = CreateGuardsFromLogs(filePath);
            List<Guard> sortedGuards = guards.OrderByDescending(g => g.TotalAsleep).ToList();

            Guard selectedGuard = sortedGuards[0];
            return selectedGuard.Id * selectedGuard.MinuteMostAsleep;
        }

        private List<Guard> CreateGuardsFromLogs(string filePath)
        {
            List<GuardLogInput> sortedLogs = ParseGuardLogInputs(filePath);
            List<Guard> guards = new List<Guard>();

            int id = -1;
            int minFellAlseep = -1;
            int minAwake = -1;

            foreach (GuardLogInput log in sortedLogs)
            {
                if (log.LogEntry.Contains("#"))
                {
                    string[] split = log.LogEntry.Split('#');
                    string[] splitSpace = split[1].Split(' ');

                    // Entry about a guard ID
                    id = int.Parse(splitSpace[0]);

                    // If guard does not exist
                    if (guards.All(g => g.Id != id))
                    {
                        Guard guard = new Guard()
                        {
                            Id = id,
                            TotalAsleep = 0,
                            MinutesAsleep = new List<int>()
                        };
                        guards.Add(guard);
                    }
                }
                else if (log.LogEntry.Contains("asleep"))
                {
                    minFellAlseep = log.LogDateTime.Minute;
                }
                else if (log.LogEntry.Contains("wakes"))
                {
                    // Error checking
                    if (id == -1 || minFellAlseep == -1)
                        throw new ArgumentException("Parsed logs order is wrong");

                    minAwake = log.LogDateTime.Minute;
                    // Update record
                    Guard guard = guards.FirstOrDefault(g => g.Id == id);
                    if (guard == null)
                        throw new ArgumentException("Guard does not exist.  Order of log processing is wrong");

                    int amountSlept = minAwake - minFellAlseep;
                    guard.TotalAsleep += amountSlept;
                    guard.MinutesAsleep.AddRange(Enumerable.Range(minFellAlseep, amountSlept));

                    // Reset variables
                    minFellAlseep = -1;
                    minAwake = -1;
                }
                else
                {
                    // Should never get here
                    throw new ArgumentException("Received a log entry that is not recognized");
                }
            }

            // Calculate minute most asleep
            foreach (Guard guard in guards)
            {
                int mostAsleepMinute =
                guard.MinutesAsleep.GroupBy(x => x)
                    .OrderByDescending(group => group.Count())
                    .Select(group => group.Key)
                    .FirstOrDefault();

                int mostAsleepMinuteTimes =
                guard.MinutesAsleep.GroupBy(x => x)
                    .OrderByDescending(group => group.Count())
                    .Select(group => group.Count())
                    .FirstOrDefault();

                guard.MinuteMostAsleep = mostAsleepMinute;
                guard.NumberOfTimesAsleepAtMinute = mostAsleepMinuteTimes;
            }

            return guards;
        }

        private List<GuardLogInput> ParseGuardLogInputs(string filePath)
        {
            List<GuardLogInput> logs = new List<GuardLogInput>();
            List<string> lines = GetLines(filePath);

            foreach (string line in lines)
            {
                string[] splits = line.Split(new string[] { "] " }, StringSplitOptions.None);
                DateTime logDateTime = DateTime.Parse(splits[0].Replace("[", ""));
                GuardLogInput log = new GuardLogInput()
                {
                    LogDateTime = logDateTime,
                    LogEntry = splits[1]
                };
                logs.Add(log);
            }

            // sort by time
            List<GuardLogInput> sortedLogs = logs.OrderBy(l => l.LogDateTime).ToList();

            return sortedLogs;
        }

        private List<string> GetLines(string filePath)
        {
            List<string> splitInts = new List<string>();
            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                splitInts.Add(line.Trim());
            }
            file.Close();
            return splitInts;
        }
    }

    public class GuardLogInput
    {
        public DateTime LogDateTime { get; set; }

        public string LogEntry { get; set; }
    }

    public class Guard
    {
        public int Id { get; set; }

        public int TotalAsleep { get; set; }

        public List<int> MinutesAsleep { get; set; }

        public int MinuteMostAsleep { get; set; }

        public int NumberOfTimesAsleepAtMinute { get; set; }
    }
}