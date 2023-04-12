using System.Drawing;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about a mouse event passed to a WH_MOUSE hook procedure, MouseProc.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mousehookstruct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEHOOKSTRUCT
    {

        /// POINT->tagPOINT
        public Point pt;

        /// HWND->HWND__*
        public System.IntPtr hwnd;

        /// UINT->unsigned int
        public uint wHitTestCode;

        /// ULONG_PTR->unsigned int
        public uint dwExtraInfo;
    }
}