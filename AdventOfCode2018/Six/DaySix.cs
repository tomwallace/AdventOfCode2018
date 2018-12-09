using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018.Six
{
    public class DaySix : IAdventProblemSet
    {
        public string Description()
        {
            return "Chronal Coordinates";
        }

        public int SortOrder()
        {
            return 6;
        }

        // I struggled with PartA a great deal because I was not handling the locations that touched the outside of the grid properly.
        public string PartA()
        {
            string filePath = @"Six\DaySixInput.txt";
            int largest = FindLargestArea(filePath);
            return largest.ToString();
        }

        public string PartB()
        {
            string filePath = @"Six\DaySixInput.txt";
            int totalSize = FindSizeOfTargetArea(filePath, 10000);
            return totalSize.ToString();
        }

        public int FindLargestArea(string fileName)
        {
            Dictionary<int, Coordinate> coords = GetCoords(fileName);

            int[,] grid = CreateGrid(coords);

            List<int> idsNearEdge = new List<int>();

            // Fill the grid
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    int closestDistance = int.MaxValue;
                    int closestId = -1;
                    bool overlap = false;

                    foreach (var coord in coords)
                    {
                        int distance = GetManhattanDistance(x, coord.Value.X, y, coord.Value.Y);
                        if (distance < closestDistance)
                        {
                            closestDistance = distance;
                            closestId = coord.Key;
                            overlap = false;
                        }
                        else if (distance == closestDistance)
                        {
                            overlap = true;
                        }
                    }

                    if (x <= 0 || y <= 0 || x >= grid.GetUpperBound(0) || y >= grid.GetUpperBound(1))
                    {
                        idsNearEdge.Add(closestId);
                    }
                    grid[x, y] = overlap ? -1 : closestId;
                }
            }

            // Determine which grid has the most values
            int[] countedValues = new int[coords.Count + 1];
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    if (grid[x, y] > 0)
                    {
                        countedValues[grid[x, y]]++;
                    }
                }
            }

            foreach (int edgeId in idsNearEdge.Distinct())
            {
                countedValues[edgeId] = -1;
            }

            var sorted = countedValues.OrderByDescending(x => x).ToList();
            return sorted.FirstOrDefault();
        }

        public int FindSizeOfTargetArea(string fileName, int totalDistanceMin)
        {
            Dictionary<int, Coordinate> coords = GetCoords(fileName);

            int[,] grid = CreateGrid(coords);

            int locationsMeetingRequirements = 0;

            List<int> idsNearEdge = new List<int>();

            // Fill the grid
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    int totalDistance = 0;

                    foreach (var coord in coords)
                    {
                        int distance = GetManhattanDistance(x, coord.Value.X, y, coord.Value.Y);
                        totalDistance += distance;
                    }

                    if (totalDistance < totalDistanceMin)
                        locationsMeetingRequirements++;
                }
            }

            return locationsMeetingRequirements;
        }

        private int[,] CreateGrid(Dictionary<int, Coordinate> coords)
        {
            int largestX = coords.GroupBy(c => c.Value.X).OrderByDescending(group => group.Key).Select(group => group.Key).First();
            int largestY = coords.GroupBy(c => c.Value.Y).OrderByDescending(group => group.Key).Select(group => group.Key).First();

            return new int[largestX + 1, largestY + 1];
        }

        private int GetManhattanDistance(int firstX, int secondX, int firstY, int secondY)
        {
            int dist = Math.Abs(firstX - secondX) + Math.Abs(firstY - secondY);
            return dist;
        }

        private Dictionary<int, Coordinate> GetCoords(string filePath)
        {
            Dictionary<int, Coordinate> coords = new Dictionary<int, Coordinate>();
            int id = 1;
            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                string[] split = line.Split(',');
                int x = int.Parse(split[0].Trim());
                int y = int.Parse(split[1].Trim());
                Coordinate coord = new Coordinate()
                {
                    X = x,
                    Y = y,
                    IdOfClosest = -1
                };

                coords.Add(id, coord);
                id++;
            }
            file.Close();
            return coords;
        }
    }

    public class Coordinate
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int IdOfClosest { get; set; }
    }
}