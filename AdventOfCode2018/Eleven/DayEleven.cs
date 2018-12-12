namespace AdventOfCode2018.Eleven
{
    public class DayEleven : IAdventProblemSet
    {
        public string Description()
        {
            return "Chronal Charge";
        }

        public int SortOrder()
        {
            return 11;
        }

        public string PartA()
        {
            int serialNumber = 1309;
            return FindLargestThreeByThreePowerLevel(serialNumber, 3).Coords;
        }

        public string PartB()
        {
            int serialNumber = 1309;
            return FindLargestGroupPowerLevel(serialNumber);
        }

        public string FindLargestGroupPowerLevel(int serialNumber)
        {
            int highestTotal = 0;
            string coords = "";
            for (int squareSize = 1; squareSize <= 300; squareSize++)
            {
                var result = FindLargestThreeByThreePowerLevel(serialNumber, squareSize);
                if (result.PowerLevel > highestTotal)
                {
                    highestTotal = result.PowerLevel;
                    coords = result.Coords + $",{squareSize}";
                }
            }

            return coords;
        }

        public PowerGridResult FindLargestThreeByThreePowerLevel(int serialNumber, int squareSize)
        {
            int[,] grid = CreatePowerGrid(serialNumber);

            int highestTotal = 0;
            string coords = "";

            for (int x = 0; x < (300 - squareSize); x++)
            {
                for (int y = 0; y < (300 - squareSize); y++)
                {
                    int totalLoop = 0;
                    for (int xLoop = x; xLoop < (x + squareSize); xLoop++)
                    {
                        for (int yLoop = y; yLoop < (y + squareSize); yLoop++)
                        {
                            totalLoop += grid[xLoop, yLoop];
                        }
                    }
                    //// NW
                    //int nw = grid[x - 1, y + 1];
                    //int n = grid[x, y + 1];
                    //int ne = grid[x + 1, y + 1];
                    //int e = grid[x + 1, y];
                    //int se = grid[x + 1, y - 1];
                    //int s = grid[x, y - 1];
                    //int sw = grid[x - 1, y - 1];
                    //int c = grid[x, y];

                    //int total = nw + n + ne + e + se + s + sw + c;

                    if (totalLoop > highestTotal)
                    {
                        highestTotal = totalLoop;
                        coords = $"{x + 1},{y + 1}";
                    }
                }
            }

            return new PowerGridResult() { Coords = coords, PowerLevel = highestTotal };
        }

        private int[,] CreatePowerGrid(int serialNumber)
        {
            int[,] grid = new int[300, 300];

            for (int x = 1; x <= 300; x++)
            {
                for (int y = 1; y <= 300; y++)
                {
                    grid[x - 1, y - 1] = DeterminePowerLevel(x, y, serialNumber);
                }
            }

            return grid;
        }

        public int DeterminePowerLevel(int x, int y, int serialNumber)
        {
            int rackId = x + 10;
            int powerLevel = rackId * y;
            int adjustForSerial = powerLevel + serialNumber;
            int adjustForPowerLevel = adjustForSerial * rackId;
            int hundredsDigit = (adjustForPowerLevel / 100) % 10;
            return hundredsDigit - 5;
        }
    }

    public class PowerGridResult
    {
        public string Coords { get; set; }

        public int PowerLevel { get; set; }
    }
}