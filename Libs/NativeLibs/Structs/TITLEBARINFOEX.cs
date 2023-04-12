using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Expands on the information described in the TITLEBARINFO structure by including the coordinates of each element of the title bar.
    /// This structure is sent with the WM_GETTITLEBARINFOEX message.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-titlebarinfoex
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TITLEBARINFOEX
    {
        /// DWORD->unsigned int
        public uint cbSize;

        /// RECT->tagRECT
        public RECT rcTitleBar;

        /// DWORD[6]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.U4)]
        public uint[] rgstate;

        /// RECT[6]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public RECT[] rgrect;
    }
}