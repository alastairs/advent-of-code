using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Intcode
{
    using static IntcodeOperation;

    public class IntcodeParser
    {
        public IntcodeProgram Parse(in string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            var instructions = new IntcodeLexer().Read(input).ToArray();

            IntcodeOperation operation;
            if (instructions.First() == AdditionOperation.Opcode)
            {
                operation = Add(instructions[1], instructions[2], instructions[3]);
            }
            else if (instructions.First() == MultiplicationOperation.Opcode)
            {
                operation = Multiply(instructions[1], instructions[2], instructions[3]);
            }
            else // if (instructions.First() == StopOperation.Opcode)
            {
                operation = Stop();
            }

            return new IntcodeProgram(new[] { operation });
        }
    }

    internal class IntcodeLexer
    {
        internal IEnumerable<int> Read(string input)
        {
            return input.Split(",").Select(n => int.Parse(n.Trim(), NumberFormatInfo.InvariantInfo));
        }
    }
}