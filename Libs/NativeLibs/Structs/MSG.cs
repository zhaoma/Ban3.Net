using System.Drawing;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains message information from a thread's message queue.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-msg
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        /// HWND->HWND__*
        public System.IntPtr hwnd;

        /// UINT->unsigned int
        public uint message;

        /// WPARAM->UINT_PTR->unsigned int
        public uint wParam;

        /// LPARAM->LONG_PTR->int
        public int lParam;

        /// DWORD->unsigned int
        public uint time;

        /// POINT->tagPOINT
        public Point pt;

        /// DWORD->unsigned int
        public uint lPrivate;
    }
}