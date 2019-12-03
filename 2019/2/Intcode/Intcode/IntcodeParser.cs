using System;
using System.Collections.Generic;
using System.Linq;

namespace Intcode
{
    public class IntcodeParser
    {
        public IntcodeProgram Parse(string initialState)
        {
            if (string.IsNullOrWhiteSpace(initialState))
            {
                throw new ArgumentNullException(nameof(initialState));
            }

            return new IntcodeProgram(initialState.Split(",").Select(int.Parse));
        }
    }

    public class IntcodeProgram
    {
        private readonly IEnumerable<int> _instructions;

        internal IntcodeProgram(IEnumerable<int> operations)
        {
            _instructions = operations ?? throw new ArgumentNullException(nameof(operations));
        }

        public string Execute()
        {
            var executable = new Span<int>(_instructions.ToArray());

            for (var instructionPointer = 0; instructionPointer < executable.Length; instructionPointer += 4)
            {
                if (IntcodeInstruction.IsStop(executable[instructionPointer]))
                {
                    break;
                }

                new IntcodeInstruction(executable.Slice(instructionPointer, 4)).Execute(executable);
            }

            return string.Join(",",executable.ToArray().Select(o => $"{o}"));
        }
    }
}