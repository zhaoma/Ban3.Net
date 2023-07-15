using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The SCROLLINFO structure contains scroll bar parameters to be set by the SetScrollInfo function (or SBM_SETSCROLLINFO message), or retrieved by the GetScrollInfo function (or SBM_GETSCROLLINFO message).
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-scrollinfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SCROLLINFO
    {

        /// UINT->unsigned int
        public uint cbSize;

        /// UINT->unsigned int
        public uint fMask;

        /// int
        public int nMin;

        /// int
        public int nMax;

        /// UINT->unsigned int
        public uint nPage;

        /// int
        public int nPos;

        /// int
        public int nTrackPos;
    }

}