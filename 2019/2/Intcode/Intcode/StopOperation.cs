using System;

namespace Intcode
{
    public class StopOperation : IntcodeOperation, IEquatable<StopOperation>
    {
        public const int Opcode = 99;

        public override bool Equals(object obj)
        {
            return Equals(obj as StopOperation);
        }

        public bool Equals(StopOperation other)
        {
            return Equals(this, other);
        }

        public static bool Equals(StopOperation x, StopOperation y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }

            // All non-null instances of StopOperation are equal
            return true;
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public static bool operator ==(StopOperation left, StopOperation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(StopOperation left, StopOperation right)
        {
            return !Equals(left, right);
        }
    }
}