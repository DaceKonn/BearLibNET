/*
* BearLibTerminal C# wrapper
* Copyright (C) 2013-2017 Cfyz
* Modified 2020 Evan Burkey <evan@burkey.co>
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
* of the Software, and to permit persons to whom the Software is furnished to do
* so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
* FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
* COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
* IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
* CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace BearLibNET
{
    public static class Terminal
    {

        private static string Format(string text, object[] args)
        {
            if (args != null && args.Length > 0)
                return string.Format(text, args);
            else
                return text;
        }

        private static int LibraryAlignmentFromContentAlignment(ContentAlignment alignment)
        {
            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                    return 5;
                case ContentAlignment.TopCenter:
                    return 7;
                case ContentAlignment.TopRight:
                    return 6;
                case ContentAlignment.MiddleLeft:
                    return 13;
                case ContentAlignment.MiddleCenter:
                    return 15;
                case ContentAlignment.MiddleRight:
                    return 14;
                case ContentAlignment.BottomLeft:
                    return 9;
                case ContentAlignment.BottomCenter:
                    return 11;
                case ContentAlignment.BottomRight:
                    return 10;
                default:
                    return 5;
            }
        }

        /// <summary>
        /// Maps to:
        /// <code>int terminal_open();</code>
        /// 
        /// This function initializes BearLibTerminal instance, configuring the window with default parameters:<br/>
        /// <list>
        ///     <item>- 80×25 cells</item>
        ///     <item>- Fixedsys Excelsior font</item>
        ///     <item>- white text</item>
        ///     <item>- black background</item>
        /// </list>
        /// This function does not bring the window to screen. The window is not shown until the first call to refresh.<br/>
        /// Note that unless the library is initialized with successful call to open,<br/>
        /// all other library functions will do nothing but return immediately with return code (if any) indicating an error.<br/>
        /// <br/>
        /// The function returns boolean value where false means initialization has failed.<br/>
        /// Details may be found in the log file (named bearlibterminal.log by default).<br/>
        /// 
        /// </summary>
        /// <returns>The function returns boolean value where false means initialization has failed.</returns>
        public static bool Open()
        {
            return BearLibTerminalIntegration.Open();
        }

        public static void Close()
        {
            BearLibTerminalIntegration.Close();
        }

        public static void Refresh()
        {
            BearLibTerminalIntegration.Refresh();
        }

        public static bool Set(string options)
        {
            return BearLibTerminalIntegration.Set(options);
        }

        public static void Clear()
        {
            BearLibTerminalIntegration.Clear();
        }

        public static void ClearArea(int x, int y, int w, int h)
        {
            BearLibTerminalIntegration.ClearArea(x, y, w, h);
        }

        public static void ClearArea(Rectangle area)
        {
            ClearArea(area.X, area.Y, area.Width, area.Height);
        }

        public static void Crop(int x, int y, int w, int h)
        {
            BearLibTerminalIntegration.Crop(x, y, w, h);
        }

        public static void Crop(Rectangle area)
        {
            Crop(area.X, area.Y, area.Width, area.Height);
        }

        public static void Color(Color color)
        {
            BearLibTerminalIntegration.Color(color.ToArgb());
        }

        public static void Color(string name)
        {
            BearLibTerminalIntegration.Color(BearLibTerminalIntegration.ColorFromName(name));
        }

        public static void BkColor(Color color)
        {
            BearLibTerminalIntegration.BkColor(color.ToArgb());
        }

        public static void BkColor(string name)
        {
            BearLibTerminalIntegration.BkColor(BearLibTerminalIntegration.ColorFromName(name));
        }

        public static void Composition(bool enabled)
        {
            BearLibTerminalIntegration.Composition(enabled ? 1 : 0);
        }

        public static void Layer(int index)
        {
            BearLibTerminalIntegration.Layer(index);
        }

        public static void Font(string name)
        {
            BearLibTerminalIntegration.Font(name);
        }

        public static void Put(int x, int y, int code)
        {
            BearLibTerminalIntegration.Put(x, y, code);
        }

        public static void Put(Point location, int code)
        {
            Put(location.X, location.Y, code);
        }

        public static void Put(int x, int y, char code)
        {
            Put(x, y, (int)code);
        }

        public static void Put(Point location, char code)
        {
            Put(location.X, location.Y, (int)code);
        }

        public static void PutExt(int x, int y, int dx, int dy, int code)
        {
            BearLibTerminalIntegration.PutExt(x, y, dx, dy, code, null);
        }

        public static void PutExt(Point location, Point offset, int code)
        {
            BearLibTerminalIntegration.PutExt(location.X, location.Y, offset.X, offset.Y, code, null);
        }

        public static void PutExt(int x, int y, int dx, int dy, char code)
        {
            BearLibTerminalIntegration.PutExt(x, y, dx, dy, code, null);
        }

        public static void PutExt(Point location, Point offset, char code)
        {
            BearLibTerminalIntegration.PutExt(location.X, location.Y, offset.X, offset.Y, code, null);
        }

        public static void PutExt(int x, int y, int dx, int dy, int code, Color[] corners)
        {
            int[] values = new int[4];
            for (int i = 0; i < 4; i++) values[i] = corners[i].ToArgb();
            BearLibTerminalIntegration.PutExt(x, y, dx, dy, code, values);
        }

        public static void PutExt(Point location, Point offset, int code, Color[] corners)
        {
            PutExt(location.X, location.Y, offset.X, offset.Y, code, corners);
        }

        public static void PutExt(int x, int y, int dx, int dy, char code, Color[] corners)
        {
            PutExt(x, y, dx, dy, (int)code, corners);
        }

        public static void PutExt(Point location, Point offset, char code, Color[] corners)
        {
            PutExt(location.X, location.Y, offset.X, offset.Y, (int)code, corners);
        }

        public static int Pick(int x, int y)
        {
            return Pick(x, y, 0);
        }

        public static int Pick(Point location)
        {
            return Pick(location.X, location.Y, 0);
        }

        public static int Pick(int x, int y, int index)
        {
            return BearLibTerminalIntegration.Pick(x, y, index);
        }

        public static int Pick(Point location, int index)
        {
            return Pick(location.X, location.Y, index);
        }

        public static Color PickColor(int x, int y)
        {
            return PickColor(x, y, 0);
        }

        public static Color PickColor(Point location)
        {
            return PickColor(location.X, location.Y, 0);
        }

        public static Color PickColor(int x, int y, int index)
        {
            return BearLibNET.Color.FromArgb(BearLibTerminalIntegration.PickColor(x, y, index));
        }

        public static Color PickColor(Point location, int index)
        {
            return PickColor(location.X, location.Y, index);
        }

        public static Color PickBkColor(int x, int y)
        {
            return BearLibNET.Color.FromArgb(BearLibTerminalIntegration.PickBkColor(x, y));
        }

        public static Color PickBkColor(Point location)
        {
            return PickBkColor(location.X, location.Y);
        }

        public static Size Print(Rectangle layout, ContentAlignment alignment, string text, params object[] args)
        {
        	int width, height;
        	BearLibTerminalIntegration.Print(layout.X, layout.Y, layout.Width, layout.Height, LibraryAlignmentFromContentAlignment(alignment), Format(text, args), out width, out height);
        	return new Size(width, height);
        }

        public static Size Print(Rectangle layout, string text, params object[] args)
        {
            return Print(layout, ContentAlignment.TopLeft, text, args);
        }

        public static Size Print(Point location, ContentAlignment alignment, string text, params object[] args)
        {
            return Print(location.X, location.Y, alignment, text, args);
        }

        public static Size Print(Point location, string text, params object[] args)
        {
            return Print(location.X, location.Y, text, args);
        }

        public static Size Print(int x, int y, ContentAlignment alignment, string text, params object[] args)
        {
            int width, height;
            BearLibTerminalIntegration.Print(x, y, 0, 0, LibraryAlignmentFromContentAlignment(alignment), Format(text, args), out width, out height);
            return new Size(width, height);
        }

        public static Size Print(int x, int y, string text, params object[] args)
        {
            int width, height;
            BearLibTerminalIntegration.Print(x, y, 0, 0, 0, Format(text, args), out width, out height);
            return new Size(width, height);
        }

        public static Size Measure(Size bbox, string text, params object[] args)
        {
            int width, height;
            BearLibTerminalIntegration.Measure(bbox.Width, bbox.Height, Format(text, args), out width, out height);
            return new Size(width, height);
        }

        public static Size Measure(string text, params object[] args)
        {
            return Measure(new Size(), text, args);
        }

        public static bool HasInput()
        {
            return BearLibTerminalIntegration.HasInput();
        }

        public static int State(int code)
        {
            return BearLibTerminalIntegration.State(code);
        }

        public static bool Check(int code)
        {
            return State(code) > 0;
        }

        public static int Read()
        {
            return BearLibTerminalIntegration.Read();
        }

        public static int ReadStr(int x, int y, StringBuilder text, int max)
        {
            return BearLibTerminalIntegration.ReadStr(x, y, text, max);
        }

        public static int ReadStr(Point location, StringBuilder text, int max)
        {
            return ReadStr(location.X, location.Y, text, max);
        }

        public static int ReadStr(int x, int y, ref string text, int max)
        {
            StringBuilder buffer = new StringBuilder(text, max);
            int result = ReadStr(x, y, buffer, max);
            text = buffer.ToString();
            return result;
        }

        public static int ReadStr(Point location, ref string text, int max)
        {
            return ReadStr(location.X, location.Y, ref text, max);
        }

        public static int Peek()
        {
            return BearLibTerminalIntegration.Peek();
        }

        public static void Delay(int period)
        {
            BearLibTerminalIntegration.Delay(period);
        }

        public static string Get(string name, string default_value = "")
        {
            return Marshal.PtrToStringUni(BearLibTerminalIntegration.Get(name, default_value));
        }

        private static object ParseSize(string s)
        {
            string[] parts = s.Split('x');
            return new Size(int.Parse(parts[0]), int.Parse(parts[1]));
        }

        private static object ParseBool(string s)
        {
            return s == "true";
        }

        public static T Get<T>(string name, T default_value = default(T))
        {
            string result_str = Get(name);
            if (result_str.Length == 0)
            {
                return default_value;
            }
            else
            {
                try
                {
                    Type type = typeof(T);

                    if (type == typeof(Size))
                    {
                        return (T)ParseSize(result_str);
                    }
                    else if (type == typeof(bool))
                    {
                        return (T)ParseBool(result_str);
                    }
                    else if (type.IsPrimitive)
                    {
                        return (T)Convert.ChangeType(result_str, typeof(T));
                    }
                    else if (type.IsEnum)
                    {
                        return (T)System.Enum.Parse(type, result_str);
                    }
                    else
                    {
                        return (T)System.Activator.CreateInstance(type, result_str);
                    }
                }
                catch
                {
                    return default_value;
                }
            }
        }

        public static Color ColorFromName(string name)
        {
            return BearLibNET.Color.FromArgb(BearLibTerminalIntegration.ColorFromName(name));
        }
    }
}
