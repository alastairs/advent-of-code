using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CrossedWires.Tests
{
    public class LineFacts
    {
        [Fact]
        public void Lines_are_equal_if_they_contain_the_same_points()
        {
            var line1 = new Line(new Point[] { (1, 1), (1, 2), (1, 3) });
            var line2 = new Line(new Point[] { (1, 1), (1, 2), (1, 3) });

            Assert.Equal(line1, line2);
        }

        [Theory, MemberData(nameof(Lines))]
        public void A_line_between_two_points_is_equal_to_a_line_through_all_intermediary_points(IList<Point> points)
        {
            var line1 = new Line(points);
            var line2 = Line.Between(points.First(), points.Last());

            Assert.Equal(line1, line2);
        }

        public static IEnumerable<object[]> Lines()
        {
            yield return new object[]
            {
                new[] { Point.Origin, (0, -1), (0, -2), (0, -3), (0, -4) }
            };

            yield return new object[]
            {
                new[] { (0, -4), (0, -3), (0, -2), (0, -1), Point.Origin }
            };

            yield return new object[]
            {
                new Point[] { (3, 5), (3, 4), (3, 3) }
            };

            yield return new object[]
            {
                new Point[] { (3, 3), (3, 4), (3, 5) }
            };

            yield return new object[]
            {
                new Point[] { (1, 0), (2, 0), (3, 0) }
            };

            yield return new object[]
            {
                new Point[] { (-3, 0), (-2, 0), (-1, 0) }
            };

            yield return new object[]
            {
                new Point[] { (-1, 0), (-2, 0), (-3, 0) }
            };

            yield return new object[]
            {
                new Point[] { (3, 0), (2, 0), (1, 0) }
            };
        }
    }
}