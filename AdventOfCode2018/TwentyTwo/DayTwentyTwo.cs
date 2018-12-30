using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode2018.TwentyTwo
{
    public class DayTwentyTwo : IAdventProblemSet
    {
        public string Description()
        {
            return "Mode Maze";
        }

        public int SortOrder()
        {
            return 22;
        }

        public string PartA()
        {
            int riskFactor = DetermineRiskFactor(5355, 14, 796);
            return riskFactor.ToString();
        }

        public string PartB()
        {
            int bestTime = FindBestTimeThroughCave(5355, 14, 796);
            return bestTime.ToString();
        }

        public int DetermineRiskFactor(int caveDepth, int targetX, int targetY)
        {
            int risk = 0;
            for (int y = 0; y <= targetY; y++)
            {
                for (int x = 0; x <= targetX; x++)
                {
                    int erosionLevel = CalculateErosionLevel(x, y, targetX, targetY, caveDepth);
                    int riskLevel = DetermineRiskLevel(erosionLevel);
                    risk += riskLevel;
                }
            }

            return risk;
        }

        public int FindBestTimeThroughCave(int caveDepth, int targetX, int targetY)
        {
            int bestTime = int.MaxValue;
            // I struggled with this one because I wanted to use constructed strings instead of custom classes for the Hashset
            // but then I did not separate the values in the strings with commas, so it was mismatching the values that overlapped
            // This made me lose hours of work.
            HashSet<string> stepsCovered = new HashSet<string>();

            Queue<JourneyStep> queue = new Queue<JourneyStep>();
            JourneyStep start = new JourneyStep()
            {
                X = 0,
                Y = 0,
                Time = 0,
                Equipment = 2,
                CurrentType = ".",
                Switching = 0
            };
            queue.Enqueue(start);
            stepsCovered.Add("0,0,2");

            do
            {
                JourneyStep currentStep = queue.Dequeue();

                // Handle switching
                if (currentStep.Switching > 0)
                {
                    if (currentStep.Switching != 1 ||
                        stepsCovered.Add($"{currentStep.X},{currentStep.Y},{currentStep.Equipment}"))
                    {
                        JourneyStep newStep = new JourneyStep()
                        {
                            X = currentStep.X,
                            Y = currentStep.Y,
                            Time = currentStep.Time + 1,
                            Switching = currentStep.Switching - 1,
                            Equipment = currentStep.Equipment,
                            CurrentType = currentStep.CurrentType
                        };
                        queue.Enqueue(newStep);
                    }
                    continue;
                }

                // If the currentStep time is > best time, then discard
                if (currentStep.Time > bestTime)
                    continue;

                // We have reached the target
                if (currentStep.X == targetX && currentStep.Y == targetY)
                {
                    int modTime = currentStep.Equipment == 2 ? currentStep.Time : currentStep.Time + 7;
                    if (modTime < bestTime)
                        bestTime = modTime;

                    break;
                }
                // Add next options
                List<JourneyStep> options = GetNextOptions(currentStep, caveDepth, targetX, targetY, stepsCovered);
                foreach (JourneyStep option in options)
                {
                    queue.Enqueue(option);
                }
            } while (queue.Count > 0);

            return bestTime;
        }

        private List<JourneyStep> GetNextOptions(JourneyStep current, int caveDepth, int targetX, int targetY, HashSet<string> stepsCovered)
        {
            List<JourneyStep> options = new List<JourneyStep>();

            int[] xMods = new[] { 0, 1, 0, -1 };
            int[] yMods = new[] { -1, 0, 1, 0 };

            for (int i = 0; i < 4; i++)
            {
                int x = current.X + xMods[i];
                int y = current.Y + yMods[i];

                if (x >= 0 && y >= 0)
                {
                    int targetErosionLevel = CalculateErosionLevel(x, y, targetX, targetY, caveDepth);
                    string targetSoilType = DetermineType(targetErosionLevel);
                    List<int> targetEquipment = EquipmentAllowed(targetSoilType);
                    if (targetEquipment.Contains(current.Equipment) && stepsCovered.Add($"{x},{y},{current.Equipment}"))
                    {
                        JourneyStep newStep = new JourneyStep()
                        {
                            X = x,
                            Y = y,
                            Time = current.Time + 1,
                            Switching = 0,
                            Equipment = current.Equipment,
                            CurrentType = targetSoilType
                        };

                        options.Add(newStep);
                    }
                }

                // Add other allowed tool option
                foreach (int otherTool in EquipmentAllowed(current.CurrentType))
                {
                    if (otherTool != current.Equipment)
                    {
                        JourneyStep newStep = new JourneyStep()
                        {
                            X = current.X,
                            Y = current.Y,
                            Time = current.Time + 1,
                            Switching = 6,
                            Equipment = otherTool,
                            CurrentType = current.CurrentType
                        };

                        options.Add(newStep);
                    }
                }
            }

            return options;
        }

        private List<int> EquipmentAllowed(string type)
        {
            switch (type)
            {
                case ".":
                    return new List<int>() { 1, 2 };

                case "=":
                    return new List<int>() { 1, 0 };

                case "|":
                    return new List<int>() { 2, 0 };
            }

            throw new ArgumentException("Should never get here");
        }

        private Dictionary<string, int> _erosionLevel = new Dictionary<string, int>();

        private int CalculateErosionLevel(int x, int y, int targetX, int targetY, int caveDepth)
        {
            string key = $"{x},{y}";
            if (_erosionLevel.ContainsKey(key))
                return _erosionLevel[key];

            int value = 0;
            if ((x == 0 && y == 0) || (x == targetX && y == targetY))
                value = 0;
            else if (y == 0)
                value = x * 16807;
            else if (x == 0)
                value = y * 48271;

            // Otherwise, the region's geologic index is the result of multiplying the erosion levels of the regions at X-1,Y and X,Y-1
            else value = CalculateErosionLevel(x - 1, y, targetX, targetY, caveDepth) * CalculateErosionLevel(x, y - 1, targetX, targetY, caveDepth);

            value = (value + caveDepth) % 20183;
            _erosionLevel.Add(key, value);

            return value;
        }

        private string DetermineType(int erosionLevel)
        {
            switch (erosionLevel % 3)
            {
                case 2:
                    return "|";

                case 1:
                    return "=";

                case 0:
                    return ".";
            }

            throw new ArgumentException("Should never reach here");
        }

        private int DetermineRiskLevel(int erosionLevel)
        {
            return erosionLevel % 3;
        }

        private void PrintCave(List<List<CaveSegment>> cave)
        {
            for (int y = 0; y < cave[0].Count; y++)
            {
                StringBuilder builder = new StringBuilder();
                for (int x = 0; x < cave.Count; x++)
                {
                    builder.Append(cave[x][y].SoilType);
                }
                Debug.WriteLine(builder.ToString());
            }
        }
    }

    public class CaveSegment
    {
        public int GeologicIndex { get; set; }

        public int ErosionLevel { get; set; }

        public string SoilType { get; set; }

        public int RiskLevel { get; set; }

        public override string ToString()
        {
            return RiskLevel.ToString();
        }
    }

    public class JourneyStep
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Time { get; set; }

        // 2 = torch, 1 = climbing gear, 0 = neither
        public int Equipment { get; set; }

        public string CurrentType { get; set; }

        public int Switching { get; set; }
    }
}