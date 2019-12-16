using System;

namespace Intcode.InstructionSet
{
    internal interface IIntcodeInstruction
    {
        int Size { get; }

        void Execute(int address1, int address2, int outputAddress, ref Span<int> memory, ref int instructionPointer);
    }
}