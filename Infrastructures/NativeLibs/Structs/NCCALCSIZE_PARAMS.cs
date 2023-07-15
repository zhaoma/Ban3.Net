using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information that an application can use while processing the WM_NCCALCSIZE message to calculate the size, position, and valid contents of the client area of a window.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-nccalcsize_params
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NCCALCSIZE_PARAMS
    {
        /// RECT[3]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public RECT[] rgrc;

        /// PWINDOWPOS->tagWINDOWPOS*
        public System.IntPtr lppos;
    }
}