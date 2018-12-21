using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2018.Ten;

namespace AdventOfCode2018.Nineteen
{
    public class DayNineteen : IAdventProblemSet
    {
        public string Description()
        {
            return "Go With The Flow";
        }

        public int SortOrder()
        {
            return 19;
        }

        public string PartA()
        {
            string filePath = @"Nineteen\DayNineteenInput.txt";
            int value = FindValueInRegisterZero(filePath, 5, 0);
            return value.ToString();
        }

        public string PartB()
        {
            string filePath = @"Nineteen\DayNineteenInput.txt";
            int value = FindValueInRegisterZero(filePath, 5, 1);
            return value.ToString();
        }

        public int FindValueInRegisterZero(string filePath, int pointerIndex, int regZeroStart)
        {
            int[] startState = new[] {regZeroStart, 0, 0, 0, 0, 0};
            int pointerValue = -1;
            List<Instruction> instructions = GetInstructions(filePath);

            for (int i = 0; i < instructions.Count; i++)
            {
                startState[pointerIndex] = pointerValue + 1;

                Instruction instruction = instructions[i];
                int[] endState = UseOpCode(instruction.OpCode, startState, instruction.Operations);

                pointerValue = endState[pointerIndex];

                i = pointerValue;
            }

            return startState[0];
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

                instructions.Add(new Instruction() {OpCode = opCode, Operations = operations});
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