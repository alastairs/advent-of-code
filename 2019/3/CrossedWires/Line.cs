using System.Collections;
using System.Collections.Generic;

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
    }
}