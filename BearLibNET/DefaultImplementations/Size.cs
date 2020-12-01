namespace BearLibNET.DefaultImplementations
{
    public struct Size : ISize
    {
        public Size(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int Height { get; set; }

        public int Width { get; set; }

        public bool IsEmpty => Height == 0 && Width == 0;

        public static Size Empty() => new Size()
        {
            Height = 0,
            Width = 0
        };
    }
}