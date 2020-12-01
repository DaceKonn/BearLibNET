namespace BearLibNET.Interfaces
{
    public interface ISizeFactory
    {
        ISize GetSize(int height, int width);

        ISize GetSize();
    }
}