using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains title bar information.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-titlebarinfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TITLEBARINFO
    {
        /// DWORD->unsigned int
        public uint cbSize;

        /// RECT->tagRECT
        public RECT rcTitleBar;

        /// DWORD[6]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.U4)]
        public uint[] rgstate;
    }
}