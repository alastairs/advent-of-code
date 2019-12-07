using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;
using Xunit.Abstractions;

namespace SecureContainer
{
    public class SecureContainerFacts
    {
        private ITestOutputHelper Console { get; }

        public SecureContainerFacts(ITestOutputHelper testOutputHelper)
        {
            Console = testOutputHelper;
        }

        [Fact]
        public void Brute_force_the_password()
        {
            const int start = 134564;
            const int end = 585159;

            var searchSpaceSize = end - start;
            Console.WriteLine($"Beginning search across space of {searchSpaceSize} integers");

            var searchSpace = new List<int>(searchSpaceSize);
            for (var i = start; i <= end; i++)
            {
                if (HasTwoAdjacentIdenticalDigits(i) && HasNoSequentiallyDecreasingDigits(i))
                {
                    searchSpace.Add(i);
                }
            }

            Console.WriteLine($"There are {searchSpace.Count} potential passwords, and they are:");
            foreach (var guess in searchSpace)
            {
                Console.WriteLine("  {0}", guess);
            }
        }

        private static bool HasTwoAdjacentIdenticalDigits(int guess)
        {
            var digits = $"{guess}".AsSpan();

            for (var d = 0; d < digits.Length - 1; d++)
            {
                if (digits[d] == digits[d + 1])
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HasNoSequentiallyDecreasingDigits(int guess)
        {
            var digits = $"{guess}".AsSpan();

            for (var d = 0; d < digits.Length - 1; d++)
            {
                if (digits[d] > digits[d + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
