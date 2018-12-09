using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018.Seven
{
    public class DaySeven : IAdventProblemSet
    {
        public string Description()
        {
            return "The Sum of Its Parts";
        }

        public int SortOrder()
        {
            return 7;
        }

        public string PartA()
        {
            string filePath = @"Seven\DaySevenInput.txt";
            return DetermineInstructionOrder(filePath);
        }

        public string PartB()
        {
            string filePath = @"Seven\DaySevenInput.txt";
            int seconds = DetermineAssemblyTime(filePath, 5, 60);
            return seconds.ToString();
        }

        public string DetermineInstructionOrder(string filePath)
        {
            Dictionary<char, HashSet<char>> instructions = GetInstructions(filePath);
            HashSet<char> keysWithoutDependencies = FindKeysWithoutDependencies(instructions);
            foreach (char key in keysWithoutDependencies)
            {
                instructions.Add(key, new HashSet<char>());
            }
            List<char> keyOrderUsed = new List<char>();

            do
            {
                HashSet<char> keysCanBeRemovedThisPass = new HashSet<char>();
                foreach (var instruction in instructions)
                {
                    bool canBeCompleted = true;
                    foreach (char req in instruction.Value)
                    {
                        if (!keyOrderUsed.Contains(req))
                            canBeCompleted = false;
                    }

                    if (canBeCompleted)
                    {
                        keysCanBeRemovedThisPass.Add(instruction.Key);
                    }

                }

                // Clean up dictionary
                List<char> sorted = keysCanBeRemovedThisPass.OrderBy(k => k).ToList();
                if (sorted.Any())
                {
                    instructions.Remove(sorted.First());
                    keyOrderUsed.Add(sorted.First());
                }
                    
            } while (instructions.Any());

            // Create the composite key
            return new string(keyOrderUsed.ToArray());
        }

        public int DetermineAssemblyTime(string filePath, int numberOfWorkers, int secondsOffset)
        {
            Dictionary<char, HashSet<char>> instructions = GetInstructions(filePath);
            HashSet<char> keysWithoutDependencies = FindKeysWithoutDependencies(instructions);
            foreach (char key in keysWithoutDependencies)
            {
                instructions.Add(key, new HashSet<char>());
            }

            Dictionary<char, int> workers = new Dictionary<char, int>();
            List<char> keyOrderUsed = new List<char>();
            int currentSecond = -1;

            do
            {
                // Clean up workers
                List<char> keysOfFinishedWorkers =
                    workers.Where(w => w.Value <= currentSecond).Select(w => w.Key).ToList();
                foreach (char key in keysOfFinishedWorkers)
                {
                    workers.Remove(key);
                    instructions.Remove(key);
                    keyOrderUsed.Add(key);
                }

                HashSet<char> keysCanBeRemovedThisPass = new HashSet<char>();
                foreach (var instruction in instructions)
                {
                    bool canBeCompleted = true;
                    foreach (char req in instruction.Value)
                    {
                        if (!keyOrderUsed.Contains(req))
                            canBeCompleted = false;
                    }

                    if (canBeCompleted && !workers.ContainsKey(instruction.Key))
                    {
                        keysCanBeRemovedThisPass.Add(instruction.Key);
                    }

                }

                // Clean up dictionary
                List<char> sorted = keysCanBeRemovedThisPass.OrderBy(k => k).ToList();
                foreach (char sortedKey in sorted)
                {
                    if (workers.Count < numberOfWorkers)
                    {
                        workers.Add(sortedKey, CalculateStepSeconds(sortedKey, secondsOffset) + currentSecond);
                    }
                }

                currentSecond++;
            } while (instructions.Any());

            return currentSecond;
        }
       
        public int CalculateStepSeconds(char step, int secondsOffset)
        {
            int value = Convert.ToInt32(step) - 64;
            return value + secondsOffset;
        }

        private HashSet<char> FindKeysWithoutDependencies(Dictionary<char, HashSet<char>> instructions)
        {
            HashSet<char> keysWithoutDependencies = new HashSet<char>();
            foreach (var instruction in instructions)
            {
                foreach (char req in instruction.Value)
                {
                    if (!instructions.Keys.Contains(req))
                    {
                        keysWithoutDependencies.Add(req);
                    }
                }
            }

            return keysWithoutDependencies;
        }

        private Dictionary<char, HashSet<char>> GetInstructions(string filePath)
        {
            Dictionary<char, HashSet<char>> instructions = new Dictionary<char, HashSet<char>>();
            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                string[] splitTep = line.Split(new string[] { "tep " }, StringSplitOptions.None);
                char value = splitTep[1][0];
                char key = splitTep[2][0];

                if (instructions.ContainsKey(key))
                    instructions[key].Add(value);
                else
                    instructions.Add(key,new HashSet<char>() {value});
            }
            file.Close();
            return instructions;
        }
    }
}