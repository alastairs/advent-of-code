using System;
using System.Globalization;

namespace Intcode.InstructionSet
{
    internal class LoadInstruction : IIntcodeInstruction
    {
        public const IntcodeInstructionSet.Opcode Opcode = IntcodeInstructionSet.Opcode.Load;

        public int Size => 2;

        public void Execute(int _, int __, ref int outputAddress)
        {
            var rawInput = Console.ReadLine();
            outputAddress = int.Parse(rawInput, NumberStyles.None);
        }
    }
}