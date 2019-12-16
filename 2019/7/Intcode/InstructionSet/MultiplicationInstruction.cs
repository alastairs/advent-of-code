using System;

namespace Intcode.InstructionSet
{
    internal class MultiplicationInstruction : IIntcodeInstruction
    {
        public const IntcodeInstructionSet.Opcode Opcode = IntcodeInstructionSet.Opcode.Multiplication;

        public int Size => 4;

        public void Execute(int address1, int address2, int outputAddress, ref Span<int> memory, ref int instructionPointer)
        {
            memory[outputAddress] = address1 * address2;
            instructionPointer += Size;
        }
    }
}