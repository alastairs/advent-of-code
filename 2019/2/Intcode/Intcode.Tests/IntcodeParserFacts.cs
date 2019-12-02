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
    }
}
