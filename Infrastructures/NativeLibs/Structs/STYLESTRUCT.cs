using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains the styles for a window.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-stylestruct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct STYLESTRUCT
    {
        /// DWORD->unsigned int
        public uint styleOld;

        /// DWORD->unsigned int
        public uint styleNew;
    }
}