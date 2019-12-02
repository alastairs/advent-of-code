using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Intcode
{
    public class IntcodeProgram : IEquatable<IntcodeProgram>, IEnumerable<IntcodeOperation>
    {
        private readonly IList<IntcodeOperation> _operations;

        public IntcodeProgram(IEnumerable<IntcodeOperation> operations)
        {
            _operations = operations?.ToList() ?? throw new ArgumentNullException(nameof(operations));
        }

        public string Execute()
        {
            return string.Join(",", this.Select(o => this[o.OutputIndex] = o.Execute()));
        }

        public IntcodeOperation this[int index]
        {
            get => _operations.ElementAt(index);
            set => _operations[index] = value;
        }

        public IEnumerator<IntcodeOperation> GetEnumerator()
        {
            return new IntcodeProgramCounter(_operations);
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

            if (x is null || y is null)
            {
                return false;
            }

            return x._operations.SequenceEqual(y._operations);
        }

        public override int GetHashCode()
        {
            return _operations.GetHashCode();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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