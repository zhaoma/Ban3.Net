using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The MONITORINFO structure contains information about a display monitor.
    /// The GetMonitorInfo function stores information in a MONITORINFO structure or a MONITORINFOEX structure.
    /// The MONITORINFO structure is a subset of the MONITORINFOEX structure.
    /// The MONITORINFOEX structure adds a string member to contain a name for the display monitor.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-monitorinfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MONITORINFO
    {
        /// DWORD->unsigned int
        public uint cbSize;

        /// RECT->tagRECT
        public RECT rcMonitor;

        /// RECT->tagRECT
        public RECT rcWork;

        /// DWORD->unsigned int
        public uint dwFlags;
    }
}