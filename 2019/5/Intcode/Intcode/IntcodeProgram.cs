using System;
using System.Collections.Generic;
using System.Linq;
using Intcode.InstructionSet;

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

            var instructionPointer = 0;
            while(!IntcodeInstruction.IsStop(executable[instructionPointer]))
            {
                if (IntcodeInstructionSet.Contains(executable[instructionPointer], out var instruction))
                {
                    new IntcodeInstruction(executable.Slice(instructionPointer, instruction.Size)).Execute(executable);
                }

                instructionPointer += instruction.Size;
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