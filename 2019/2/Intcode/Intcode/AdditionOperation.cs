using System;

namespace Intcode
{
    public class AdditionOperation : IntcodeOperation, IEquatable<AdditionOperation>
    {
        public const int Opcode = 1;

        private readonly int _addend1;
        private readonly int _addend2;
        private readonly int _outputIndex;


        public AdditionOperation(int addend1, int addend2, int outputIndex)
        {
            _addend1 = addend1;
            _addend2 = addend2;
            _outputIndex = outputIndex;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as AdditionOperation);
        }

        public bool Equals(AdditionOperation other)
        {
            return Equals(this, other);
        }

        private static bool Equals(AdditionOperation x, AdditionOperation y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }

            return x._addend1 == y._addend1 &&
                   x._addend2 == y._addend2 &&
                   x._outputIndex == y._outputIndex;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_addend1, _addend2, _outputIndex);
        }

        public static bool operator ==(AdditionOperation left, AdditionOperation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AdditionOperation left, AdditionOperation right)
        {
            return !Equals(left, right);
        }
    }
}