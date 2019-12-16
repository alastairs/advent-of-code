using System;

namespace Intcode.InstructionSet
{
    internal class JumpIfFalseInstruction : IIntcodeInstruction
    {
        public const IntcodeInstructionSet.Opcode Opcode = IntcodeInstructionSet.Opcode.JumpIfFalse;

        public int Size => 3;

        public void Execute(int address1, int address2, int _, ref Span<int> __, ref int instructionPointer)
        {
            instructionPointer = address1 == 0 ? address2 : instructionPointer + Size;
        }
    }
}