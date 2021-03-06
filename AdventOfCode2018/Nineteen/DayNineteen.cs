﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            int value = FindValueInRegisterZero(filePath, 5);
            return value.ToString();
        }

        public string PartB()
        {
            string filePath = @"Nineteen\DayNineteenInput.txt";
            int value = FindValueInRegisterZeroExtended(filePath, 5);
            return value.ToString();
        }

        public int FindValueInRegisterZero(string filePath, int pointerIndex)
        {
            int[] startState = new[] { 0, 0, 0, 0, 0, 0 };
            int pointerValue = -1;
            List<Instruction> instructions = GetInstructions(filePath);

            for (int i = 0; i < instructions.Count; i++)
            {
                startState[pointerIndex] = pointerValue + 1;

                Instruction instruction = instructions[i];
                UseOpCode(instruction.OpCode, startState, instruction.Operations);

                pointerValue = startState[pointerIndex];

                i = pointerValue;
            }

            return startState[0];
        }

        //I really struggled with this part of the program.  I looked on Reddit and found the following.  I was able
        // to go through my input and eventually map it out.  Much harder than it should have been, but I
        // eventually solved it.:

        //R1 = 1
        //do
        //{
        //if R3 * R1 == R5 {
        //R0 += R3
        //R2 = 1
        //}
        //else
        //{
        //R2 = 0
        //}
        //R1 += 1
        //} while (R1 <= R5)

        public int FindValueInRegisterZeroExtended(string filePath, int pointerIndex)
        {
            int[] startState = new[] { 1, 0, 0, 0, 0, 0 };
            int pointerValue = -1;
            List<Instruction> instructions = GetInstructions(filePath);

            for (int i = 0; i < instructions.Count; i++)
            {
                if (i == 2 && startState[2] != 0)
                {
                    if (startState[3] % startState[2] == 0)
                    {
                        startState[0] += startState[2];
                    }
                    startState[4] = 0;
                    startState[1] = startState[3];

                    startState[pointerIndex] = 11;

                    pointerValue = startState[pointerIndex];

                    i = pointerValue;
                    continue;
                }
                startState[pointerIndex] = pointerValue + 1;

                Instruction instruction = instructions[i];
                UseOpCode(instruction.OpCode, startState, instruction.Operations);

                pointerValue = startState[pointerIndex];

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