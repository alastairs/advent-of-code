using System;
using System.Collections.Generic;

namespace Intcode
{
    internal static class IntcodeInstructionSet
    {
        private static IDictionary<Opcode, Func<int, int, int>> InstructionSet { get; } =
            new Dictionary<Opcode, Func<int, int, int>>
            {
                { Opcode.Addition, (i, j) => i + j },
                { Opcode.Multiplication, (i, j) => i * j },
            };

        public static bool Contains(int opcode, out Func<int, int, int> execute)
        {
            return InstructionSet.TryGetValue((Opcode)opcode, out execute);
        }

        internal enum Opcode
        {
            Addition = 1,
            Multiplication = 2,
            Stop = 99
        }
    }
}