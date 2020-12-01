using BearLibNET.Interfaces;

namespace BearLibNET.DefaultImplementations
{
    public class SizeFactory : ISizeFactory
    {
        public ISize GetSize(int height, int width)
        {
            return new Size(height, width);
        }

        public ISize GetSize()
        {
            return new Size();
        }
    }
}
