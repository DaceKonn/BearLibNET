using BearLibNET.Interfaces;
using System;

namespace BearLibNET.DefaultImplementations
{
    public class ColorFactory : IColorFactory
    {
        public IColor FromArgb(int argb) => new Color()
        {
            A = (int)((argb & 4278190080L) >> 24),
            R = (argb & 16711680) >> 16,
            G = (argb & 65280) >> 8,
            B = argb & byte.MaxValue
        };

        public IColor FromArgb(int alpha, int red, int green, int blue)
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
    }
}
