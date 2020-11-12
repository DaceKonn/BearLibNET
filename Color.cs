using System;

namespace BearLibNET
{
    public struct Color
    {
        public int A { get; set; }

        public int R { get; set; }

        public int B { get; set; }

        public int G { get; set; }

        public static Color FromArgb(int argb) => new Color()
        {
            A = (int)((argb & 4278190080L) >> 24),
            R = (argb & 16711680) >> 16,
            G = (argb & 65280) >> 8,
            B = argb & byte.MaxValue
        };

        public static Color FromArgb(int alpha, int red, int green, int blue)
        {
            if (alpha > byte.MaxValue || red > byte.MaxValue || (green > byte.MaxValue || blue > byte.MaxValue))
                throw new ArgumentException("ARGB value over 255");
            return new Color()
            {
                A = alpha,
                R = red,
                G = green,
                B = blue
            };
        }

        public int ToArgb() => A << 24 | R << 16 | G << 8 | B;
    }
}