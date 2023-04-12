using System.Drawing;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about the placement of a window on the screen.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-windowplacement
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPLACEMENT
    {
        /// UINT->unsigned int
        public uint length;

        /// UINT->unsigned int
        public uint flags;

        /// UINT->unsigned int
        public uint showCmd;

        /// POINT->tagPOINT
        public POINT ptMinPosition;

        /// POINT->tagPOINT
        public POINT ptMaxPosition;

        /// RECT->tagRECT
        public RECT rcNormalPosition;

        /// RECT->tagRECT
        public RECT rcDevice;
    }
}