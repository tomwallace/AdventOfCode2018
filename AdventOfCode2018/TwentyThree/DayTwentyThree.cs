using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018.TwentyThree
{
    public class DayTwentyThree : IAdventProblemSet
    {
        public string Description()
        {
            return "Experimental Emergency Teleportation (HARD)";
        }

        public int SortOrder()
        {
            return 23;
        }

        public string PartA()
        {
            string filePath = @"TwentyThree\DayTwentyThreeInput.txt";
            long count = NumberOfBotsInRangeOfStrongest(filePath);
            return count.ToString();
        }

        public string PartB()
        {
            string filePath = @"TwentyThree\DayTwentyThreeInput.txt";
            long distance = FindDistanceToOptimumLocation(filePath);
            return distance.ToString();
        }

        public long NumberOfBotsInRangeOfStrongest(string filePath)
        {
            List<Nanobot> nanobots = ParseNanobots(filePath);

            Nanobot strongest = nanobots.OrderByDescending(n => n.SignalRadius).ToList().FirstOrDefault();

            int inRange = 0;

            foreach (Nanobot bot in nanobots)
            {
                if (strongest.DistanceTo(bot) <= strongest.SignalRadius)
                    inRange++;
            }

            return inRange;
        }

        public long FindDistanceToOptimumLocation(string filePath)
        {
            List<Nanobot> nanobots = ParseNanobots(filePath);

            List<long> xs = nanobots.Select(n => n.X).ToList();
            xs.Add(0);
            List<long> ys = nanobots.Select(n => n.Y).ToList();
            ys.Add(0);
            List<long> zs = nanobots.Select(n => n.Z).ToList();
            zs.Add(0);

            // Find starting grid distance outside of X Max
            long distance = 1;
            while (distance < xs.Max() - xs.Min())
                distance *= 2;

            // Loop over gradually decreasing grid distance
            do
            {
                Nanobot bestCoordinate = new Nanobot(0, 0, 0);
                int targetNumberMatched = 0;
                long distanceToBestCoord = 0;

                // Find the best square in that grid
                for (long x = xs.Min(); x <= xs.Max(); x += distance)
                {
                    for (long y = ys.Min(); y <= ys.Max(); y += distance)
                    {
                        for (long z = zs.Min(); z <= zs.Max(); z += distance)
                        {
                            int numberMatched = 0;
                            foreach (Nanobot bot in nanobots)
                            {
                                if (((bot.DistanceTo(x, y, z) - bot.SignalRadius) / distance) <= 0)
                                    numberMatched++;
                            }

                            if (numberMatched > targetNumberMatched)
                            {
                                targetNumberMatched = numberMatched;
                                bestCoordinate = new Nanobot(x, y, z);
                                distanceToBestCoord = Math.Abs(x) + Math.Abs(y) + Math.Abs(z);
                            }
                            else if (numberMatched == targetNumberMatched)
                            {
                                // Handle edge case of clumped bots
                                if (distanceToBestCoord == 0 || Math.Abs(x) + Math.Abs(y) + Math.Abs(z) < distanceToBestCoord)
                                {
                                    bestCoordinate = new Nanobot(x, y, z);
                                    distanceToBestCoord = Math.Abs(x) + Math.Abs(y) + Math.Abs(z);
                                }
                            }
                        }
                    }
                }

                // If we are at "actual" grid size, then we are done
                if (distance == 1)
                {
                    return distanceToBestCoord;
                }

                // Otherwise, decrease grid size and reset lists by adding each Min and Max
                xs.Clear();
                ys.Clear();
                zs.Clear();
                xs.Add(bestCoordinate.X + distance);
                xs.Add(bestCoordinate.X - distance);
                ys.Add(bestCoordinate.Y + distance);
                ys.Add(bestCoordinate.Y - distance);
                zs.Add(bestCoordinate.Z + distance);
                zs.Add(bestCoordinate.Z - distance);

                distance /= 2;
            } while (true);
        }

        private List<Nanobot> ParseNanobots(string filePath)
        {
            List<Nanobot> bots = new List<Nanobot>();
            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                string[] splitGreatThan = line.Split('>');
                string[] splitLessThan = splitGreatThan[0].Split('<');
                string[] position = splitLessThan[1].Split(',');
                string[] splitEquals = splitGreatThan[1].Split('=');

                bots.Add(new Nanobot()
                {
                    X = long.Parse(position[0].Trim()),
                    Y = long.Parse(position[1].Trim()),
                    Z = long.Parse(position[2].Trim()),
                    SignalRadius = long.Parse(splitEquals[1].Trim())
                });
            }
            file.Close();
            return bots;
        }
    }

    public class Nanobot
    {
        public long X { get; set; }

        public long Y { get; set; }

        public long Z { get; set; }

        public long SignalRadius { get; set; }

        public long DistanceTo(Nanobot other)
        {
            return Math.Abs(X - other.X) + Math.Abs(Y - other.Y) + Math.Abs(Z - other.Z);
        }

        public long DistanceTo(long x, long y, long z)
        {
            return Math.Abs(X - x) + Math.Abs(Y - y) + Math.Abs(Z - z);
        }

        public Nanobot(long x, long y, long z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Nanobot()
        {
        }
    }
}