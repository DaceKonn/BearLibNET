using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearLibNET.Constants.TKCodes
{
    public static class InputEventStates
    {
        public const int
        //If key was released instead of pressed, it's code will be OR'ed withTK_KEY_RELEASED
        TK_KEY_RELEASED = 0x100,
        // Input result codes for terminal_read function.
        TK_INPUT_NONE = 0,
        TK_INPUT_CANCELLED = -1;
    }
}
