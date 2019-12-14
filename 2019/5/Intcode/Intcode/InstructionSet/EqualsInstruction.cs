namespace Intcode.InstructionSet
{
    internal class EqualsInstruction : IIntcodeInstruction
    {
        public const IntcodeInstructionSet.Opcode Opcode = IntcodeInstructionSet.Opcode.Equals;

        public int Size => 4;

        public int Execute(int value1, int value2, ref int outputAddress)
        {
            outputAddress = value1 == value2 ? 1 : 0;
            return Size;
        }
    }
}