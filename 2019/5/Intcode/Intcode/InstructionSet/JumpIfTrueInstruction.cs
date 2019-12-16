namespace Intcode.InstructionSet
{
    internal class JumpIfTrueInstruction : IIntcodeInstruction
    {
        public const IntcodeInstructionSet.Opcode Opcode = IntcodeInstructionSet.Opcode.JumpIfTrue;

        public int Size => 3;

        public void Execute(int address1, int address2, ref int outputAddress, ref int instructionPointer)
        {
            instructionPointer = address1 != 0 ? address2 : instructionPointer + Size;
        }
    }
}