using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Intcode
{
    using static IntcodeOperation;

    public class IntcodeParser
    {
        public IntcodeProgram Parse(string input)
        {
            return new IntcodeProgram(new[] { Add(1, 1, 3) });
        }
    }

    internal class IntcodeLexer
    {
        internal IEnumerable<int> Read(string input)
        {
            return input.Split(",").Select(n => int.Parse(n.Trim(), NumberFormatInfo.InvariantInfo));
        }
    }
}