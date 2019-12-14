namespace Intcode.InstructionSet
{
    internal interface IIntcodeInstruction
    {
        int Size { get; }

        int Execute(int address1, int address2, ref int outputAddress);
    }
}