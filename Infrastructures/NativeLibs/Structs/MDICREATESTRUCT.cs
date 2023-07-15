using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about the class, title, owner, location, and size of a multiple-document interface (MDI) child window.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mdicreatestructa
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MDICREATESTRUCTA
    {
        /// LPCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string szClass;

        /// LPCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string szTitle;

        /// HANDLE->void*
        public System.IntPtr hOwner;

        /// int
        public int x;

        /// int
        public int y;

        /// int
        public int cx;

        /// int
        public int cy;

        /// DWORD->unsigned int
        public uint style;

        /// LPARAM->LONG_PTR->int
        public int lParam;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct tagMDICREATESTRUCTW
    {

        /// LPCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string szClass;

        /// LPCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string szTitle;

        /// HANDLE->void*
        public System.IntPtr hOwner;

        /// int
        public int x;

        /// int
        public int y;

        /// int
        public int cx;

        /// int
        public int cy;

        /// DWORD->unsigned int
        public uint style;

        /// LPARAM->LONG_PTR->int
        public int lParam;
    }
}