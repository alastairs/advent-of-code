namespace Intcode.InstructionSet
{
    internal class JumpIfFalseInstruction : IIntcodeInstruction
    {
        public const IntcodeInstructionSet.Opcode Opcode = IntcodeInstructionSet.Opcode.JumpIfFalse;

        public int Size => 3;

        public int Execute(int address1, int address2, ref int outputAddress)
        {
            return address1 == 0 ? address2 : Size;
        }
    }
}