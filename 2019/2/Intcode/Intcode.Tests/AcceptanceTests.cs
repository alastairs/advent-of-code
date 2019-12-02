using System.Collections.Generic;
using Xunit;

namespace Intcode.Tests
{
    public class AcceptanceTests
    {
        [Theory, MemberData(nameof(SampleCases))]
        public void Sample_cases_are_evaluated_correctly(string initialState, string finalState)
        {
            var program = new IntcodeParser().Parse(initialState);

            var result = program.Execute();

            Assert.Equal(finalState, result);
        }

        public static IEnumerable<object[]> SampleCases()
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
    }
}
