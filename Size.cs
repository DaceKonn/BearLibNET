namespace BearLibNET
{
    public struct Size
    {
        public Size(int h, int w)
        {
            Height = h;
            Width = w;
        }

        public int Height { get; set; }

        public int Width { get; set; }

        public bool IsEmpty => this.Height == 0 && this.Width == 0;

        public static Size Empty() => new Size()
        {
            Height = 0,
            Width = 0
        };
    }
}