namespace Intcode.InstructionSet
{
    internal class AdditionInstruction : IIntcodeInstruction
    {
        public const IntcodeInstructionSet.Opcode Opcode = IntcodeInstructionSet.Opcode.Addition;

        public int Size => 4;

        public int Execute(int address1, int address2, ref int outputAddress)
        {
            outputAddress = address1 + address2;

            return Size;
        }
    }
}