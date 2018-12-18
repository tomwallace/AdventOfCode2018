using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace AdventOfCode2018.Eighteen
{
    public class DayEighteen : IAdventProblemSet
    {
        public string Description()
        {
            return "Settlers of The North Pole";
        }

        public int SortOrder()
        {
            return 18;
        }

        public string PartA()
        {
            string filePath = @"Eighteen\DayEighteenInput.txt";
            int resourceValue = FindResourceValueAfterMinutes(filePath, 10);
            return resourceValue.ToString();
        }

        public string PartB()
        {
            string filePath = @"Eighteen\DayEighteenInput.txt";
            // First duplication after 577, and repeats every 28 steps - figured out by dumping into excel.  Similar to the plant problem in day 12
            int remainder = (1000000000 - 577) % 28;
            // That remainder has to be added to the unique 577 ones
            int resourceValue = FindResourceValueAfterMinutes(filePath, 577 + remainder);

            return resourceValue.ToString();
        }

        public int FindResourceValueAfterMinutes(string filePath, int minutes)
        {
            char[,] forest = ParseForest(filePath);

            for (int m = 0; m < minutes; m++)
            {
                char[,] copy = (char[,])forest.Clone();
                for (int x = 0; x < forest.GetLength(0); x++)
                {
                    for (int y = 0; y < forest.GetLength(1); y++)
                    {
                        copy[x, y] = FindNewValue(x, y, forest);
                    }
                }

                forest = copy;

                Debug.WriteLine(DetermineResourceValue(forest));
            }

            return DetermineResourceValue(forest);
        }

        private int DetermineResourceValue(char[,] forest)
        {
            int trees = 0;
            int lumberYards = 0;
            for (int x = 0; x < forest.GetLength(0); x++)
            {
                for (int y = 0; y < forest.GetLength(1); y++)
                {
                    if (forest[x, y] == '#')
                        lumberYards++;
                    if (forest[x, y] == '|')
                        trees++;
                }
            }

            return trees * lumberYards;
        }

        private char[,] ParseForest(string filePath)
        {
            string line;
            StreamReader file = new StreamReader(filePath);

            List<char[]> temp = new List<char[]>();
            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                temp.Add(line.ToCharArray());
            }
            file.Close();

            char[,] forest = new char[temp.Count, temp[0].Length];
            for (int i = 0; i < temp.Count; i++)
            {
                for (int y = 0; y < temp[0].Length; y++)
                {
                    forest[i, y] = temp[i][y];
                }
            }

            return forest;
        }

        private char FindNewValue(int x, int y, char[,] forest)
        {
            int trees = 0;
            int empty = 0;
            int lumberYard = 0;
            for (int counterX = x - 1; counterX <= x + 1; counterX++)
            {
                for (int counterY = y - 1; counterY <= y + 1; counterY++)
                {
                    // Ignore self
                    if (counterX == x && counterY == y) { }
                    // Ignore invalid indexes
                    else if (counterX < 0 || counterX >= forest.GetLength(0) || counterY < 0 ||
                             counterY >= forest.GetLength(1))
                    {
                    }
                    else
                    {
                        if (forest[counterX, counterY] == '#')
                            lumberYard++;
                        if (forest[counterX, counterY] == '|')
                            trees++;
                        if (forest[counterX, counterY] == '.')
                            empty++;
                    }
                }
            }

            if (forest[x, y] == '.' && trees >= 3)
                return '|';

            if (forest[x, y] == '|' && lumberYard >= 3)
                return '#';

            if (forest[x, y] == '#' && lumberYard >= 1 && trees >= 1)
                return '#';

            if (forest[x, y] == '#')
                return '.';

            // otherwise state does not change
            return forest[x, y];
        }
    }
}