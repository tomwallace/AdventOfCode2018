using System.IO;

namespace AdventOfCode2018.Seventeen
{
    public class DaySeventeen : IAdventProblemSet
    {
        public string Description()
        {
            return "Reservoir Research (HARD)";
        }

        public int SortOrder()
        {
            return 17;
        }

        public string PartA()
        {
            string filePath = @"Seventeen\DaySeventeenInput.txt";
            int waterVolume = DetermineWaterVolume(filePath);
            return waterVolume.ToString();
        }

        public string PartB()
        {
            string filePath = @"Seventeen\DaySeventeenInput.txt";
            int waterVolume = DetermineWaterVolumeWhenSpringRunsDry(filePath);
            return waterVolume.ToString();
        }

        public int DetermineWaterVolume(string filePath)
        {
            Geology geology = CreateStrata(filePath);

            var springX = 500;
            var springY = 0;

            // fill with water
            GoDown(springX, springY, geology);

            // count spaces with water
            var waterVolume = 0;
            for (int y = geology.MinY; y < geology.Strata.GetLength(1); y++)
            {
                for (int x = 0; x < geology.Strata.GetLength(0); x++)
                {
                    if (geology.Strata[x, y] == 'W' || geology.Strata[x, y] == '|')
                        waterVolume++;
                }
            }

            return waterVolume;
        }

        public int DetermineWaterVolumeWhenSpringRunsDry(string filePath)
        {
            Geology geology = CreateStrata(filePath);

            var springX = 500;
            var springY = 0;

            // fill with water
            GoDown(springX, springY, geology);

            // count spaces with water
            var waterVolume = 0;
            for (int y = geology.MinY; y < geology.Strata.GetLength(1); y++)
            {
                for (int x = 0; x < geology.Strata.GetLength(0); x++)
                {
                    if (geology.Strata[x, y] == 'W')
                        waterVolume++;
                }
            }

            return waterVolume;
        }

        private Geology CreateStrata(string filePath)
        {
            var x = 2000;
            var y = 2000;
            int maxY = 0;
            int minY = int.MaxValue;

            char[,] strata = new char[x, y];

            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                var l = line.Split(new[] { '=', ',', '.' });

                if (l[0] == "x")
                {
                    x = int.Parse(l[1]);
                    y = int.Parse(l[3]);
                    var len = int.Parse(l[5]);
                    for (var a = y; a <= len; a++)
                    {
                        strata[x, a] = '#';
                    }
                }
                else
                {
                    y = int.Parse(l[1]);
                    x = int.Parse(l[3]);
                    var len = int.Parse(l[5]);
                    for (var a = x; a <= len; a++)
                    {
                        strata[a, y] = '#';
                    }
                }

                if (y > maxY)
                {
                    maxY = y;
                }

                if (y < minY)
                {
                    minY = y;
                }
            }
            file.Close();
            return new Geology()
            {
                Strata = strata,
                MinY = minY,
                MaxY = maxY
            };
        }

        private bool SpaceTaken(int x, int y, char[,] strata)
        {
            return strata[x, y] == '#' || strata[x, y] == 'W';
        }

        private void GoDown(int x, int y, Geology geology)
        {
            geology.Strata[x, y] = '|';
            while (geology.Strata[x, y + 1] != '#' && geology.Strata[x, y + 1] != 'W')
            {
                y++;
                if (y > geology.MaxY)
                {
                    return;
                }
                geology.Strata[x, y] = '|';
            };

            do
            {
                bool goDownLeft = false;
                bool goDownRight = false;

                // find boundaries
                int minX;
                for (minX = x; minX >= 0; minX--)
                {
                    if (SpaceTaken(minX, y + 1, geology.Strata) == false)
                    {
                        goDownLeft = true;
                        break;
                    }

                    geology.Strata[minX, y] = '|';

                    if (SpaceTaken(minX - 1, y, geology.Strata))
                    {
                        break;
                    }
                }

                int maxX;
                for (maxX = x; maxX < geology.Strata.GetLength(0); maxX++)
                {
                    if (SpaceTaken(maxX, y + 1, geology.Strata) == false)
                    {
                        goDownRight = true;

                        break;
                    }

                    geology.Strata[maxX, y] = '|';

                    if (SpaceTaken(maxX + 1, y, geology.Strata))
                    {
                        break;
                    }
                }

                // handle water falling
                if (goDownLeft)
                {
                    if (geology.Strata[minX, y] != '|')
                        GoDown(minX, y, geology);
                }

                if (goDownRight)
                {
                    if (geology.Strata[maxX, y] != '|')
                        GoDown(maxX, y, geology);
                }

                if (goDownLeft || goDownRight)
                {
                    return;
                }

                // fill row
                for (int a = minX; a < maxX + 1; a++)
                {
                    geology.Strata[a, y] = 'W';
                }

                y--;
            }
            while (true);
        }
    }

    public class Geology
    {
        public char[,] Strata { get; set; }

        public int MaxY { get; set; }

        public int MinY { get; set; }
    }
}