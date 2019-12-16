namespace Intcode.InstructionSet
{
    internal interface IIntcodeInstruction
    {
        int Size { get; }

        void Execute(int address1, int address2, ref int outputAddress, ref int instructionPointer);
    }
}