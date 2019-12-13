namespace Intcode.InstructionSet
{
    internal class LessThanInstruction : IIntcodeInstruction
    {
        public const IntcodeInstructionSet.Opcode Opcode = IntcodeInstructionSet.Opcode.LessThan;

        public int Size => 4;

        public void Execute(int value1, int value2, ref int outputAddress)
        {
            outputAddress = value1 < value2 ? 1 : 0;
        }
    }
}