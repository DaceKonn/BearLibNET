namespace BearLibNET.TKCodes
{
    /// <summary>
    /// Virtual key-codes for internal terminal states/variables.<br/>
    /// These can be accessed via terminal_state function.
    /// </summary>
    public enum VirtualKeyCodes
    {

        /// <summary>
        /// Terminal width in cells
        /// </summary>
        TK_WIDTH = 0xC0,
        /// <summary>
        /// Terminal height in cells
        /// </summary>
        TK_HEIGHT = 0xC1,
        /// <summary>
        /// Cell width in pixels
        /// </summary>
        TK_CELL_WIDTH = 0xC2,
        /// <summary>
        /// Cell height in pixels
        /// </summary>
        TK_CELL_HEIGHT = 0xC3,
        /// <summary>
        /// Current foregroung color
        /// </summary>
        TK_COLOR = 0xC4,
        /// <summary>
        /// Current background color
        /// </summary>
        TK_BKCOLOR = 0xC5,
        /// <summary>
        /// Current layer
        /// </summary>
        TK_LAYER = 0xC6,
        /// <summary>
        /// Current composition state
        /// </summary>
        TK_COMPOSITION = 0xC7,
        /// <summary>
        /// Translated ANSI code of last produced character
        /// </summary>
        TK_CHAR = 0xC8,
        /// <summary>
        /// Unicode codepoint of last produced character
        /// </summary>
        TK_WCHAR = 0xC9,
        /// <summary>
        /// Last dequeued event
        /// </summary>
        TK_EVENT = 0xCA,
        /// <summary>
        /// Fullscreen state
        /// </summary>
        TK_FULLSCREEN = 0xCB
    }
}
