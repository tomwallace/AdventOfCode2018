using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.Ten
{
    public class DayTen : IAdventProblemSet
    {
        public string Description()
        {
            return "The Stars Align";
        }

        public int SortOrder()
        {
            return 10;
        }

        public string PartA()
        {
            string filePath = @"Ten\DayTenInput.txt";
            int seconds = FindSecondWhereStarsAlign(filePath);
            return $"RBCZAEPP after {seconds} seconds";
        }

        public string PartB()
        {
            string filePath = @"Ten\DayTenInput.txt";
            int seconds = FindSecondWhereStarsAlign(filePath);
            return seconds.ToString();
        }

        public int FindSecondWhereStarsAlign(string filePath)
        {
            Star[] stars = GetStars(filePath);
            int seconds = 0;
            int numberStarsAligned;

            do
            {
                seconds++;
                numberStarsAligned = 0;

                foreach (Star star in stars)
                {
                    star.Move();
                }

                foreach (Star star in stars)
                {
                    foreach (Star otherStar in stars)
                    {
                        if (star != otherStar && star.IsAdjacent(otherStar))
                        {
                            numberStarsAligned++;
                            break;
                        }
                    }
                }
            } while (numberStarsAligned != stars.Length);

            PrintStarFormation(stars);
            return seconds;
        }

        private void PrintStarFormation(Star[] stars)
        {
            int minX = stars.Min(s => s.PositionX);
            int maxX = stars.Max(s => s.PositionX);
            int minY = stars.Min(s => s.PositionY);
            int maxY = stars.Max(s => s.PositionY);

            for (int y = minY - 1; y <= maxY + 1; y++)
            {
                List<Star> row = stars.Where(s => s.PositionY == y).ToList();
                StringBuilder builder = new StringBuilder();
                for (int x = minX - 1; x <= maxX + 1; x++)
                {
                    if (row.Find(s => s.PositionX == x) != null)
                        builder.Append("#");
                    else
                        builder.Append(".");
                }
                Debug.WriteLine(builder.ToString());
            }
        }

        private Star[] GetStars(string filePath)
        {
            List<Star> stars = new List<Star>();
            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                string[] splitLesserThan = line.Split('<');
                string[] splitPosition = splitLesserThan[1].Split('>');
                string[] splitPositionSpec = splitPosition[0].Split(',');
                int positionX = int.Parse(splitPositionSpec[0].Trim());
                int positionY = int.Parse(splitPositionSpec[1].Trim());

                string[] splitVelocity = splitLesserThan[2].Split('>');
                string[] splitVelocitySpec = splitVelocity[0].Split(',');
                int velocityX = int.Parse(splitVelocitySpec[0].Trim());
                int velocityY = int.Parse(splitVelocitySpec[1].Trim());

                stars.Add(new Star()
                {
                    PositionX = positionX,
                    PositionY = positionY,
                    VelocityX = velocityX,
                    VelocityY = velocityY
                });
            }
            file.Close();
            return stars.ToArray();
        }
    }

    public class Star
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int VelocityX { get; set; }
        public int VelocityY { get; set; }

        public bool IsAdjacent(Star other)
        {
            // NW
            if (PositionX == other.PositionX - 1 && PositionY == other.PositionY + 1)
                return true;
            // N
            if (PositionX == other.PositionX && PositionY == other.PositionY + 1)
                return true;
            // NE
            if (PositionX == other.PositionX + 1 && PositionY == other.PositionY + 1)
                return true;
            // E
            if (PositionX == other.PositionX + 1 && PositionY == other.PositionY)
                return true;
            // SE
            if (PositionX == other.PositionX + 1 && PositionY == other.PositionY - 1)
                return true;
            // S
            if (PositionX == other.PositionX && PositionY == other.PositionY - 1)
                return true;
            // SW
            if (PositionX == other.PositionX - 1 && PositionY == other.PositionY - 1)
                return true;
            // W
            if (PositionX == other.PositionX - 1 && PositionY == other.PositionY)
                return true;

            return false;
        }

        public void Move()
        {
            PositionX = PositionX + VelocityX;
            PositionY = PositionY + VelocityY;
        }

        public override string ToString()
        {
            return $"Star P({PositionX}:{PositionY}) V({VelocityX}:{VelocityY})";
        }
    }
}