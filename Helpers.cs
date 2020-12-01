using BearLibNET.Interfaces;

namespace BearLibNET
{
    internal static class Helpers
    {
        public static string Format(string text, object[] args)
        {
            if (args != null && args.Length > 0)
                return string.Format(text, args);
            else
                return text;
        }

        public static object ParseSize(ISizeFactory sizeFactory, string s)
        {
            string[] parts = s.Split('x');
            return sizeFactory.GetSize(int.Parse(parts[0]), int.Parse(parts[1]));
        }

        public static object ParseBool(string s)
        {
            return s == "true";
        }
    }
}
