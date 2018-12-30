using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2018.TwentyFive
{
    public class DayTwentyFive : IAdventProblemSet
    {
        public string Description()
        {
            return "Four-Dimensional Adventure";
        }

        public int SortOrder()
        {
            return 25;
        }

        public string PartA()
        {
            string filePath = @"TwentyFive\DayTwentyFiveInput.txt";
            int number = FindNumberOfConstellations(filePath);
            return number.ToString();
        }

        public string PartB()
        {
            return "No Part B for Day 25!";
        }

        public int FindNumberOfConstellations(string filePath)
        {
            List<SpaceTimePoint> points = ParseSpaceTime(filePath);
            int constellations = 0;

            List<int> allTried = new List<int>();
            while (true)
            {
                List<int> tried = new List<int>();
                Queue<int> pointsToCheck = new Queue<int>();
                for (int i = 0; i < points.Count; i++)
                {
                    if (!allTried.Contains(i))
                    {
                        pointsToCheck.Enqueue(i);
                        break;
                    }
                }
                while (pointsToCheck.Count > 0)
                {
                    int currentIndex = pointsToCheck.Dequeue();
                    if (allTried.Contains(currentIndex))
                        continue;

                    tried.Add(currentIndex);
                    allTried.Add(currentIndex);
                    for (int i = 0; i < points.Count; i++)
                    {
                        if (!tried.Contains(i) && !allTried.Contains(i))
                        {
                            if ((GetDistance(points[i], points[currentIndex])) <= 3)
                            {
                                pointsToCheck.Enqueue(i);
                            }
                        }
                    }
                }
                if (tried.Count == 0)
                {
                    break;
                }
                constellations++;
            }

            return constellations;
        }

        private int GetDistance(SpaceTimePoint pointOne, SpaceTimePoint pointTwo)
        {
            return Math.Abs(pointOne.X - pointTwo.X) + Math.Abs(pointOne.Y - pointTwo.Y) + Math.Abs(pointOne.Z - pointTwo.Z) + Math.Abs(pointOne.T - pointTwo.T);
        }

        private List<SpaceTimePoint> ParseSpaceTime(string filePath)
        {
            List<SpaceTimePoint> points = new List<SpaceTimePoint>();
            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                string[] split = line.Split(',');
                SpaceTimePoint point = new SpaceTimePoint(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3]));
                points.Add(point);
            }
            file.Close();

            return points;
        }
    }

    public class SpaceTimePoint
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public int T { get; set; }

        public SpaceTimePoint(int x, int y, int z, int t)
        {
            X = x;
            Y = y;
            Z = z;
            T = t;
        }
    }
}