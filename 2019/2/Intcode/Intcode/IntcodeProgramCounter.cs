using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Intcode
{
    internal class IntcodeProgramCounter : IEnumerator<IntcodeOperation>
    {
        private int _counter;
        private readonly IEnumerable<IntcodeOperation> _operations;

        public IntcodeProgramCounter(IEnumerable<IntcodeOperation> operations)
        {
            _operations = operations ?? throw new ArgumentNullException(nameof(operations));
        }

        public bool MoveNext()
        {
            if (Current == IntcodeOperation.Stop())
            {
                return false;
            }

            _counter += 4;
            return true;
        }

        public void Reset()
        {
            _counter = 0;
        }

        public IntcodeOperation Current => _operations.ElementAt(_counter);

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}