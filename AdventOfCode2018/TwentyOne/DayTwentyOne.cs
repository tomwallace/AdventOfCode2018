using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode2018.TwentyOne
{
    public class DayTwentyOne : IAdventProblemSet
    {
        public string Description()
        {
            return "Chronal Conversion";
        }

        public int SortOrder()
        {
            return 21;
        }

        public string PartA()
        {
            string filePath = @"TwentyOne\DayTwentyOneInput.txt";
            int value = FindValueOfRegisterTwo(filePath, 5);
            return value.ToString();
        }

        public string PartB()
        {
            string filePath = @"TwentyOne\DayTwentyOneInput.txt";
            int value = FindMaxValueOfRegisterTwo(filePath, 5);
            return value.ToString();
        }

        // I had to read some of the comments on the Reddit thread for this day just to figure out what the problem was asking.
        // Then in reviewing the input, you can see the only line that involves Register Zero at all is line 28.  So, for Part One
        // the best you can do is the value of the register that instruction writes to when our pointer reads 28.
        public int FindValueOfRegisterTwo(string filePath, int pointerIndex)
        {
            int[] startState = new[] { 0, 0, 0, 0, 0, 0 };
            int pointerValue = -1;
            List<Instruction> instructions = GetInstructions(filePath);

            for (int i = 0; i < instructions.Count; i++)
            {
                startState[pointerIndex] = pointerValue + 1;

                Instruction instruction = instructions[i];
                UseOpCode(instruction.OpCode, startState, instruction.Operations);

                if (startState[pointerIndex] == 28)
                    return startState[2];

                pointerValue = startState[pointerIndex];

                i = pointerValue;
            }

            return startState[0];
        }

        public int FindMaxValueOfRegisterTwo(string filePath, int pointerIndex)
        {
            int[] startState = new[] { 0, 0, 0, 0, 0, 0 };
            int pointerValue = -1;
            List<Instruction> instructions = GetInstructions(filePath);

            HashSet<int> seen = new HashSet<int>();
            bool firstTimeThrough = true;
            int lastAdded = 0;

            for (int i = 0; i < instructions.Count; i++)
            {
                startState[pointerIndex] = pointerValue + 1;

                Instruction instruction = instructions[i];
                UseOpCode(instruction.OpCode, startState, instruction.Operations);

                if (startState[pointerIndex] == 28)
                {
                    if (seen.Contains(startState[2]))
                    {
                        return lastAdded;
                    }
                    else if (!seen.Contains(startState[2]))
                    {
                        if (seen.Count() > 0)
                        {
                            Debug.WriteLine($"Seen List Last:  {seen.Last()} : Item not in seen: {startState[2]}");
                        }
                    }
                    seen.Add(startState[2]);
                    lastAdded = startState[2];
                }

                pointerValue = startState[pointerIndex];

                i = pointerValue;
            }

            return lastAdded;
        }

        private int[] UseOpCode(string name, int[] startState, int[] operations)
        {
            switch (name)
            {
                case "addr":
                    startState[operations[2]] = startState[operations[0]] + startState[operations[1]];
                    return startState;
                    break;

                case "addi":
                    startState[operations[2]] = startState[operations[0]] + operations[1];
                    return startState;
                    break;

                case "mulr":
                    startState[operations[2]] = startState[operations[0]] * startState[operations[1]];
                    return startState;
                    break;

                case "muli":
                    startState[operations[2]] = startState[operations[0]] * operations[1];
                    return startState;
                    break;

                case "banr":
                    startState[operations[2]] = startState[operations[0]] & startState[operations[1]];
                    return startState;
                    break;

                case "bani":
                    startState[operations[2]] = startState[operations[0]] & operations[1];
                    return startState;
                    break;

                case "borr":
                    startState[operations[2]] = startState[operations[0]] | startState[operations[1]];
                    return startState;
                    break;

                case "bori":
                    startState[operations[2]] = startState[operations[0]] | operations[1];
                    return startState;
                    break;

                case "setr":
                    startState[operations[2]] = startState[operations[0]];
                    return startState;
                    break;

                case "seti":
                    startState[operations[2]] = operations[0];
                    return startState;
                    break;

                case "gtir":
                    startState[operations[2]] = operations[0] > startState[operations[1]] ? 1 : 0;
                    return startState;
                    break;

                case "gtri":
                    startState[operations[2]] = startState[operations[0]] > operations[1] ? 1 : 0;
                    return startState;
                    break;

                case "gtrr":
                    startState[operations[2]] = startState[operations[0]] > startState[operations[1]] ? 1 : 0;
                    return startState;
                    break;

                case "eqir":
                    startState[operations[2]] = operations[0] == startState[operations[1]] ? 1 : 0;
                    return startState;
                    break;

                case "eqri":
                    startState[operations[2]] = startState[operations[0]] == operations[1] ? 1 : 0;
                    return startState;
                    break;

                case "eqrr":
                    startState[operations[2]] = startState[operations[0]] == startState[operations[1]] ? 1 : 0;
                    return startState;
                    break;

                default:
                    throw new ArgumentException("Trying to access opcode that does not exist");
            }
        }

        private List<Instruction> GetInstructions(string filePath)
        {
            List<Instruction> instructions = new List<Instruction>();
            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                string opCode = line.Substring(0, 5).Trim();
                int[] operations = line.Substring(5).Split(' ').Select(i => int.Parse(i)).ToArray();

                instructions.Add(new Instruction() { OpCode = opCode, Operations = operations });
            }
            file.Close();
            return instructions;
        }
    }

    public class Instruction
    {
        public string OpCode { get; set; }

        public int[] Operations { get; set; }
    }
}