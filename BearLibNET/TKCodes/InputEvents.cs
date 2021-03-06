﻿namespace BearLibNET.TKCodes
{
    /// <summary>
    /// Input events codes for:
    /// <list type="bullet">
    /// <item>keyboard</item>
    /// <item>mouse</item>
    /// <item>window actions</item>
    /// </list>
    /// </summary>
    public enum InputEvents
    {
        /// <summary>
        /// Input result codes for terminal_read function.
        /// </summary>
        TK_INPUT_NONE = 0,

        /// <summary>
        /// Input result codes for terminal_read function.
        /// </summary>
        TK_INPUT_CANCELLED = -1,

        #region keyboard input evetns

        TK_A = 0x04,
        TK_B = 0x05,
        TK_C = 0x06,
        TK_D = 0x07,
        TK_E = 0x08,
        TK_F = 0x09,
        TK_G = 0x0A,
        TK_H = 0x0B,
        TK_I = 0x0C,
        TK_J = 0x0D,
        TK_K = 0x0E,
        TK_L = 0x0F,
        TK_M = 0x10,
        TK_N = 0x11,
        TK_O = 0x12,
        TK_P = 0x13,
        TK_Q = 0x14,
        TK_R = 0x15,
        TK_S = 0x16,
        TK_T = 0x17,
        TK_U = 0x18,
        TK_V = 0x19,
        TK_W = 0x1A,
        TK_X = 0x1B,
        TK_Y = 0x1C,
        TK_Z = 0x1D,
        TK_1 = 0x1E,
        TK_2 = 0x1F,
        TK_3 = 0x20,
        TK_4 = 0x21,
        TK_5 = 0x22,
        TK_6 = 0x23,
        TK_7 = 0x24,
        TK_8 = 0x25,
        TK_9 = 0x26,
        TK_0 = 0x27,
        TK_RETURN_or_ENTER = 0x28,
        //TK_ENTER = 0x28,
        TK_ESCAPE = 0x29,
        TK_BACKSPACE = 0x2A,
        TK_TAB = 0x2B,
        TK_SPACE = 0x2C,
        TK_MINUS = 0x2D,
        TK_EQUALS = 0x2E,
        TK_LBRACKET = 0x2F,
        TK_RBRACKET = 0x30,
        TK_BACKSLASH = 0x31,
        TK_SEMICOLON = 0x33,
        TK_APOSTROPHE = 0x34,
        TK_GRAVE = 0x35,
        TK_COMMA = 0x36,
        TK_PERIOD = 0x37,
        TK_SLASH = 0x38,
        TK_F1 = 0x3A,
        TK_F2 = 0x3B,
        TK_F3 = 0x3C,
        TK_F4 = 0x3D,
        TK_F5 = 0x3E,
        TK_F6 = 0x3F,
        TK_F7 = 0x40,
        TK_F8 = 0x41,
        TK_F9 = 0x42,
        TK_F10 = 0x43,
        TK_F11 = 0x44,
        TK_F12 = 0x45,
        TK_PAUSE = 0x48,
        TK_INSERT = 0x49,
        TK_HOME = 0x4A,
        TK_PAGEUP = 0x4B,
        TK_DELETE = 0x4C,
        TK_END = 0x4D,
        TK_PAGEDOWN = 0x4E,
        TK_RIGHT = 0x4F,
        TK_LEFT = 0x50,
        TK_DOWN = 0x51,
        TK_UP = 0x52,
        TK_KP_DIVIDE = 0x54,
        TK_KP_MULTIPLY = 0x55,
        TK_KP_MINUS = 0x56,
        TK_KP_PLUS = 0x57,
        TK_KP_ENTER = 0x58,
        TK_KP_1 = 0x59,
        TK_KP_2 = 0x5A,
        TK_KP_3 = 0x5B,
        TK_KP_4 = 0x5C,
        TK_KP_5 = 0x5D,
        TK_KP_6 = 0x5E,
        TK_KP_7 = 0x5F,
        TK_KP_8 = 0x60,
        TK_KP_9 = 0x61,
        TK_KP_0 = 0x62,
        TK_KP_PERIOD = 0x63,
        TK_SHIFT = 0x70,
        TK_CONTROL = 0x71,
        TK_ALT = 0x72,

        #endregion

        #region mouse input events

        // Buttons
        TK_MOUSE_LEFT = 0x80,
        TK_MOUSE_RIGHT = 0x81,
        TK_MOUSE_MIDDLE = 0x82,
        /// <summary>
        /// Mouse X1 button
        /// </summary>
        TK_MOUSE_X1 = 0x83,
        /// <summary>
        /// Mouse X2 button
        /// </summary>
        TK_MOUSE_X2 = 0x84,

        /// <summary>
        /// Movement event
        /// </summary>
        TK_MOUSE_MOVE = 0x85,
        /// <summary>
        /// Mouse scroll event
        /// </summary>
        TK_MOUSE_SCROLL = 0x86, // 

        /// <summary>
        /// Scroll direction and amount
        /// </summary>
        TK_MOUSE_WHEEL = 0x8B,

        #endregion

        #region window evetns

        /// <summary>
        /// Window close input event
        /// </summary>
        TK_CLOSE = 0xE0,

        /// <summary>
        /// Window resized input event
        /// </summary>
        TK_RESIZED = 0xE1

        #endregion
    }
}
