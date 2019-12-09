using System;
using System.Collections.Generic;

namespace Intcode
{
    internal ref struct IntcodeInstruction
    {
        private static IDictionary<Opcode, Func<int, int, int>> KnownInstructions { get; } =
            new Dictionary<Opcode, Func<int, int, int>>
            {
                { Opcode.Addition, (i, j) => i + j },
                { Opcode.Multiplication, (i, j) => i * j },
            };

        private readonly Span<int> _instruction;

        public IntcodeInstruction(Span<int> instruction)
        {
            _instruction = instruction;
        }

        public void Execute(Span<int> program)
        {
            if (!KnownInstructions.TryGetValue((Opcode) _instruction[0], out var execute))
            {
                throw new InvalidOperationException($"Unknown opcode {_instruction[0]}");
            }

            program[_instruction[3]] = execute(program[_instruction[1]], program[_instruction[2]]);
        }

        public static bool IsStop(int opcode)
        {
            return opcode == (int) Opcode.Stop;
        }

        private enum Opcode
        {
            Addition = 1,
            Multiplication = 2,
            Stop = 99
        }
    }
}