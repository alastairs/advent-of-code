namespace Intcode.InstructionSet
{
    internal class MultiplicationInstruction : IIntcodeInstruction
    {
        public const IntcodeInstructionSet.Opcode Opcode = IntcodeInstructionSet.Opcode.Multiplication;

        public void Execute(int address1, int address2, ref int outputAddress)
        {
            outputAddress = address1 * address2;
        }
    }
}