namespace Intcode.InstructionSet
{
    internal interface IIntcodeInstruction
    {
        void Execute(int address1, int address2, ref int outputAddress);
    }
}