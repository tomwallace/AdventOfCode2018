using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Nine
{
    public class DayNine : IAdventProblemSet
    {
        public string Description()
        {
            return "Marble Mania";
        }

        public int SortOrder()
        {
            return 9;
        }

        public string PartA()
        {
            long highScore = FindWinningScore(71617, 416);
            return highScore.ToString();
        }

        public string PartB()
        {
            long highScore = FindWinningScore(7161700, 416);
            return highScore.ToString();
        }

        public long FindWinningScore(int numberOfMarbles, int numberOfPlayers)
        {
            long[] players = new long[numberOfPlayers];
            int currentMarbleId = 1;
            int currentPlayer = 1;

            Marble currentMarble = new Marble();
            currentMarble.Id = 0;
            currentMarble.Left = currentMarble;
            currentMarble.Right = currentMarble;

            do
            {
                if ((currentMarbleId % 23) == 0)
                {
                    players[currentPlayer] += currentMarbleId;

                    // Move counterclockwise and score that marble
                    for (int i = 0; i < 7; i++)
                    {
                        currentMarble = currentMarble.Left;
                    }
                    players[currentPlayer] += currentMarble.Id;

                    // Remove that marble from play
                    currentMarble.Left.Right = currentMarble.Right;
                    currentMarble.Right.Left = currentMarble.Left;
                    currentMarble = currentMarble.Right;
                }
                else
                {
                    // Insert new marble
                    currentMarble = currentMarble.Right;
                    Marble newMarble = new Marble();
                    newMarble.Id = currentMarbleId;
                    newMarble.Left = currentMarble;
                    newMarble.Right = currentMarble.Right;
                    currentMarble.Right.Left = newMarble;
                    currentMarble.Right = newMarble;

                    currentMarble = newMarble;
                }

                // Move to next round
                currentMarbleId++;
                currentPlayer++;
                if (currentPlayer == players.Length)
                    currentPlayer = 0;
            } while (currentMarbleId < numberOfMarbles);

            List<long> sortedScores = players.OrderByDescending(s => s).ToList();
            return sortedScores.FirstOrDefault();
        }
    }

    public class Marble
    {
        public int Id { get; set; }

        public Marble Left { get; set; }

        public Marble Right { get; set; }
    }
}