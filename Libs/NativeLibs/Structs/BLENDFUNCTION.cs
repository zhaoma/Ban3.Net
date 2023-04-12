using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The BLENDFUNCTION structure controls blending by specifying the blending functions for source and destination bitmaps.
    /// https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-blendfunction
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BLENDFUNCTION
    {

        /// BYTE->unsigned char
        public byte BlendOp;

        /// BYTE->unsigned char
        public byte BlendFlags;

        /// BYTE->unsigned char
        public byte SourceConstantAlpha;

        /// BYTE->unsigned char
        public byte AlphaFormat;
    }
}