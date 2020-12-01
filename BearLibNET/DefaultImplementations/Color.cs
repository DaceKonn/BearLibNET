namespace BearLibNET.DefaultImplementations
{
    public struct Color : IColor
    {
        public int A { get; set; }

        public int R { get; set; }

        public int B { get; set; }

        public int G { get; set; }

        public int ToArgb() => A << 24 | R << 16 | G << 8 | B;
    }
}