using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2018.Three
{
    public class DayThree : IAdventProblemSet
    {
        private HashSet<int>[,] _grid;
        private HashSet<int> _ids;

        public DayThree()
        {
            _grid = new HashSet<int>[9999, 9999];
            _ids = new HashSet<int>();
        }

        public string Description()
        {
            return "No Matter How You Slice It";
        }

        public int SortOrder()
        {
            return 3;
        }

        public string PartA()
        {
            string filePath = @"Three\DayThreeInput.txt";
            int squareInches = SquareInchesOfFabricWithTwoOrMoreClaims(filePath);
            return squareInches.ToString();
        }

        public string PartB()
        {
            string filePath = @"Three\DayThreeInput.txt";
            int id = GetIdOfUnoverlappingClaim(filePath);
            return id.ToString();
        }

        public int SquareInchesOfFabricWithTwoOrMoreClaims(string filePath)
        {
            ParseLines(filePath);

            int matchingInches = 0;

            for (int x = 0; x < 9999; x++)
            {
                for (int y = 0; y < 9999; y++)
                {
                    if (_grid[x, y] != null && _grid[x, y].Count >= 2)
                    {
                        matchingInches++;
                    }
                }
            }

            return matchingInches;
        }

        public int GetIdOfUnoverlappingClaim(string filePath)
        {
            ParseLines(filePath);

            int matchingInches = 0;
            foreach (int id in _ids)
            {
                bool isOverlapping = DoesIdOverlap(id);
                if (!isOverlapping)
                    return id;
            }

            // should never reach
            throw new ArgumentException("All claims overlap");
        }

        private bool DoesIdOverlap(int id)
        {
            for (int x = 0; x < 9999; x++)
            {
                for (int y = 0; y < 9999; y++)
                {
                    if (_grid[x, y] != null && _grid[x, y].Count >= 2 && _grid[x, y].Contains(id))
                    {
                        // The claim is overlapping
                        return true;
                    }
                }
            }

            // Did not overlap
            return false;
        }

        private void ParseLines(string filePath)
        {
            List<string> lines = GetLines(filePath);
            foreach (string line in lines)
            {
                // ex: #1201 @ 776,404: 19x25
                string[] splitAt = line.Split('@');
                string[] splitHash = splitAt[0].Trim().Split('#');
                string[] splitColon = splitAt[1].Split(':');
                string[] splitComma = splitColon[0].Trim().Split(',');

                int id = int.Parse(splitHash[1]);
                _ids.Add(id);

                int coordX = int.Parse(splitComma[0]);
                int coordY = int.Parse(splitComma[1]);

                string[] splitX = splitColon[1].Split('x');
                int lengthX = int.Parse(splitX[0]);
                int lengthY = int.Parse(splitX[1]);

                // Update Grid
                for (int x = coordX; x < (coordX + lengthX); x++)
                {
                    for (int y = coordY; y < (coordY + lengthY); y++)
                    {
                        if (_grid[x, y] == null)
                            _grid[x, y] = new HashSet<int>();

                        _grid[x, y].Add(id);
                    }
                }
            }
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
}