using System;
using System.Collections.Generic;
using Xunit;

namespace CrossedWires.Tests
{
    public class VectorFacts
    {
        [Fact]
        public void Vectors_are_equal_in_direction_and_magnitude()
        {
            var magnitude = new Random().Next();
            var vector1 = Vector.FromString($"U{magnitude}");
            var vector2 = Vector.FromString($"U{magnitude}");

            Assert.Equal(vector1, vector2);
        }

        [Theory]
        [InlineData("U1", "U2", "U3")]
        [InlineData("U2", "U2", "U4")]
        [InlineData("U5", "D2", "U3")]
        [InlineData("U5", "D5", "U0")]
        [InlineData("L2", "R2", "R0")]
        [InlineData("L5", "R2", "L3")]
        public void Vector_addition_results_in_a_combined_vector(string descriptor1, string descriptor2, string resultDescriptor)
        {
            var v1 = Vector.FromString(descriptor1);
            var v2 = Vector.FromString(descriptor2);
            var result = Vector.FromString(resultDescriptor);

            Assert.Equal(v1 + v2, result);
        }

        [Theory]
        [MemberData(nameof(Lines))]
        public void Applying_the_vector_to_the_start_point_gives_a_line(Point start, Vector v, Point end)
        {
            Assert.Equal(start + v, Line.Between(start, end));
        }

        public static IEnumerable<object[]> Lines()
        {
            yield return new object[] { Point.Origin, Vector.FromString("U4"), (0, 4) };
            yield return new object[] { (10, -3), Vector.FromString("R100"), (110, -3) };
            yield return new object[] { Point.Origin, Vector.FromString("R0"), Point.Origin };
        }
    }
}
