using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018.Thirteen
{
    public class DayThirteen : IAdventProblemSet
    {
        public List<char[]> _tracks;

        public string Description()
        {
            return "Mine Cart Madness (HARD)";
        }

        public int SortOrder()
        {
            return 13;
        }

        public string PartA()
        {
            string filePath = @"Thirteen\DayThirteenInput.txt";
            return FindFirstCollision(filePath);
        }

        public string PartB()
        {
            string filePath = @"Thirteen\DayThirteenInput.txt";
            return FindLocationOfLastCart(filePath);
        }

        public string FindFirstCollision(string filePath)
        {
            List<MineCart> carts = ParseCartTracks(filePath);

            bool collision = false;
            string collisionLocation = "";

            do
            {
                for (int i = 0; i < carts.Count; i++)
                {
                    carts[i].Move(_tracks);
                    var grouped = carts.GroupBy(c => c.Position).OrderByDescending(g => g.Count());
                    if (grouped.First().Count() > 1)
                    {
                        collision = true;
                        collisionLocation = grouped.First().Key.ToString();
                        break;
                    }
                }

                carts = carts.OrderBy(c => c.Position.Y).ThenBy(c => c.Position.X).ToList();
            } while (!collision);

            return collisionLocation;
        }

        public string FindLocationOfLastCart(string filePath)
        {
            List<MineCart> carts = ParseCartTracks(filePath);

            bool solo = false;
            string soloLocation = "";

            do
            {
                for (int i = 0; i < carts.Count; i++)
                {
                    if (!carts[i].Destroyed)
                        carts[i].Move(_tracks);

                    var grouped = carts.Where(c => c.Destroyed == false).GroupBy(c => c.Position).Where(g => g.Count() == 2);
                    foreach (var coord in grouped)
                    {
                        foreach (var mineCart in carts.Where(c => c.Position.ToString() == coord.Key.ToString()))
                        {
                            mineCart.Destroyed = true;
                        }
                    }
                }

                if (carts.Count(c => c.Destroyed == false) == 1)
                {
                    solo = true;
                    soloLocation = carts.First(c => c.Destroyed == false).Position.ToString();
                }

                carts = carts.OrderBy(c => c.Destroyed).ThenBy(c => c.Position.Y).ThenBy(c => c.Position.X).ToList();
            } while (!solo);

            return soloLocation;
        }

        private List<MineCart> ParseCartTracks(string filePath)
        {
            List<char[]> tracks = new List<char[]>();
            List<MineCart> carts = new List<MineCart>();
            string line;
            StreamReader file = new StreamReader(filePath);
            int y = 0;

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                char[] characters = line.ToCharArray();
                if (characters.Contains('^') || characters.Contains('>') || characters.Contains('v') ||
                    characters.Contains('<'))
                {
                    for (int x = 0; x < characters.Length; x++)
                    {
                        if (characters[x] == '^' || characters[x] == '>' || characters[x] == 'v' || characters[x] == '<')
                        {
                            MineCart cart = new MineCart(x, y, characters[x]);
                            carts.Add(cart);
                            characters[x] = '#';
                        }
                    }
                }

                tracks.Add(characters);

                y++;
            }
            file.Close();

            _tracks = tracks;
            return carts;
        }
    }

    public class MineCart
    {
        public MineCart(int x, int y, char pointing)
        {
            Position = new Coordinate(x, y);

            if (pointing == '^')
                Direction = 1;
            if (pointing == '>')
                Direction = 2;
            if (pointing == 'v')
                Direction = 3;
            if (pointing == '<')
                Direction = 4;

            CrossingDecision = 0;
            Destroyed = false;
        }

        public Coordinate Position { get; set; }

        // 1 = N, 2 = E, 3 = S, 4 = W
        public int Direction { get; set; }

        public int CrossingDecision { get; set; }

        public bool Destroyed { get; set; }

        public void Move(List<char[]> grid)
        {
            Position = NewPosition();

            // Adjust facing
            char reading = grid[Position.Y][Position.X];
            if (reading == '/')
            {
                if (Direction == 1 || Direction == 3)
                    Direction++;
                else if (Direction == 2 || Direction == 4)
                    Direction--;
                else
                    throw new ArgumentException("Facing invalid direction");
            }
            else if (reading == '\\')
            {
                if (Direction == 1 || Direction == 3)
                    Direction--;
                else if (Direction == 2 || Direction == 4)
                    Direction++;
                else
                    throw new ArgumentException("Facing invalid direction");
            }
            else if (reading == '+')
            {
                if (CrossingDecision == 0)
                    Direction--;
                else if (CrossingDecision == 2)
                    Direction++;

                CrossingDecision++;
                if (CrossingDecision > 2)
                    CrossingDecision = 0;
            }

            // Adjust direction if we exceeded or were less than our max and min
            if (Direction > 4)
                Direction = 1;
            if (Direction < 1)
                Direction = 4;
        }

        private Coordinate NewPosition()
        {
            if (Direction == 1)
                return new Coordinate(Position.X, Position.Y - 1);

            if (Direction == 2)
                return new Coordinate(Position.X + 1, Position.Y);

            if (Direction == 3)
                return new Coordinate(Position.X, Position.Y + 1);

            if (Direction == 4)
                return new Coordinate(Position.X - 1, Position.Y);

            throw new ArgumentException("Current direction is an illegal one.");
        }
    }

    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            CoordinateComparer comparer = new CoordinateComparer();
            return comparer.Equals(this, (Coordinate)obj);
        }

        public override int GetHashCode()
        {
            CoordinateComparer comparer = new CoordinateComparer();
            return comparer.GetHashCode(this);
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }

    public class CoordinateComparer : IEqualityComparer<Coordinate>
    {
        public bool Equals(Coordinate c1, Coordinate c2)
        {
            if (c2 == null && c1 == null)
                return true;
            else if (c1 == null | c2 == null)
                return false;
            else if (c1.X == c2.X && c1.Y == c2.Y)
                return true;
            else
                return false;
        }

        public int GetHashCode(Coordinate c)
        {
            return $"{c.X}{c.Y}".GetHashCode();
        }
    }
}