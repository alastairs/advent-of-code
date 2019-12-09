using System.Collections.Generic;
using Xunit;

namespace Intcode.Tests
{
    public class AcceptanceTests
    {
        [Theory, MemberData(nameof(SimpleSampleCases))]
        public void Sample_cases_are_evaluated_correctly(string initialState, string finalState)
        {
            var program = new IntcodeParser().Parse(initialState);

            program.Execute();

            Assert.Equal(finalState, string.Join(",", program.Memory.ToArray()));
        }

        public static IEnumerable<object[]> SimpleSampleCases()
        {
            yield return new object[]
            {
                // Initial state
                "1,0,0,0," +
                "99",

                // Final state
                "2,0,0,0," +
                "99"
            };

            yield return new object[]
            {
                // Initial state
                "2,3,0,3," +
                "99",

                // Final state
                "2,3,0,6," +
                "99"
            };

            yield return new object[]
            {
                // Initial state
                "2,4,4,5," +
                "99," +
                "0",

                // Final state
                "2,4,4,5," +
                "99," +
                "9801"
            };

            yield return new object[]
            {
                // Initial state
                "1,1,1,4," +
                "99,5,6,0," +
                "99",

                // Final state
                "30,1,1,4," +
                "2,5,6,0," +
                "99"
            };

            yield return new object[]
            {
                // Initial state
                "1,9,10,3," +
                "2,3,11,0," +
                "99," +
                "30,40,50",

                // Final state
                "3500,9,10,70," +
                "2,3,11,0," +
                "99," +
                "30,40,50"
            };
        }

        [Theory, MemberData(nameof(IOSampleCases))]
        public void IO_Sample_cases_are_evaluated_correctly(string initialState, string finalState, string input, string expectedOutput)
        {
            var program = new IntcodeParser().Parse(initialState);

            var actualOutput = program.Execute(input);

            Assert.Equal(finalState, string.Join(",", program.Memory.ToArray()));
            Assert.Equal(expectedOutput, actualOutput);
        }

        public static IEnumerable<object[]> IOSampleCases()
        {
            // This program is equivalent to `echo`
            yield return new object[]
            {
                // Initial state
                "3,0,4,0,99",

                // Final state is no different
                "3,0,4,0,99",

                // Input
                "5",

                // Output is identical to input
                "5"
            };
        }
    }
}
