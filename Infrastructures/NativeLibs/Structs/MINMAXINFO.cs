using System.Drawing;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about a window's maximized size and position and its minimum and maximum tracking size.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-minmaxinfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MINMAXINFO
    {

        /// POINT->tagPOINT
        public Point ptReserved;

        /// POINT->tagPOINT
        public Point ptMaxSize;

        /// POINT->tagPOINT
        public Point ptMaxPosition;

        /// POINT->tagPOINT
        public Point ptMinTrackSize;

        /// POINT->tagPOINT
        public Point ptMaxTrackSize;
    }
}