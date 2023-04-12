using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains the scalable metrics associated with minimized windows.
    /// This structure is used with the SystemParametersInfo function when the SPI_GETMINIMIZEDMETRICS or SPI_SETMINIMIZEDMETRICS action value is specified.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-minimizedmetrics
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MINIMIZEDMETRICS
    {
        /// UINT->unsigned int
        public uint cbSize;

        /// int
        public int iWidth;

        /// int
        public int iHorzGap;

        /// int
        public int iVertGap;

        /// int
        public int iArrange;
    }
}