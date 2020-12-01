using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearLibNET.Constants.TKCodes
{
    public static class VirtualKeyCodes
    {
        public const int
        // Virtual key-codes for internal terminal states/variables.
        // These can be accessed via terminal_state function.
        TK_WIDTH = 0xC0, // Terminal width in cells
        TK_HEIGHT = 0xC1, // Terminal height in cells
        TK_CELL_WIDTH = 0xC2, // Cell width in pixels
        TK_CELL_HEIGHT = 0xC3, // Cell height in pixels
        TK_COLOR = 0xC4, // Current foregroung color
        TK_BKCOLOR = 0xC5, // Current background color
        TK_LAYER = 0xC6, // Current layer
        TK_COMPOSITION = 0xC7, // Current composition state
        TK_CHAR = 0xC8, // Translated ANSI code of last produced character
        TK_WCHAR = 0xC9, // Unicode codepoint of last produced character
        TK_EVENT = 0xCA, // Last dequeued event
        TK_FULLSCREEN = 0xCB; // Fullscreen state
    }
}
