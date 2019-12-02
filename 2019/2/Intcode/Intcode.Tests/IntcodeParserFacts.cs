using Xunit;

namespace Intcode.Tests
{
    using static IntcodeOperation;

    public class IntcodeParserFacts
    {
        private readonly IntcodeParser _sut = new IntcodeParser();

        [Fact]
        public void Opcode_1_Is_Addition()
        {
            const string input = "1, 1, 1, 3";

            var program = _sut.Parse(input);

            var expected = new IntcodeProgram(new[] { Add(1, 1, 3) });
            Assert.Equal(expected, program);
        }

        [Fact]
        public void Opcode_2_Is_Multiplication()
        {
            const string input = "2, 1, 1, 3";

            var program = _sut.Parse(input);

            var expected = new IntcodeProgram(new[] { Multiply(1, 1, 3) });
            Assert.Equal(expected, program);
        }

        [Fact]
        public void Opcode_99_is_stop()
        {
            const string input = "99";

            var program = _sut.Parse(input);

            var expected = new IntcodeProgram(new[] { Stop() });
            Assert.Equal(expected, program);
        }

        [Fact]
        public void Multiple_opcodes_and_arguments_form_a_program()
        {
            const string input = "1, 1, 1, 9," +
                                 "2, 1, 1, 10," +
                                 "99," +
                                 "0," +
                                 "0";

            var program = _sut.Parse(input);

            var expected = new IntcodeProgram(new[]
            {
                Add(1, 1, 9),
                Multiply(1, 1, 10),
                Stop()
            });

            Assert.Equal(program, expected);
        }
    }
}
