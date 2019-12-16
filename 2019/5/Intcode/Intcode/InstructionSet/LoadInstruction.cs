using System;

namespace Intcode.InstructionSet
{
    internal class LoadInstruction : IIntcodeInstruction
    {
        public const IntcodeInstructionSet.Opcode Opcode = IntcodeInstructionSet.Opcode.Load;

        public int Size => 2;

        public void Execute(int address1, int address2, ref int outputAddress, ref int instructionPointer)
        {
            var rawInput = Console.ReadLine();
            outputAddress = int.Parse(rawInput);

            instructionPointer += Size;
        }
    }
}