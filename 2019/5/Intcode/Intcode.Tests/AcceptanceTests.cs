﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
            Console.SetIn(new StringReader(input));

            var actualOutput = new StringBuilder();
            Console.SetOut(new StringWriter(actualOutput));
            program.Execute();

            Assert.Equal(finalState, string.Join(",", program.Memory.ToArray()));
            Assert.Equal(expectedOutput, actualOutput.ToString().Trim());
        }

        public static IEnumerable<object[]> IOSampleCases()
        {
            // This program is equivalent to `echo`
            yield return new object[]
            {
                // Initial state
                "3,0,4,0,99",

                // Final state has input loaded to address 0
                "5,0,4,0,99",

                // Input
                "5",

                // Output is identical to input
                "5"
            };

            yield return new object[]
            {
                // Initial state
                "1002,4,3,4,33",

                // Final state
                "1002,4,3,4,99",

                // Accepts no input, returns no output
                "", ""
            };

            yield return new object[]
            {
                // Initial state
                "3,13,1,13,6,6,1100,1,238,13,104,0,99,13",

                // Final state
                "3,13,1,13,6,6,1101,1,238,13,104,0,99,239",

                // Input
                "1",

                // Output
                "0"
            };
        }

        [Theory, MemberData(nameof(ComparisonSampleCases))]
        public void Comparison_sample_cases_are_evaluated_correctly(string initialState, string input, string expectedOutput)
        {
            var program = new IntcodeParser().Parse(initialState);
            Console.SetIn(new StringReader(input));

            var actualOutput = new StringBuilder();
            Console.SetOut(new StringWriter(actualOutput));
            program.Execute();

            Assert.Equal(expectedOutput, actualOutput.ToString().Trim());
        }

        public static IEnumerable<object[]> ComparisonSampleCases()
        {
            yield return new object[]
            {
                // Initial state
                "3,9,8,9,10,9,4,9,99,-1,8",

                // Input
                "8",

                // Output
                "1"
            };

            yield return new object[]
            {
                // Initial state
                "3,9,8,9,10,9,4,9,99,-1,8",

                // Input
                "-5",

                // Output
                "0"
            };

            yield return new object[]
            {
                // Initial state
                "3,9,7,9,10,9,4,9,99,-1,8",

                // Input
                "-5",

                // Output
                "1"
            };

            yield return new object[]
            {
                // Initial state
                "3,9,7,9,10,9,4,9,99,-1,8",

                // Input
                "10",

                // Output
                "0"
            };

            yield return new object[]
            {
                // Initial state
                "3,3,1108,-1,8,3,4,3,99",

                // Input
                "8",

                // Output
                "1"
            };

            yield return new object[]
            {
                // Initial state
                "3,3,1108,-1,8,3,4,3,99",

                // Input
                "-5",

                // Output
                "0"
            };

            yield return new object[]
            {
                // Initial state
                "3,3,1107,-1,8,3,4,3,99",

                // Input
                "-5",

                // Output
                "1"
            };

            yield return new object[]
            {
                // Initial state
                "3,3,1107,-1,8,3,4,3,99",

                // Input
                "10",

                // Output
                "0"
            };
        }

        [Theory, MemberData(nameof(BranchingSampleCases))]
        public void Branching_sample_cases_are_evaluated_correctly(string initialState, string input, string expectedOutput)
        {
            var program = new IntcodeParser().Parse(initialState);
            Console.SetIn(new StringReader(input));

            var actualOutput = new StringBuilder();
            Console.SetOut(new StringWriter(actualOutput));
            program.Execute();

            Assert.Equal(expectedOutput, actualOutput.ToString().Trim());
        }

        public static IEnumerable<object[]> BranchingSampleCases()
        {
            yield return new object[]
            {
                // Initial state
                "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9",

                // Input
                "0",

                // Output
                "0"
            };

            yield return new object[]
            {
                // Initial state
                "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9",

                // Input
                "1",

                // Output
                "1"
            };

            yield return new object[]
            {
                // Initial state
                "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9",

                // Input
                "-1",

                // Output
                "1"
            };

            yield return new object[]
            {
                // Initial state
                "3,3,1105,-1,9,1101,0,0,12,4,12,99,1",

                // Input
                "0",

                // Output
                "0"
            };

            yield return new object[]
            {
                // Initial state
                "3,3,1105,-1,9,1101,0,0,12,4,12,99,1",

                // Input
                "1",

                // Output
                "1"
            };

            yield return new object[]
            {
                // Initial state
                "3,3,1105,-1,9,1101,0,0,12,4,12,99,1",

                // Input
                "-1",

                // Output
                "1"
            };
        }
    }
}
