using System;

namespace BearLibNET
{
    public struct Point : IEquatable<Point>
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public bool Equals(Point other)
        {
            if (this == other)
                return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (this == (Point)obj)
                return true;
            return obj.GetType() == GetType() && Equals((Point)obj);
        }

        public override int GetHashCode() => HashCode.Combine<int, int>(X, Y);

        public static bool operator ==(Point left, Point right) => object.Equals((object)left, (object)right);

        public static bool operator !=(Point left, Point right) => !object.Equals((object)left, (object)right);
    }
}