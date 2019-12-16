using System;
using System.Linq;

namespace Intcode
{
    public class IntcodeParser
    {
        public IntcodeProgram Parse(string initialState)
        {
            if (string.IsNullOrWhiteSpace(initialState))
            {
                throw new ArgumentNullException(nameof(initialState));
            }

            return new IntcodeProgram(initialState.Split(",").Select(int.Parse));
        }
    }
}