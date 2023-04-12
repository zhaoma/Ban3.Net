using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about a GUI thread.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-guithreadinfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GUITHREADINFO
    {

        /// DWORD->unsigned int
        public uint cbSize;

        /// DWORD->unsigned int
        public uint flags;

        /// HWND->HWND__*
        public System.IntPtr hwndActive;

        /// HWND->HWND__*
        public System.IntPtr hwndFocus;

        /// HWND->HWND__*
        public System.IntPtr hwndCapture;

        /// HWND->HWND__*
        public System.IntPtr hwndMenuOwner;

        /// HWND->HWND__*
        public System.IntPtr hwndMoveSize;

        /// HWND->HWND__*
        public System.IntPtr hwndCaret;

        /// RECT->tagRECT
        public RECT rcCaret;
    }
}