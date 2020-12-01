using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearLibNET.Constants.TKCodes
{
    public static class MouseEventStates
    {
        public const int

        // Mouse events/states
        TK_MOUSE_LEFT = 0x80, // Buttons
        TK_MOUSE_RIGHT = 0x81,
        TK_MOUSE_MIDDLE = 0x82,
        TK_MOUSE_X1 = 0x83,
        TK_MOUSE_X2 = 0x84,
        TK_MOUSE_MOVE = 0x85, // Movement event
        TK_MOUSE_SCROLL = 0x86, // Mouse scroll event
        TK_MOUSE_X = 0x87, // Cusor position in cells
        TK_MOUSE_Y = 0x88,
        TK_MOUSE_PIXEL_X = 0x89, // Cursor position in pixels
        TK_MOUSE_PIXEL_Y = 0x8A,
        TK_MOUSE_WHEEL = 0x8B, // Scroll direction and amount
        TK_MOUSE_CLICKS = 0x8C; // Number of consecutive clicks
    }
}
