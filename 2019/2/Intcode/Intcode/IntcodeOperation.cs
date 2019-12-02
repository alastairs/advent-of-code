namespace Intcode
{
    public class IntcodeOperation
    {
        public static IntcodeOperation Add(int addend1, int addend2, int outputIndex)
        {
            return new AdditionOperation(addend1, addend2, outputIndex);
        }

        public static IntcodeOperation Multiply(int multiplier, int multiplicand, int outputIndex)
        {
            return new MultiplicationOperation(multiplier, multiplicand, outputIndex);
        }

        public static IntcodeOperation Stop()
        {
            return new StopOperation();
        }
    }
}