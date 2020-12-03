namespace BearLibNET.TKCodes
{
    /// <summary>
    /// States of inputs<br/>
    /// Mouse input states included
    /// </summary>
    public enum InputStates
    {
        

        /// <summary>
        /// Cusor <c>X</c> position in cells
        /// </summary>
        TK_MOUSE_X = 0x87,
        /// <summary>
        /// Cusor <c>Y</c> position in cells
        /// </summary>
        TK_MOUSE_Y = 0x88,
        /// <summary>
        /// Cursor <c>X</c> position in pixels
        /// </summary>
        TK_MOUSE_PIXEL_X = 0x89,
        /// <summary>
        /// Cursor <c>Y</c> position in pixels
        /// </summary>
        TK_MOUSE_PIXEL_Y = 0x8A,

        /// <summary>
        /// Number of consecutive clicks
        /// </summary>
        TK_MOUSE_CLICKS = 0x8C
    }
}
