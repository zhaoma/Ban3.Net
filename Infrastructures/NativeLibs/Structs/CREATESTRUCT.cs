using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CREATESTRUCTA
    {
        /// LPVOID->void*
        public System.IntPtr lpCreateParams;

        /// HINSTANCE->HINSTANCE__*
        public System.IntPtr hInstance;

        /// HMENU->HMENU__*
        public System.IntPtr hMenu;

        /// HWND->HWND__*
        public System.IntPtr hwndParent;

        /// int
        public int cy;

        /// int
        public int cx;

        /// int
        public int y;

        /// int
        public int x;

        /// LONG->int
        public int style;

        /// LPCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpszName;

        /// LPCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpszClass;

        /// DWORD->unsigned int
        public uint dwExStyle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CREATESTRUCTW
    {

        /// LPVOID->void*
        public System.IntPtr lpCreateParams;

        /// HINSTANCE->HINSTANCE__*
        public System.IntPtr hInstance;

        /// HMENU->HMENU__*
        public System.IntPtr hMenu;

        /// HWND->HWND__*
        public System.IntPtr hwndParent;

        /// int
        public int cy;

        /// int
        public int cx;

        /// int
        public int y;

        /// int
        public int x;

        /// LONG->int
        public int style;

        /// LPCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszName;

        /// LPCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszClass;

        /// DWORD->unsigned int
        public uint dwExStyle;
    }
}