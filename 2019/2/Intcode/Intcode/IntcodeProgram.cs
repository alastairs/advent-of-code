using System;
using System.Collections.Generic;
using System.Linq;

namespace Intcode
{
    public class IntcodeProgram : IEquatable<IntcodeProgram>
    {
        private readonly IEnumerable<IntcodeOperation> _operations;

        public IntcodeProgram(IEnumerable<IntcodeOperation> operations)
        {
            _operations = operations ?? throw new ArgumentNullException(nameof(operations));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as IntcodeProgram);
        }

        public bool Equals(IntcodeProgram other)
        {
            return Equals(this, other);
        }

        private static bool Equals(IntcodeProgram x, IntcodeProgram y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }

            return x._operations.SequenceEqual(y._operations);
        }

        public override int GetHashCode()
        {
            return _operations.GetHashCode();
        }

        public static bool operator ==(IntcodeProgram left, IntcodeProgram right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IntcodeProgram left, IntcodeProgram right)
        {
            return !Equals(left, right);
        }
    }
}