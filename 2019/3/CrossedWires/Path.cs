using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrossedWires
{
    public class Path : IEnumerable<Vector>
    {
        private readonly IEnumerable<Vector> _path;

        private Path(IEnumerable<Vector> vectors)
        {
            _path = vectors;
        }

        public static Path FromString(string pathDescriptor)
        {
            return new Path(
                pathDescriptor.Split(",")
                    .Select(v => v.Trim())
                    .Select(Vector.FromString));
        }

        public ISet<Point> IntersectionPoints(Path wire2Path)
        {
            var wire1Lines = TraceFrom(Point.Origin);
            var wire2Lines = wire2Path.TraceFrom(Point.Origin);

            var wire1Points = wire1Lines.SelectMany(l => l);
            var wire2Points = wire2Lines.SelectMany(l => l);

            return new HashSet<Point>(wire1Points.Intersect(wire2Points).Except(new[] { Point.Origin }).Distinct());
        }

        private IEnumerable<Line> TraceFrom(Point start)
        {
            var lines = new List<Line>();

            foreach (var vector in _path)
            {
                var line = start + vector;
                start = line.Last();
                lines.Add(line);
            }

            return lines;
        }

        public IEnumerator<Vector> GetEnumerator()
        {
            return _path.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}