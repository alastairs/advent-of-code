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
            if (!IntcodeInstructionSet.Contains(_instruction[0], out var instruction))
            {
                throw new InvalidOperationException($"Unknown opcode {_instruction[0]}");
            }

            instruction.Execute(program[_instruction[1]], program[_instruction[2]], ref program[_instruction[3]]);
        }

        public static bool IsStop(int opcode)
        {
            return opcode == (int) IntcodeInstructionSet.Opcode.Stop;
        }
    }
}