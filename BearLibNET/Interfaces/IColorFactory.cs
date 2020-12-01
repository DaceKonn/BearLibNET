namespace BearLibNET.Interfaces
{
    public interface IColorFactory
    {
        IColor FromArgb(int argb);
        IColor FromArgb(int alpha, int red, int green, int blue);
    }
}