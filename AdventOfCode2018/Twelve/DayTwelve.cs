using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace AdventOfCode2018.Twelve
{
    public class DayTwelve : IAdventProblemSet
    {
        private Dictionary<string, char> _patterns;

        public DayTwelve()
        {
            _patterns = new Dictionary<string, char>();
        }

        public string Description()
        {
            return "Subterranean Sustainability";
        }

        public int SortOrder()
        {
            return 12;
        }

        public string PartA()
        {
            string filePath = @"Twelve\DayTwelveInput.txt";
            long sum = FindPlantSum(filePath, 20);
            return sum.ToString();
        }

        public string PartB()
        {
            string filePath = @"Twelve\DayTwelveInput.txt";
            // In looking at the output, every entry after 100 adds 91 (50 billion is too much to add)
            // So get the sum after 100 and then do the math
            long sum = FindPlantSum(filePath, 100);
            long remainder = (50000000000 - 100) * 91;
            return (sum + remainder).ToString();
        }

        public long FindPlantSum(string filePath, long generations)
        {
            string plantState = ParsePatterns(filePath);
            int currentLeftIndex = 0;

            Dictionary<string, string> knownStates = new Dictionary<string, string>();

            for (int i = 0; i < generations; i++)
            {
                if (knownStates.ContainsKey(plantState))
                    plantState = knownStates[plantState];
                else
                {
                    string initialState = plantState;

                    // Add buffers
                    if (plantState[0] == '#')
                    {
                        plantState = "..." + plantState;
                        currentLeftIndex -= 3;
                    }
                    else if (plantState[1] == '#')
                    {
                        plantState = ".." + plantState;
                        currentLeftIndex -= 2;
                    }
                    else if (plantState[2] == '#')
                    {
                        plantState = "." + plantState;
                        currentLeftIndex -= 1;
                    }

                    if (plantState[plantState.Length - 1] == '#')
                        plantState = plantState + "...";
                    else if (plantState[plantState.Length - 2] == '#')
                        plantState = plantState + "..";
                    else if (plantState[plantState.Length - 3] == '#')
                        plantState = plantState + ".";

                    //string initialState = "..." + plantState + "...";
                    //currentLeftIndex -= 3;
                    StringBuilder builder = new StringBuilder();
                    for (int c = 0; c < plantState.Length; c++)
                    {
                        if (c < 2 || c >= plantState.Length - 2)
                            builder.Append(plantState[c]);
                        else
                        {
                            // See if any matches and substitute
                            string subSection = plantState.Substring(c - 2, 5);
                            if (_patterns.ContainsKey(subSection))
                                builder.Append(_patterns[subSection]);
                            else
                                builder.Append(".");
                        }
                    }

                    plantState = builder.ToString();

                    knownStates.Add(initialState, plantState);
                }

                // print values
                long counter = 0;
                long leftInd = currentLeftIndex;
                foreach (char c in plantState)
                {
                    if (c == '#')
                        counter += leftInd;

                    leftInd++;
                }

                Debug.WriteLine($"{counter}");
            }

            // Sum values
            long sumPlantIndexes = 0;
            foreach (char c in plantState)
            {
                if (c == '#')
                    sumPlantIndexes += currentLeftIndex;

                currentLeftIndex++;
            }

            return sumPlantIndexes;
        }

        private string ParsePatterns(string filePath)
        {
            string plantState = "";
            string line;
            StreamReader file = new StreamReader(filePath);
            int y = 0;

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("initial state"))
                {
                    string[] split = line.Split(new string[] { "initial state: " }, StringSplitOptions.None);
                    plantState = split[1].Trim();
                }
                else if (line.Contains("=>"))
                {
                    string[] split = line.Split(new string[] { " => " }, StringSplitOptions.None);
                    char convertTo = split[1].Trim()[0];
                    _patterns.Add(split[0], convertTo);
                }
            }
            file.Close();

            return plantState;
        }
    }
}