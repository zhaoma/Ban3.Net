using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about a notification message.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-nmhdr
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NMHDR
    {

        /// HWND->HWND__*
        public System.IntPtr hwndFrom;

        /// UINT_PTR->unsigned int
        public uint idFrom;

        /// UINT->unsigned int
        public uint code;
    }
}