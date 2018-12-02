using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018.Two
{
    public class DayTwo : IAdventProblemSet
    {
        public string Description()
        {
            return "Inventory Management System";
        }

        public int SortOrder()
        {
            return 2;
        }

        public string PartA()
        {
            string filePath = @"Two\DayTwoInput.txt";
            int checkSum = CalculateCheckSum(filePath);
            return checkSum.ToString();
        }

        // I spent a lot of time trying to get the Checksum concept to work here, but calculating the checksum off the ASCII value of each character
        // and multiplying them together.  Then I sorted by the check sum, figuring that the values that were closest would then be next to each other
        // in the resulting list.  That did not work (though it did work for the sample problem).  In the end, I just brute forced all combinations, with
        // exit criteria the first time a pair of strings had more than one different character, and that when I found just one pair that matched, I exited
        // the loop.
        // Unfortunately, I also misread the answer and was returning the mismatched characters, which cost me about an hour.
        public string PartB()
        {
            string filePath = @"Two\DayTwoInput.txt";
            return FindCommonLetters(filePath);
        }

        public int CalculateCheckSum(string filePath)
        {
            List<string> lines = GetLines(filePath);

            int numberOfTwos = 0;
            int numberOfThrees = 0;

            foreach (string line in lines)
            {
                if (ContainsNumberOfDuplicateLetters(line, 2))
                    numberOfTwos++;
                if (ContainsNumberOfDuplicateLetters(line, 3))
                    numberOfThrees++;
            }

            return numberOfTwos * numberOfThrees;
        }

        public bool ContainsNumberOfDuplicateLetters(string input, int duplicatesRequired)
        {
            List<char> chars = input.ToCharArray().ToList();
            var duplicateChars = chars.GroupBy(x => x)
                .Where(group => group.Count() == duplicatesRequired);

            return duplicateChars.Any();
        }

        public string FindCommonLetters(string filePath)
        {
            List<string> lines = GetLines(filePath);
            string currentLine = lines[0];
            lines.Remove(currentLine);

            do
            {
                string commonLetters = FindCommonLettersWhenOnlyOnePairIsOff(lines, currentLine);

                if (commonLetters != null)
                    return commonLetters;

                currentLine = lines[0];
                lines.Remove(currentLine);
            } while (lines.Count > 0);

            // Should not get here
            throw new ArgumentException("Did not find only one matching character");
        }

        private string FindCommonLettersWhenOnlyOnePairIsOff(List<string> lines, string lineEvaluating)
        {
            foreach (string line in lines)
            {
                List<int> differentCharacterIndex = new List<int>();

                for (int i = 0; i < line.Length; i++)
                {
                    if (lineEvaluating[i] != line[i])
                        differentCharacterIndex.Add(i);

                    if (differentCharacterIndex.Count > 1)
                        break;
                }

                if (differentCharacterIndex.Count == 1)
                    return lineEvaluating.Remove(differentCharacterIndex[0], 1);
            }

            return null;
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