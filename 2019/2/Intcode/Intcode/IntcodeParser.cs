using System;
using System.Collections.Generic;
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
            return new IntcodeProgram(instructions);
        }
    }

    internal class IntcodeLexer
    {
        internal IEnumerable<IntcodeOperation> Read(string input)
        {
            return Read(input.Split(",").Select(int.Parse).ToList());
        }

        private static IEnumerable<IntcodeOperation> Read(IList<int> tokens)
        {
            var instructions = new List<IntcodeOperation>(tokens.Count / 4);
            for (var i = 0; i < tokens.Count;)
            {
                switch (tokens[i])
                {
                    case StopOperation.Opcode:
                        instructions.Add(Stop());
                        i++;
                        continue;
                    case AdditionOperation.Opcode:
                        instructions.Add(Add(tokens[i + 1], tokens[i + 2], tokens[i + 3]));
                        break;
                    case MultiplicationOperation.Opcode:
                        instructions.Add(Multiply(tokens[i + 1], tokens[i + 2], tokens[i + 3]));
                        break;
                }

                i += 4;
            }

            return instructions;
        }
    }
}