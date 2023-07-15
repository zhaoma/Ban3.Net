using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The SCROLLBARINFO structure contains scroll bar information.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-scrollbarinfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SCROLLBARINFO
    {
        /// DWORD->unsigned int
        public uint cbSize;

        /// RECT->tagRECT
        public RECT rcScrollBar;

        /// int
        public int dxyLineButton;

        /// int
        public int xyThumbTop;

        /// int
        public int xyThumbBottom;

        /// int
        public int reserved;

        /// DWORD[6]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.U4)]
        public uint[] rgstate;
    }
}