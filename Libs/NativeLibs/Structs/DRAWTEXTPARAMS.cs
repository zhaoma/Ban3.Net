using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The DRAWTEXTPARAMS structure contains extended formatting options for the DrawTextEx function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-drawtextparams
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DRAWTEXTPARAMS
    {
        /// <summary>
        /// The structure size, in bytes.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// The size of each tab stop, in units equal to the average character width.
        /// </summary>
        public int iTabLength;

        /// <summary>
        /// The left margin, in units equal to the average character width.
        /// </summary>
        public int iLeftMargin;

        /// <summary>
        /// The right margin, in units equal to the average character width.
        /// </summary>
        public int iRightMargin;

        /// <summary>
        /// Receives the number of characters processed by DrawTextEx, including white-space characters.
        /// The number can be the length of the string or the index of the first line that falls below the drawing area.
        /// Note that DrawTextEx always processes the entire string if the DT_NOCLIP formatting flag is specified.
        /// </summary>
        public uint uiLengthDrawn;
    }
}