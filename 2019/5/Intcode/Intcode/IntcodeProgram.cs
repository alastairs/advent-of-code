using System;
using System.Collections.Generic;
using System.Linq;

namespace Intcode
{
    public class IntcodeProgram
    {
        public Memory<int> Memory { get; }

        internal IntcodeProgram(IEnumerable<int> operations)
        {
            Memory = operations?.ToArray().AsMemory() ?? throw new ArgumentNullException(nameof(operations));
        }

        public string Execute(in string input = null)
        {
            var executable = Memory.Span;

            for (var instructionPointer = 0; instructionPointer < executable.Length; instructionPointer += 4)
            {
                if (IntcodeInstruction.IsStop(executable[instructionPointer]))
                {
                    break;
                }

                new IntcodeInstruction(executable.Slice(instructionPointer, 4)).Execute(executable);
            }

            return string.Empty;
        }

        public IntcodeProgram Copy()
        {
            return new IntcodeProgram(Memory.ToArray());
        }
    }

    public static class IntcodeMemory
    {
        public static int At(this Memory<int> memory, int index)
        {
            return memory.Span[index];
        }

        public static void Set(this Memory<int> memory, int index, int value)
        {
            memory.Span[index] = value;
        }
    }
}