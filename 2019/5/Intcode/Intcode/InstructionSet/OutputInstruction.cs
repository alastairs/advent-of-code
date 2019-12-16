using System;

namespace Intcode.InstructionSet
{
    internal class OutputInstruction : IIntcodeInstruction
    {
        public const IntcodeInstructionSet.Opcode Opcode = IntcodeInstructionSet.Opcode.Output;

        public int Size => 2;

        public void Execute(int address1, int address2, ref int outputAddress, ref int instructionPointer)
        {
            Console.WriteLine(address1);
            instructionPointer += Size;
        }
    }
}