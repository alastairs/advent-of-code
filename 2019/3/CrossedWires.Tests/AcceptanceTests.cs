using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CrossedWires.Tests
{
    public class AcceptanceTests
    {
        [Theory, MemberData(nameof(Samples))]
        public void ClosestIntersectionPoint(string wire1, string wire2, int distance, int _)
        {
            var wire1Path = Path.FromString(wire1);
            var wire2Path = Path.FromString(wire2);

            var intersections = wire1Path.IntersectionPoints(wire2Path);

            Assert.Equal(distance, intersections.Min(p => p.DistanceFrom(Point.Origin)));
        }

        [Theory, MemberData(nameof(Samples))]
        public void IntersectionPointWithShortestLength(string wire1, string wire2, int _, int noOfSteps)
        {
            var wire1Path = Path.FromString(wire1);
            var wire2Path = Path.FromString(wire2);

            var wire1Lines = wire1Path.TraceFrom(Point.Origin);
            var wire2Lines = wire2Path.TraceFrom(Point.Origin);

            var combinedWireLengths =
                wire1Path.IntersectionPoints(wire2Path)
                    .Select(intersection =>
                        CalculateLength(wire1Lines, intersection) +
                        CalculateLength(wire2Lines, intersection));

            Assert.Equal(noOfSteps, combinedWireLengths.Min());
        }

        private static int CalculateLength(IEnumerable<Line> wire1Lines, Point intersection)
        {
            var wiresToIntersection = wire1Lines.TakeWhile(l => !l.Contains(intersection));
            return wiresToIntersection.Sum(l => l.Length) +
                   Line.Between(wiresToIntersection.Last().Last(), intersection).Length;
        }

        public static IEnumerable<object[]> Samples()
        {
            yield return new object[]
            {
                "R8,U5,L5,D3",
                "U7,R6,D4,L4",
                6,
                30
            };

            yield return new object[]
            {
                "R75,D30,R83,U83,L12,D49,R71,U7,L72",
                "U62,R66,U55,R34,D71,R55,D58,R83",
                159,
                610
            };

            yield return new object[]
            {
                "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51",
                "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7",
                135,
                410
            };
        }
    }
}
