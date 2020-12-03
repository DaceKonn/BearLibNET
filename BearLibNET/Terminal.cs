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

using BearLibNET.DefaultImplementations;
using BearLibNET.Interfaces;
using BearLibNET.Integration;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace BearLibNET
{
    /// <summary>
    /// Base class for BearLibNEt that exposes the BearLibTerminal API
    /// </summary>
    public static class Terminal
    {
        private static IColorFactory colorFactory = null;
        private static ISizeFactory sizeFactory = null;

        /// <summary>
        /// <para>The factory used to build IColor</para>
        /// <para>See also:
        /// <list type="bullet">
        ///     <item><seealso cref="Interfaces.IColorFactory"/></item>
        ///     <item><seealso cref="DefaultImplementations.SizeFactory"/></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <value>Injected implementation or Default ColorFactory implementation</value>
        public static IColorFactory ColorFactory
        {
            private get
            {
                if (colorFactory == null)
                {
                    colorFactory = new ColorFactory();
                }
                return colorFactory;
            }

            set
            {
                colorFactory = value;
            }
        }

        /// <summary>
        /// <para>The factory used to build ISize</para>
        /// <para>See also:
        /// <list type="bullet">
        ///     <item><seealso cref="Interfaces.ISizeFactory"/></item>
        ///     <item><seealso cref="DefaultImplementations.SizeFactory"/></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <value>Injected implementation or Default <see cref="DefaultImplementations.SizeFactory"/> implementation</value>
        public static ISizeFactory SizeFactory
        {
            private get
            {
                if (sizeFactory == null)
                {
                    sizeFactory = new SizeFactory();
                }
                return sizeFactory;
            }

            set
            {
                sizeFactory = value;
            }
        }

        /// <summary>
        /// <para>Maps to:
        /// <code>int terminal_open();</code></para>
        /// 
        /// <para>This function initializes BearLibTerminal instance, configuring the window with default parameters:<br/>
        /// <list type="bullet">
        ///     <item>80×25 cells</item>
        ///     <item>Fixedsys Excelsior font</item>
        ///     <item>white text</item>
        ///     <item>black background</item>
        /// </list>
        /// This function does not bring the window to screen. The window is not shown until the first call to <see cref="Refresh"/>.
        /// Note that unless the library is initialized with successful call to open,
        /// all other library functions will do nothing but return immediately with return code (if any) indicating an error.</para>
        /// 
        /// <para>The function returns boolean value where false means initialization has failed.<br/>
        /// Details may be found in the log file (named bearlibterminal.log by default).</para>
        /// 
        /// </summary>
        /// <returns>The function returns boolean value where false means initialization has failed.</returns>
        /// 
        public static bool Open()
        {
            return BearLibTerminalIntegration.Open();
        }

        /// <summary>
        /// <para>Symmetric to <see cref="Open"/>, this function closes the window and deinitializes BearLibTerminal instance.</para>
        /// </summary>
        public static void Close()
        {
            BearLibTerminalIntegration.Close();
        }

        /// <summary>
        /// <para>This function commits the scene for output. It also has an effect of redrawing the scene.</para>
        /// 
        /// <para>BearLibTerminal does not draw to screen immediately upon <see cref="Put(int, int, int)"/> (and it's overloads) or <see cref="Print(int, int, ContentAlignment, string, object[])"/> (and it's overloads) calls.<br/>
        /// Instead, the scene is constructed off-screen in a double-buffered manner.<br/>
        /// If the contents of the window are destroyed for some reason (for example, the window has been obstructed and operating system asking it to refresh),<br/>
        /// BearLibTerminal redraws an already commited “frontbuffer” scene. Only when this <see cref="Refresh"/> function is called the modified scene will be actually brought to screen.</para>
        /// 
        /// <para>The first call to this function since library initialization will show the window on screen.<br/>
        /// Between the <see cref="Open"/> and first <see cref="Refresh"/> calls, the window stays invisible.</para>
        /// 
        /// </summary>
        public static void Refresh()
        {
            BearLibTerminalIntegration.Refresh();
        }

        /// <summary>
        /// <para>This is probably the most complex function in BearLibTerminal API.</para>
        /// <para>Configuring library options and mechanics, managing fonts, tilesets and even configuration file is performed with it.</para>
        /// <para>This method is transactional, if one of the options in the string fail, then all are rolledback.</para>
        /// <example>
        /// The function accepts a “configuration string” with various options described in it:
        /// <code>
        /// window.title='game';<br/>
        /// font: UbuntuMono-R.ttf, size=12;<br/>
        /// ini.settings.tile-size=16;<br/>
        /// </code>
        /// </example>
        /// <para>More on configuration can be found here: 
        /// <a href="http://foo.wyrd.name/en:bearlibterminal:reference:configuration">
        /// http://foo.wyrd.name/en:bearlibterminal:reference:configuration
        /// </a> 
        /// </para>
        /// </summary>
        /// <param name="options">string containing options</param>
        /// <returns>Returns True if all options from string were set</returns>
        public static bool Set(string options)
        {
            return BearLibTerminalIntegration.Set(options);
        }

        /// <summary>
        /// This function clears entire scene (all <see cref="Layer(int)">layers</see>). It also sets background color of every cell to the currently selected background color.
        /// </summary>
        public static void Clear()
        {
            BearLibTerminalIntegration.Clear();
        }

        /// <summary>
        /// <para>This function clears a part of the currently selected <see cref="Layer(int)">layer</see>.<br/>
        /// The arguments specify top-left corner and a size of a rectangular area to be cleared.<br/>
        /// When called on the first layer, it also sets background color of affected cells to the currently selected background color.</para>
        /// <para>
        /// See also:
        /// <list type="bullet">
        /// <item><seealso cref="ClearArea(IRectangle)"/></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public static void ClearArea(int x, int y, int w, int h)
        {
            BearLibTerminalIntegration.ClearArea(x, y, w, h);
        }

        /// <summary>
        /// <para>This function clears a part of the currently selected <see cref="Layer(int)">layer</see>.<br/>
        /// The arguments specify top-left corner and a size of a rectangular area to be cleared.<br/>
        /// When called on the first layer, it also sets background color of affected cells to the currently selected background color.</para>
        /// <para>
        /// See also:
        /// <list type="bullet">
        /// <item><seealso cref="ClearArea(int, int, int, int)"/></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="area"></param>
        public static void ClearArea(IRectangle area)
        {
            ClearArea(area.X, area.Y, area.Width, area.Height);
        }

        /// <summary>
        /// <para>
        /// This function sets a crop area of the current <see cref="Layer(int)">layer</see>.<br/>
        /// Dimensions of the area are expressed in cells. <br/>
        /// Cropping is disabled either by setting area's width or height to zero or by clearing entire scene with <see cref="Clear"/>.
        /// </para>
        /// <para>
        /// See also:
        /// <list type="bullet">
        /// <item><seealso cref="Crop(IRectangle)"/></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public static void Crop(int x, int y, int w, int h)
        {
            BearLibTerminalIntegration.Crop(x, y, w, h);
        }

        /// <summary>
        /// <para>
        /// This function sets a crop area of the current <see cref="Layer(int)">layer</see>.<br/>
        /// Dimensions of the area are expressed in cells. <br/>
        /// Cropping is disabled either by setting area's width or height to zero or by clearing entire scene with <see cref="Clear"/>.
        /// </para>
        /// <para>
        /// See also:
        /// <list type="bullet">
        /// <item><seealso cref="Crop(int, int, int, int)"/></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="area"></param>
        public static void Crop(IRectangle area)
        {
            Crop(area.X, area.Y, area.Width, area.Height);
        }

        public static void Color(IColor color)
        {
            BearLibTerminalIntegration.Color(color.ToArgb());
        }

        public static void Color(string name)
        {
            BearLibTerminalIntegration.Color(BearLibTerminalIntegration.ColorFromName(name));
        }

        public static void BkColor(IColor color)
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

        public static void Put(IPoint location, int code)
        {
            Put(location.X, location.Y, code);
        }

        public static void Put(int x, int y, char code)
        {
            Put(x, y, (int)code);
        }

        public static void Put(IPoint location, char code)
        {
            Put(location.X, location.Y, (int)code);
        }

        public static void PutExt(int x, int y, int dx, int dy, int code)
        {
            BearLibTerminalIntegration.PutExt(x, y, dx, dy, code, null);
        }

        public static void PutExt(IPoint location, IPoint offset, int code)
        {
            BearLibTerminalIntegration.PutExt(location.X, location.Y, offset.X, offset.Y, code, null);
        }

        public static void PutExt(int x, int y, int dx, int dy, char code)
        {
            BearLibTerminalIntegration.PutExt(x, y, dx, dy, code, null);
        }

        public static void PutExt(IPoint location, IPoint offset, char code)
        {
            BearLibTerminalIntegration.PutExt(location.X, location.Y, offset.X, offset.Y, code, null);
        }

        public static void PutExt(int x, int y, int dx, int dy, int code, IColor[] corners)
        {
            int[] values = new int[4];
            for (int i = 0; i < 4; i++) values[i] = corners[i].ToArgb();
            BearLibTerminalIntegration.PutExt(x, y, dx, dy, code, values);
        }

        public static void PutExt(IPoint location, IPoint offset, int code, IColor[] corners)
        {
            PutExt(location.X, location.Y, offset.X, offset.Y, code, corners);
        }

        public static void PutExt(int x, int y, int dx, int dy, char code, IColor[] corners)
        {
            PutExt(x, y, dx, dy, (int)code, corners);
        }

        public static void PutExt(IPoint location, IPoint offset, char code, IColor[] corners)
        {
            PutExt(location.X, location.Y, offset.X, offset.Y, (int)code, corners);
        }

        public static int Pick(int x, int y)
        {
            return Pick(x, y, 0);
        }

        public static int Pick(IPoint location)
        {
            return Pick(location.X, location.Y, 0);
        }

        public static int Pick(int x, int y, int index)
        {
            return BearLibTerminalIntegration.Pick(x, y, index);
        }

        public static int Pick(IPoint location, int index)
        {
            return Pick(location.X, location.Y, index);
        }

        /// <summary>
        /// Returns a color of a tile in the specified cell.
        /// <para>
        /// See also:
        /// <list type="bullet">
        /// <item><seealso cref="PickColor(int, int, int)"/></item>
        /// <item><seealso cref="PickColor(IPoint)"/></item>
        /// <item><seealso cref="PickColor(IPoint, int)"/></item>
        /// <item><seealso cref="PickBkColor(int, int)"/></item>
        /// <item><seealso cref="PickBkColor(IPoint)"/></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static IColor PickColor(int x, int y)
        {
            return PickColor(x, y, 0);
        }

        /// <summary>
        /// Returns a color of a tile in the specified cell.
        /// <para>
        /// See also:
        /// <list type="bullet">
        /// <item><seealso cref="PickColor(int, int)"/></item>
        /// <item><seealso cref="PickColor(int, int, int)"/></item>
        /// <item><seealso cref="PickColor(IPoint, int)"/></item>
        /// <item><seealso cref="PickBkColor(int, int)"/></item>
        /// <item><seealso cref="PickBkColor(IPoint)"/></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static IColor PickColor(IPoint location)
        {
            return PickColor(location.X, location.Y, 0);
        }

        /// <summary>
        /// Returns a color of a tile in the specified cell.
        /// <para>
        /// See also:
        /// <list type="bullet">
        /// <item><seealso cref="PickColor(int, int)"/></item>
        /// <item><seealso cref="PickColor(IPoint)"/></item>
        /// <item><seealso cref="PickColor(IPoint, int)"/></item>
        /// <item><seealso cref="PickBkColor(int, int)"/></item>
        /// <item><seealso cref="PickBkColor(IPoint)"/></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static IColor PickColor(int x, int y, int index)
        {
            return ColorFactory.FromArgb(BearLibTerminalIntegration.PickColor(x, y, index));
        }

        /// <summary>
        /// Returns a color of a tile in the specified cell.
        /// <para>
        /// See also:
        /// <list type="bullet">
        /// <item><seealso cref="PickColor(int, int)"/></item>
        /// <item><seealso cref="PickColor(int, int, int)"/></item>
        /// <item><seealso cref="PickColor(IPoint)"/></item>
        /// <item><seealso cref="PickBkColor(int, int)"/></item>
        /// <item><seealso cref="PickBkColor(IPoint)"/></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="location"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static IColor PickColor(IPoint location, int index)
        {
            return PickColor(location.X, location.Y, index);
        }

        /// <summary>
        /// Returns a background color of the specified cell.
        /// <para>
        /// See also:
        /// <list type="bullet">
        /// <item><seealso cref="PickBkColor(IPoint)"/></item>
        /// <item><seealso cref="PickColor(int, int)"/></item>
        /// <item><seealso cref="PickColor(int, int, int)"/></item>
        /// <item><seealso cref="PickColor(IPoint)"/></item>
        /// <item><seealso cref="PickColor(IPoint, int)"/></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static IColor PickBkColor(int x, int y)
        {
            return ColorFactory.FromArgb(BearLibTerminalIntegration.PickBkColor(x, y));
        }

        /// <summary>
        /// Returns a background color of the specified cell.
        /// <para>
        /// See also:
        /// <list type="bullet">
        /// <item><seealso cref="PickBkColor(int, int)"/></item>
        /// <item><seealso cref="PickColor(int, int)"/></item>
        /// <item><seealso cref="PickColor(int, int, int)"/></item>
        /// <item><seealso cref="PickColor(IPoint)"/></item>
        /// <item><seealso cref="PickColor(IPoint, int)"/></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static IColor PickBkColor(IPoint location)
        {
            return PickBkColor(location.X, location.Y);
        }

        public static ISize Print(IRectangle layout, ContentAlignment alignment, string text, params object[] args)
        {
            BearLibTerminalIntegration.Print(layout.X, layout.Y, layout.Width, layout.Height, (int)alignment, Helpers.Format(text, args), out int width, out int height);
            return new DefaultImplementations.Size(width, height);
        }

        public static ISize Print(IRectangle layout, string text, params object[] args)
        {
            return Print(layout, ContentAlignment.TopLeft, text, args);
        }

        public static ISize Print(IPoint location, ContentAlignment alignment, string text, params object[] args)
        {
            return Print(location.X, location.Y, alignment, text, args);
        }

        public static ISize Print(IPoint location, string text, params object[] args)
        {
            return Print(location.X, location.Y, text, args);
        }

        public static ISize Print(int x, int y, ContentAlignment alignment, string text, params object[] args)
        {
            BearLibTerminalIntegration.Print(x, y, 0, 0, (int)alignment, Helpers.Format(text, args), out int width, out int height);
            return SizeFactory.GetSize(width, height);
        }

        public static ISize Print(int x, int y, string text, params object[] args)
        {
            BearLibTerminalIntegration.Print(x, y, 0, 0, 0, Helpers.Format(text, args), out int width, out int height);
            return SizeFactory.GetSize(width, height);
        }

        public static ISize Measure(ISize bbox, string text, params object[] args)
        {
            BearLibTerminalIntegration.Measure(bbox.Width, bbox.Height, Helpers.Format(text, args), out int width, out int height);
            return SizeFactory.GetSize(width, height);
        }

        public static ISize Measure(string text, params object[] args)
        {
            return Measure(SizeFactory.GetSize(), text, args);
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

        public static int ReadStr(IPoint location, StringBuilder text, int max)
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

        public static int ReadStr(IPoint location, ref string text, int max)
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

        public static T Get<T>(string name, T default_value = default)
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

                    if (typeof(ISize).IsAssignableFrom(type))
                    {
                        return (T)Helpers.ParseSize(SizeFactory, result_str);
                    }
                    else if (type == typeof(bool))
                    {
                        return (T)Helpers.ParseBool(result_str);
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

        public static IColor ColorFromName(string name)
        {
            return ColorFactory.FromArgb(BearLibTerminalIntegration.ColorFromName(name));
        }

        /// <summary>
        /// Exposes some of BearLibTerminal API but typed with Enums instad of integers
        /// </summary>
        public class Typed
        {
            public static TKCodes.InputEvents Read() => (TKCodes.InputEvents)BearLibTerminalIntegration.Read();

            public static TKCodes.InputEvents Peek() => (TKCodes.InputEvents)BearLibTerminalIntegration.Peek();

            public static int State(TKCodes.InputEvents code) => BearLibTerminalIntegration.State((int)code);

            public static int State(TKCodes.InputStates code) => BearLibTerminalIntegration.State((int)code);

            public static int State(TKCodes.VirtualKeyCodes code) => BearLibTerminalIntegration.State((int)code);

            public static bool Check(TKCodes.InputEvents code) => State(code) > 0;

            public static bool Check(TKCodes.InputStates code) => State(code) > 0;

            public static bool Check(TKCodes.VirtualKeyCodes code) => State(code) > 0;
        }
    }
}
