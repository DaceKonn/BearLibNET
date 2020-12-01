using BearLibNET.Interfaces;
using System;

namespace BearLibNET
{
    public static class Helpers
    {
        internal static string Format(string text, object[] args)
        {
            if (args != null && args.Length > 0)
                return string.Format(text, args);
            else
                return text;
        }

        internal static object ParseSize(ISizeFactory sizeFactory, string s)
        {
            string[] parts = s.Split('x');
            return sizeFactory.GetSize(int.Parse(parts[0]), int.Parse(parts[1]));
        }

        internal static object ParseBool(string s)
        {
            return s == "true";
        }

        public static Type CheckCodeType(int code)
        {
            if (Enum.IsDefined(typeof(TKCodes.InputEvents), code))
            {
                return typeof(TKCodes.InputEvents);
            }

            if (Enum.IsDefined(typeof(TKCodes.InputStates), code))
            {
                return typeof(TKCodes.InputStates);
            }

            if (Enum.IsDefined(typeof(TKCodes.VirtualKeyCodes), code))
            {
                return typeof(TKCodes.VirtualKeyCodes);
            }

            return null;
        }
    }
}
