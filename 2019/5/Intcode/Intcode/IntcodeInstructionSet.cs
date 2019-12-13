﻿using System.Collections.Generic;
using Intcode.InstructionSet;

namespace Intcode
{
    internal static class IntcodeInstructionSet
    {
        private static IDictionary<Opcode, IIntcodeInstruction> InstructionSet { get; } =
            new Dictionary<Opcode, IIntcodeInstruction>
            {
                { AdditionInstruction.Opcode, new AdditionInstruction() },
                { MultiplicationInstruction.Opcode, new MultiplicationInstruction() },
                { LoadInstruction.Opcode, new LoadInstruction() },
                { OutputInstruction.Opcode, new OutputInstruction() },
            };

        public static bool Contains(int opcode, out IIntcodeInstruction instruction)
        {
            return InstructionSet.TryGetValue((Opcode)opcode, out instruction);
        }

        public static bool IsStop(int opcode)
        {
            return opcode == (int)Opcode.Stop;
        }

        internal enum Opcode
        {
            Addition = 1,
            Multiplication = 2,
            Load = 3,
            Output = 4,

            Stop = 99
        }
    }
}