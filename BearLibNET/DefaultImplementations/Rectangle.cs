﻿using System;

namespace BearLibNET.DefaultImplementations
{
    public struct Rectangle : IRectangle, IEquatable<Rectangle>
    {
        public Rectangle(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }

        public int Width { get; }

        public int Height { get; }

        public int X { get; }

        public int Y { get; }

        public bool Equals(Rectangle other)
        {
            if (this == other)
                return true;
            return Width == other.Width && Height == other.Height && X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this == (Rectangle)obj)
                return true;
            return obj.GetType() == GetType() && Equals((Rectangle)obj);
        }

        public override int GetHashCode() => HashCode.Combine<int, int, int, int>(Width, Height, X, Y);

        public static bool operator ==(Rectangle left, Rectangle right) => object.Equals(left, right);

        public static bool operator !=(Rectangle left, Rectangle right) => !object.Equals(left, right);
    }
}