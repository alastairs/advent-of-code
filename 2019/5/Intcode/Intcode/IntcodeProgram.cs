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
            while(!IntcodeInstructionSet.IsStop(executable[instructionPointer]))
            {
                var opcode = executable[instructionPointer];
                var parameters = new[] { 0, 0, 0 }.AsSpan();

                if (HasParameters(opcode))
                {
                    parameters = GetParameters((int) Math.Truncate(opcode / 100d));
                    opcode %= 100;
                }

                if (IntcodeInstructionSet.Contains(opcode, out var instruction))
                {
                    var currentInstruction = executable.Slice(instructionPointer, instruction.Size);
                    var arguments = ResolveArguments(executable, currentInstruction, parameters);

                    instruction.Execute(arguments[0], arguments[1], ref executable[currentInstruction[3]]);
                }

                instructionPointer += instruction.Size;
            }

            return string.Empty;
        }

        private static Span<int> GetParameters(in int parametersDescriptor)
        {
            var parameters = new int[3];
            for (var i = 0; i < 3; i++)
            {
                var power = Math.Pow(10, i + 1);
                var result = parametersDescriptor / power;
                result -= Math.Truncate(result);
                parameters[i] = (int)(result * 10);
            }

            return parameters.AsSpan();
        }

        private static int[] ResolveArguments(in Span<int> program, in Span<int> instruction, in Span<int> parameters)
        {
            var arguments = new int[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == 0)
                {
                    arguments[i] = program[instruction[i + 1]];
                }

                if (parameters[i] == 1)
                {
                    arguments[i] = instruction[i + 1];
                }
            }

            return arguments;
        }


        private static bool HasParameters(in int opcode)
        {
            return opcode > 99;
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