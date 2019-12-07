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

            var possibilities = Enumerable.Range(start, end - start).Where(MatchesAllRequirements).ToList();
            Console.WriteLine($"There are {possibilities.Count} potential passwords, and they are:");
            foreach (var guess in possibilities)
            {
                Console.WriteLine("  {0}", guess);
            }
        }

        private static bool MatchesAllRequirements(int guess)
        {
            var digits = guess.ToString().AsSpan();

            var hasTwoSequentialDigits = false;
            for (var d = 0; d < digits.Length - 1; d++)
            {
                // Digits must always increase or stay the same
                if (digits[d] > digits[d + 1])
                {
                    return false;
                }

                if (d < 5 && digits[d] == digits[d + 1])
                {
                    hasTwoSequentialDigits = true;
                }

                if (d < 4 && hasTwoSequentialDigits && digits[d] == digits[d + 2])
                {
                    hasTwoSequentialDigits = false;
                }

                if (d > 0 && hasTwoSequentialDigits && digits[d] == digits[d - 1])
                {
                    hasTwoSequentialDigits = false;
                }
            }

            return hasTwoSequentialDigits;
        }
    }
}
