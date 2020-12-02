using System;
using System.Runtime.InteropServices;
using System.Text;

namespace BearLibNET.Integration
{
    internal sealed class BearLibTerminalIntegration
    {
        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_open", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Open();

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_close", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Close();

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_refresh", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh();

        [DllImport("BearLibTerminal.dll", CharSet = CharSet.Unicode, EntryPoint = "terminal_set16", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Set(string options);

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_clear", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Clear();

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_clear_area", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearArea(int x, int y, int w, int h);

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_crop", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Crop(int x, int y, int w, int h);

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_color", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Color(int argb);

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_bkcolor", CallingConvention = CallingConvention.Cdecl)]
        public static extern void BkColor(int argb);

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_composition", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Composition(int mode);

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_layer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Layer(int index);

        [DllImport("BearLibTerminal.dll", CharSet = CharSet.Unicode, EntryPoint = "terminal_font16", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Font(string name);

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_put", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Put(int x, int y, int code);

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_put_ext", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PutExt(int x, int y, int dx, int dy, int code, [MarshalAs(UnmanagedType.LPArray)] int[] corners);

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_pick", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Pick(int x, int y, int index);

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_pick_color", CallingConvention = CallingConvention.Cdecl)]
        public static extern int PickColor(int x, int y, int index);

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_pick_bkcolor", CallingConvention = CallingConvention.Cdecl)]
        public static extern int PickBkColor(int x, int y);

        [DllImport("BearLibTerminal.dll", CharSet = CharSet.Unicode, EntryPoint = "terminal_print_ext16", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Print(int x, int y, int w, int h, int align, string text, out int out_w, out int out_h);

        [DllImport("BearLibTerminal.dll", CharSet = CharSet.Unicode, EntryPoint = "terminal_measure_ext16", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Measure(int width, int height, string text, out int out_w, out int out_h);

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_has_input", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasInput();

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_state", CallingConvention = CallingConvention.Cdecl)]
        public static extern int State(int code);

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_read", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Read();

        [DllImport("BearLibTerminal.dll", CharSet = CharSet.Unicode, EntryPoint = "terminal_read_str16", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadStr(int x, int y, StringBuilder text, int max);

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_peek", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Peek();

        [DllImport("BearLibTerminal.dll", EntryPoint = "terminal_delay", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Delay(int period);

        [DllImport("BearLibTerminal.dll", CharSet = CharSet.Unicode, EntryPoint = "terminal_get16", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Get(string key, string default_value);

        [DllImport("BearLibTerminal.dll", CharSet = CharSet.Unicode, EntryPoint = "color_from_name16", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ColorFromName(string name);
    }
}
