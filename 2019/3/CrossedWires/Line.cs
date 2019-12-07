using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrossedWires
{
    public class Line : IEnumerable<Point>
    {
        private readonly IEnumerable<Point> _points;

        public Line(IEnumerable<Point> points)
        {
            _points = points;
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return _points.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static Line Between(Point a, Point b)
        {
            return Point.Between(a, b);
        }

        public int Length => _points.Count() - 1;

        public override string ToString()
        {
            return $"{_points.First()} -> {_points.Last()} (Length {Length})";
        }
    }
}