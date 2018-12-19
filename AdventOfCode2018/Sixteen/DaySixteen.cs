using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018.Sixteen
{
    public class DaySixteen : IAdventProblemSet
    {
        public string Description()
        {
            return "Chronal Classification (HARD)";
        }

        public int SortOrder()
        {
            return 16;
        }

        public string PartA()
        {
            string filePath = @"Sixteen\DaySixteenInputA.txt";
            int count = HowManySamplesBehaveLikeAtLeastThreeOpcodes(filePath);
            return count.ToString();
        }

        public string PartB()
        {
            string filePath = @"Sixteen\DaySixteenInputA.txt";
            string filePathTestProgram = @"Sixteen\DaySixteenInputB.txt";
            int result = SolveSampleForRegisterOne(filePath, filePathTestProgram);
            return result.ToString();
        }

        // TODO: Figure out how to reduce code duplication
        public int HowManySamplesBehaveLikeAtLeastThreeOpcodes(string filePath)
        {
            Dictionary<string, List<int>> opCodes = new Dictionary<string, List<int>>();
            opCodes.Add("addr", new List<int>());
            opCodes.Add("addi", new List<int>());
            opCodes.Add("mulr", new List<int>());
            opCodes.Add("muli", new List<int>());
            opCodes.Add("banr", new List<int>());
            opCodes.Add("bani", new List<int>());
            opCodes.Add("borr", new List<int>());
            opCodes.Add("bori", new List<int>());
            opCodes.Add("setr", new List<int>());
            opCodes.Add("seti", new List<int>());
            opCodes.Add("gtir", new List<int>());
            opCodes.Add("gtri", new List<int>());
            opCodes.Add("gtrr", new List<int>());
            opCodes.Add("eqir", new List<int>());
            opCodes.Add("eqri", new List<int>());
            opCodes.Add("eqrr", new List<int>());

            List<Instruction> instructions = GetInstructions(filePath);

            int numberAtLeastThree = 0;

            foreach (var instruction in instructions)
            {
                int timesMatched = 0;
                foreach (string name in opCodes.Keys)
                {
                    int matchedOpCode = ProcessOpCode(name, (int[])instruction.Before.Clone(), instruction.Operations, instruction.After);
                    if (matchedOpCode >= 0)
                        timesMatched++;
                }
                if (timesMatched >= 3)
                    numberAtLeastThree++;
            }

            return numberAtLeastThree;
        }

        public int SolveSampleForRegisterOne(string filePath, string filePathTestProgram)
        {
            Dictionary<string, List<int>> opCodes = new Dictionary<string, List<int>>();
            opCodes.Add("addr", new List<int>());
            opCodes.Add("addi", new List<int>());
            opCodes.Add("mulr", new List<int>());
            opCodes.Add("muli", new List<int>());
            opCodes.Add("banr", new List<int>());
            opCodes.Add("bani", new List<int>());
            opCodes.Add("borr", new List<int>());
            opCodes.Add("bori", new List<int>());
            opCodes.Add("setr", new List<int>());
            opCodes.Add("seti", new List<int>());
            opCodes.Add("gtir", new List<int>());
            opCodes.Add("gtri", new List<int>());
            opCodes.Add("gtrr", new List<int>());
            opCodes.Add("eqir", new List<int>());
            opCodes.Add("eqri", new List<int>());
            opCodes.Add("eqrr", new List<int>());

            List<Instruction> instructions = GetInstructions(filePath);

            int numberAtLeastThree = 0;

            foreach (var instruction in instructions)
            {
                foreach (string name in opCodes.Keys)
                {
                    int matchedOpCode = ProcessOpCode(name, (int[])instruction.Before.Clone(), instruction.Operations, instruction.After);
                    if (matchedOpCode >= 0)
                        opCodes[name].Add(matchedOpCode);
                }
            }

            // Create reference
            string[] opCodeMatches = new string[16];

            for (int i = 1; i <= 16; i++)
            {
                int highestCount = 0;
                string highestName = "";

                foreach (var opCode in opCodes)
                {
                    int count = opCode.Value.Where(c => c == i).Count();
                    if (count >= highestCount && !opCodeMatches.Contains(opCode.Key))
                    {
                        highestCount = count;
                        highestName = opCode.Key;
                    }
                }

                opCodeMatches[i - 1] = highestName;
            }
            
            // I tried to do this in code, but it did not work out, so I am using the above information and doing it by hand
            // NOT: borr, bori, eqrr
            // borr, eqrr, bori
            // bori, borr, eqrr
            // bori, eqrr, borr
            // eqrr, borr, bori
            // eqrr, bori, borr
            string[] manualMatches = new[]
            {
                "gtri",
                "setr",
                "gtrr",
                "addr",
                "mulr",
                "banr",
                "muli",
                "gtir",
                "bori",   // **
                "addi",
                "eqir",
                "eqri",
                "eqrr",   // **
                "bani",
                "seti",
                "borr"   // **
            };

            // TODO: The current state does not work, so my matching answers must not be working
            // Starting state
            int[] registers = new[] {0, 0, 0, 0};
            foreach (var operations in GetTestProgram(filePathTestProgram))
            {
                string opCodeName = manualMatches[operations[0]];
                registers = UseOpCode(opCodeName, registers, operations);
            }

            return registers[0];
        }

        private List<Instruction> GetInstructions(string filePath)
        {
            List<Instruction> instructions = new List<Instruction>();
            string line;
            StreamReader file = new StreamReader(filePath);

            string before = null;
            string operations = null;
            string after = null;

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                if (line?.Length > 0)
                {
                    if (line.Contains("Before"))
                    {
                        before = line.Split(new string[] { "Before: [" }, StringSplitOptions.None)[1];
                    }
                    else if (line.Contains("After: "))
                    {
                        after = line.Split(new string[] { "After:  [" }, StringSplitOptions.None)[1];
                    }
                    else
                    {
                        operations = line;
                    }

                    if (before != null && operations != null && after != null)
                    {
                        Instruction instruction = new Instruction();
                        instruction.Before = before.Split(']')[0].Split(',').ToList().Select(i => int.Parse(i.Trim())).ToArray();
                        instruction.Operations = operations.Split(' ').ToList().Select(i => int.Parse(i.Trim())).ToArray();
                        instruction.After = after.Split(']')[0].Split(',').ToList().Select(i => int.Parse(i.Trim())).ToArray();

                        instructions.Add(instruction);

                        before = null;
                        operations = null;
                        after = null;
                    }
                }
            }
            file.Close();
            return instructions;
        }

        private List<int[]> GetTestProgram(string filePath)
        {
            List<int[]> program = new List<int[]>();
            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                int[] splitLine = line.Split(' ').ToList().Select(i => int.Parse(i.Trim())).ToArray();
                program.Add(splitLine);
            }
            file.Close();
            return program;
        }

        private int ProcessOpCode(string name, int[] startState, int[] operations, int[] endState)
        {
            switch (name)
            {
                case "addr":
                    startState[operations[3]] = startState[operations[1]] + startState[operations[2]];
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                case "addi":
                    startState[operations[3]] = startState[operations[1]] + operations[2];
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                case "mulr":
                    startState[operations[3]] = startState[operations[1]] * startState[operations[2]];
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                case "muli":
                    startState[operations[3]] = startState[operations[1]] * operations[2];
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                case "banr":
                    startState[operations[3]] = startState[operations[1]] & startState[operations[2]];
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                case "bani":
                    startState[operations[3]] = startState[operations[1]] & operations[2];
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                case "borr":
                    startState[operations[3]] = startState[operations[1]] | startState[operations[2]];
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                case "bori":
                    startState[operations[3]] = startState[operations[1]] | operations[2];
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                case "setr":
                    startState[operations[3]] = startState[operations[1]];
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                case "seti":
                    startState[operations[3]] = operations[1];
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                case "gtir":
                    startState[operations[3]] = operations[1] > startState[operations[2]] ? 1 : 0;
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                case "gtri":
                    startState[operations[3]] = startState[operations[1]] > operations[2] ? 1 : 0;
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                case "gtrr":
                    startState[operations[3]] = startState[operations[1]] > startState[operations[2]] ? 1 : 0;
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                case "eqir":
                    startState[operations[3]] = operations[1] == startState[operations[2]] ? 1 : 0;
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                case "eqri":
                    startState[operations[3]] = startState[operations[1]] == operations[2] ? 1 : 0;
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                case "eqrr":
                    startState[operations[3]] = startState[operations[1]] == startState[operations[2]] ? 1 : 0;
                    return startState.SequenceEqual(endState) ? operations[0] : -1;
                    break;

                default:
                    throw new ArgumentException("Trying to access opcode that does not exist");
            }
        }

        // TODO: Figure out how to combine for code duplication reduction
        private int[] UseOpCode(string name, int[] startState, int[] operations)
        {
            switch (name)
            {
                case "addr":
                    startState[operations[3]] = startState[operations[1]] + startState[operations[2]];
                    return startState;
                    break;

                case "addi":
                    startState[operations[3]] = startState[operations[1]] + operations[2];
                    return startState;
                    break;

                case "mulr":
                    startState[operations[3]] = startState[operations[1]] * startState[operations[2]];
                    return startState;
                    break;

                case "muli":
                    startState[operations[3]] = startState[operations[1]] * operations[2];
                    return startState;
                    break;

                case "banr":
                    startState[operations[3]] = startState[operations[1]] & startState[operations[2]];
                    return startState;
                    break;

                case "bani":
                    startState[operations[3]] = startState[operations[1]] & operations[2];
                    return startState;
                    break;

                case "borr":
                    startState[operations[3]] = startState[operations[1]] | startState[operations[2]];
                    return startState;
                    break;

                case "bori":
                    startState[operations[3]] = startState[operations[1]] | operations[2];
                    return startState;
                    break;

                case "setr":
                    startState[operations[3]] = startState[operations[1]];
                    return startState;
                    break;

                case "seti":
                    startState[operations[3]] = operations[1];
                    return startState;
                    break;

                case "gtir":
                    startState[operations[3]] = operations[1] > startState[operations[2]] ? 1 : 0;
                    return startState;
                    break;

                case "gtri":
                    startState[operations[3]] = startState[operations[1]] > operations[2] ? 1 : 0;
                    return startState;
                    break;

                case "gtrr":
                    startState[operations[3]] = startState[operations[1]] > startState[operations[2]] ? 1 : 0;
                    return startState;
                    break;

                case "eqir":
                    startState[operations[3]] = operations[1] == startState[operations[2]] ? 1 : 0;
                    return startState;
                    break;

                case "eqri":
                    startState[operations[3]] = startState[operations[1]] == operations[2] ? 1 : 0;
                    return startState;
                    break;

                case "eqrr":
                    startState[operations[3]] = startState[operations[1]] == startState[operations[2]] ? 1 : 0;
                    return startState;
                    break;

                default:
                    throw new ArgumentException("Trying to access opcode that does not exist");
            }
        }
    }

    public class Instruction
    {
        public int[] Before { get; set; }

        public int[] Operations { get; set; }

        public int[] After { get; set; }
    }
}