using System.Collections.Generic;
using Xunit;

namespace CrossedWires.Tests
{
    public class AcceptanceTests
    {
        [Theory, MemberData(nameof(Samples))]
        public void Test1(string wire1, string wire2, int distance)
        {
            var wire1Path = Path.FromString(wire1);
            var wire2Path = Path.FromString(wire2);

            var intersections = wire1Path.IntersectionPoints(wire2Path);

            Assert.Equal(intersections.ClosestTo(new Point(0,0)), distance);
        }

        public static IEnumerable<object[]> Samples()
        {
            yield return new object[]
            {
                "R8,U5,L5,D3",
                "U7,R6,D4,L4",
                6
            };

            yield return new object[]
            {
                "R75,D30,R83,U83,L12,D49,R71,U7,L72",
                "U62,R66,U55,R34,D71,R55,D58,R83",
                159
            };

            yield return new object[]
            {
                "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51",
                "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7",
                135
            };
        }
    }
}
