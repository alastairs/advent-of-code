using System;
using System.Linq;
using System.Runtime.Intrinsics;

namespace CrossedWires
{
    public class Vector : IEquatable<Vector>
    {
        private readonly int _xMagnitude;
        private readonly int _yMagnitude;

        private Vector(int xMagnitude, int yMagnitude)
        {
            _xMagnitude = xMagnitude;
            _yMagnitude = yMagnitude;
        }

        public static Vector FromString(string vectorDescriptor)
        {
            var magnitude = int.Parse(vectorDescriptor.Substring(1));
            var directionDescriptor = vectorDescriptor.First();

            if (directionDescriptor == 'D' || directionDescriptor == 'L') magnitude = -magnitude;
            return directionDescriptor switch
            {
                var d when d == 'U' || d == 'D' => new Vector(0, magnitude),
                var d when d == 'L' || d == 'R' => new Vector(magnitude, 0),
                _ => throw new ArgumentException($"Invalid direction descriptor '{directionDescriptor}'")
            };
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Vector);
        }

        public bool Equals(Vector other)
        {
            return Equals(this, other);
        }

        public static bool Equals(Vector v1, Vector v2)
        {
            if (ReferenceEquals(v1, v2))
            {
                return true;
            }

            if (ReferenceEquals(v1, null) || ReferenceEquals(v2, null))
            {
                return false;
            }

            return v1._xMagnitude == v2._xMagnitude &&
                   v1._yMagnitude == v2._yMagnitude;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_xMagnitude, _yMagnitude);
        }

        public static bool operator ==(Vector left, Vector right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Vector left, Vector right)
        {
            return !Equals(left, right);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a._xMagnitude + b._xMagnitude, a._yMagnitude + b._yMagnitude);
        }

        public static Line operator +(Point start, Vector v)
        {
            var end = start + (v._xMagnitude, v._yMagnitude);
            return Line.Between(start, end);
        }
    }
}