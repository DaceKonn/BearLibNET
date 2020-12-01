namespace BearLibNET
{
    public interface IColor
    {
        int A { get; set; }
        int B { get; set; }
        int G { get; set; }
        int R { get; set; }

        int ToArgb();
    }
}