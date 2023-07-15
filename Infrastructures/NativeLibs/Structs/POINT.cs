using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The POINT structure defines the x- and y-coordinates of a point.
    /// https://learn.microsoft.com/en-us/windows/win32/api/windef/ns-windef-point
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        /// <summary>
        /// Specifies the x-coordinate of the point.
        /// </summary>
        public int x;

        /// <summary>
        /// Specifies the y-coordinate of the point.
        /// </summary>
        public int y;
    }
}