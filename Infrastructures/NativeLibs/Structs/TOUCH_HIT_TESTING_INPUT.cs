using System.Drawing;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about the touch contact area reported by the touch digitizer.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-touch_hit_testing_input
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOUCH_HIT_TESTING_INPUT
    {

        /// UINT32->unsigned int
        public uint pointerId;

        /// POINT->tagPOINT
        public Point point;

        /// RECT->tagRECT
        public RECT boundingBox;

        /// RECT->tagRECT
        public RECT nonOccludedBoundingBox;

        /// UINT32->unsigned int
        public uint orientation;
    }
}