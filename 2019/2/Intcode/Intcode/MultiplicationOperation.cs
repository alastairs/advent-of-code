using System;

namespace Intcode
{
    public class MultiplicationOperation : IntcodeOperation, IEquatable<MultiplicationOperation>
    {
        public const int Opcode = 2;

        private readonly int _multiplier;
        private readonly int _multiplicand;
        private readonly int _outputIndex;


        public MultiplicationOperation(int multiplier, int multiplicand, int outputIndex)
        {
            _multiplier = multiplier;
            _multiplicand = multiplicand;
            _outputIndex = outputIndex;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MultiplicationOperation);
        }

        public bool Equals(MultiplicationOperation other)
        {
            return Equals(this, other);
        }

        private static bool Equals(MultiplicationOperation x, MultiplicationOperation y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x is null || y is null)
            {
                return false;
            }

            return x._multiplier == y._multiplier &&
                   x._multiplicand == y._multiplicand &&
                   x._outputIndex == y._outputIndex;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_multiplier, _multiplicand, _outputIndex);
        }

        public static bool operator ==(MultiplicationOperation left, MultiplicationOperation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MultiplicationOperation left, MultiplicationOperation right)
        {
            return !Equals(left, right);
        }
    }
}