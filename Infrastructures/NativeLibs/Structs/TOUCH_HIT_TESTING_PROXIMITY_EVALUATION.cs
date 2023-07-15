using System.Drawing;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains the hit test score that indicates whether the object is the likely target of the touch contact area, relative to other objects that intersect the touch contact area.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-touch_hit_testing_proximity_evaluation
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOUCH_HIT_TESTING_PROXIMITY_EVALUATION
    {
        /// UINT16->unsigned short
        public ushort score;

        /// POINT->tagPOINT
        public Point adjustedPoint;
    }
}