using System.Collections.Generic;
using Intcode.InstructionSet;

namespace Intcode
{
    internal static class IntcodeInstructionSet
    {
        private static IDictionary<Opcode, IIntcodeInstruction> InstructionSet { get; } =
            new Dictionary<Opcode, IIntcodeInstruction>
            {
                { AdditionInstruction.Opcode, new AdditionInstruction() },
                { MultiplicationInstruction.Opcode, new MultiplicationInstruction() }
            };

        public static bool Contains(int opcode, out IIntcodeInstruction instruction)
        {
            return InstructionSet.TryGetValue((Opcode)opcode, out instruction);
        }

        internal enum Opcode
        {
            Addition = 1,
            Multiplication = 2,
            Stop = 99
        }
    }
}