using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CrossedWires
{
    public sealed class Point : IEquatable<Point>
    {
        public static readonly Point Origin = new Point(0, 0);

        private int X { get; }
        private int Y { get; }

        private Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        internal static Line Between(Point a, Point b)
        {
            if (!HorizontalLine(a, b) && !VerticalLine(a, b))
            {
                throw new ArgumentException($"Points {a} and {b} must be on the same horizontal or vertical line.");
            }

            var points = HorizontalLine(a, b)
                ? CalculateRange(a.X, b.X).Select(x => new Point(x, a.Y))
                : CalculateRange(a.Y, b.Y).Select(y => new Point(a.X, y));

            return new Line(points);
        }

        private static IEnumerable<int> CalculateRange(int start, int end)
        {
            Func<int, int> iterationFunc = i => i + 1;
            Func<int, bool> testFunc = i => i <= end;

            if (start > end) // then need to go backwards through the range
            {
                iterationFunc = i => i - 1;
                testFunc = i => i >= end;
            }

            for (var i = start; testFunc(i); i = iterationFunc(i))
            {
                yield return i;
            }
        }

        private static bool HorizontalLine(Point a, Point b)
        {
            return a.Y == b.Y;
        }

        private static bool VerticalLine(Point a, Point b)
        {
            return a.X == b.X;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Point);
        }

        public bool Equals(Point other)
        {
            return Equals(this, other);
        }

        public static bool Equals(Point a, Point b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.X == b.X && a.Y == b.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Point a, Point b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(Point a, Point b)
        {
            return !Equals(a, b);
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

        public static bool operator >(Point a, Point b)
        {
            return a.X > b.X || a.Y > b.Y;
        }

        public static bool operator <(Point a, Point b)
        {
            return a.X < b.X || a.Y < b.Y;
        }

        public int DistanceFrom(Point source)
        {
            if (this == source)
            {
                return 0;
            }

            var distance = this - source;
            return Math.Abs(distance.X) + Math.Abs(distance.Y);
        }

        public static implicit operator Point((int, int) coordinates)
        {
            var (x, y) = coordinates;
            return new Point(x, y);
        }
    }
}