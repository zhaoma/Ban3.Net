using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains window information.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-windowinfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWINFO
    {
        /// DWORD->unsigned int
        public uint cbSize;

        /// RECT->tagRECT
        public RECT rcWindow;

        /// RECT->tagRECT
        public RECT rcClient;

        /// DWORD->unsigned int
        public uint dwStyle;

        /// DWORD->unsigned int
        public uint dwExStyle;

        /// DWORD->unsigned int
        public uint dwWindowStatus;

        /// UINT->unsigned int
        public uint cxWindowBorders;

        /// UINT->unsigned int
        public uint cyWindowBorders;

        /// ATOM->WORD->unsigned short
        public ushort atomWindowType;

        /// WORD->unsigned short
        public ushort wCreatorVersion;
    }
}