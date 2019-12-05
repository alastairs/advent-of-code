using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CrossedWires
{
    public class PointCollection : ICollection<Point>
    {
        private readonly Collection<Point> _points = new Collection<Point>();

        public int ClosestTo(Point point)
        {
            return 0;
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return _points.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Point item)
        {
            _points.Add(item);
        }

        public void Clear()
        {
            _points.Clear();
        }

        public bool Contains(Point item)
        {
            return _points.Contains(item);
        }

        public void CopyTo(Point[] array, int arrayIndex)
        {
            _points.CopyTo(array, arrayIndex);
        }

        public bool Remove(Point item)
        {
            return _points.Remove(item);
        }

        public int Count => _points.Count;

        public bool IsReadOnly => false;
    }

    public class Point
    {
        private readonly int _x;
        private readonly int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}