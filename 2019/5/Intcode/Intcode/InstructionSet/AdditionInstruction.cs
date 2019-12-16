namespace Intcode.InstructionSet
{
    internal class AdditionInstruction : IIntcodeInstruction
    {
        public const IntcodeInstructionSet.Opcode Opcode = IntcodeInstructionSet.Opcode.Addition;

        public int Size => 4;

        public void Execute(int address1, int address2, ref int outputAddress, ref int instructionPointer)
        {
            outputAddress = address1 + address2;
            instructionPointer += Size;
        }
    }
}