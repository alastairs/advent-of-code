using System;

namespace Intcode.InstructionSet
{
    internal class OutputInstruction : IIntcodeInstruction
    {
        public const IntcodeInstructionSet.Opcode Opcode = IntcodeInstructionSet.Opcode.Output;

        public int Size => 2;

        public void Execute(int value, int _, ref int outputAddress)
        {
            Console.WriteLine(value);
        }
    }
}