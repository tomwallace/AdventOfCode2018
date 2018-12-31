using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2018.One
{
    public class DayOneErin : IAdventProblemSet
    {
        public string Description()
        {
            return "Chronal Calibration - Erin";
        }

        public int SortOrder()
        {
            return 26;
        }

        public string PartA()
        {
            string filePath = @"One\DayOneInput.txt";
            int lastFrequency = CalculateLastFrequency(filePath);
            return lastFrequency.ToString();
        }

        public string PartB()
        {
            string filePath = @"One\DayOneInput.txt";
            int repeatedFrequency = FindFirstRepeatedFrequency(filePath);
            return repeatedFrequency.ToString();
        }

        public int CalculateLastFrequency(string filePath)
        {
            List<int> frequencyChanges = GetFrequencyChanges(filePath);
            int firstFrequency = 0;

            foreach (int change in frequencyChanges)
            {
                firstFrequency = firstFrequency + change;
            }

            return firstFrequency;
        }

        public int FindFirstRepeatedFrequency(string filePath)
        {
            List<int> frequencyChanges = GetFrequencyChanges(filePath);
            HashSet<int> pastFrequencies = new HashSet<int>();
            int currentFrequency = 0;

            for (int counter = 0; counter < frequencyChanges.Count; counter = counter + 1)
            {
                int change = frequencyChanges[counter];
                currentFrequency = currentFrequency + change;

                if (pastFrequencies.Add(currentFrequency) == false)
                {
                    return currentFrequency;
                }

                if (counter == frequencyChanges.Count - 1)
                {
                    counter = -1;
                }
            }

            throw new Exception("We never found a duplicate.  Danger Will Robinson!");
        }

        private List<int> GetFrequencyChanges(string filePath)
        {
            List<int> frequencies = new List<int>();

            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                int currentLine = int.Parse(line);
                frequencies.Add(currentLine);
            }
            file.Close();

            return frequencies;
        }
    }
}