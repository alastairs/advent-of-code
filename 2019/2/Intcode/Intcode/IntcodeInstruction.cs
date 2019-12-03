using System;

namespace Intcode
{
    internal ref struct IntcodeInstruction
    {
        private readonly Span<int> _instruction;

        public IntcodeInstruction(Span<int> instruction)
        {
            _instruction = instruction;
        }

        public void Execute(Span<int> program)
        {
            if (IsAdd(_instruction))
            {
                program[_instruction[3]] = program[_instruction[1]] + program[_instruction[2]];
                return;
            }

            if (IsMultiply(_instruction))
            {
                program[_instruction[3]] = program[_instruction[1]] * program[_instruction[2]];
                return;
            }

            throw new InvalidOperationException();
        }

        private static bool IsAdd(Span<int> instruction)
        {
            return instruction[0] == (int) Opcodes.Addition;
        }

        private static bool IsMultiply(Span<int> instruction)
        {
            return instruction[0] == (int) Opcodes.Multiplication;
        }

        public static bool IsStop(int opcode)
        {
            return opcode == (int) Opcodes.Stop;
        }

        private enum Opcodes
        {
            Addition = 1,
            Multiplication = 2,
            Stop = 99
        }
    }
}