using System;

namespace Intcode.InstructionSet
{
    internal class LoadInstruction : IIntcodeInstruction
    {
        public const IntcodeInstructionSet.Opcode Opcode = IntcodeInstructionSet.Opcode.Load;

        public int Size => 2;

        public void Execute(int address1, int _, int outputAddress, ref Span<int> memory, ref int instructionPointer)
        {
            var rawInput = Console.ReadLine();
            memory[outputAddress] = int.Parse(rawInput);

            instructionPointer += Size;
        }
    }
}