using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The SIZE structure defines the width and height of a rectangle.
    /// https://learn.microsoft.com/en-us/windows/win32/api/windef/ns-windef-size
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
        /// <summary>
        /// Specifies the rectangle's width.
        /// The units depend on which function uses this structure.
        /// </summary>
        public int cx;

        /// <summary>
        /// Specifies the rectangle's height.
        /// The units depend on which function uses this structure.
        /// </summary>
        public int cy;
    }
}