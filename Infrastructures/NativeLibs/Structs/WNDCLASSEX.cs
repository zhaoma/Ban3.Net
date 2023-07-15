using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains window class information. It is used with the RegisterClassEx and GetClassInfoEx  functions.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-wndclassexa
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WNDCLASSEX
    {
        /// UINT->unsigned int
        public uint cbSize;

        /// UINT->unsigned int
        public uint style;

        /// WNDPROC
        public WNDPROC lpfnWndProc;

        /// int
        public int cbClsExtra;

        /// int
        public int cbWndExtra;

        /// HINSTANCE->HINSTANCE__*
        public System.IntPtr hInstance;

        /// HICON->HICON__*
        public System.IntPtr hIcon;

        /// HCURSOR->HICON->HICON__*
        public System.IntPtr hCursor;

        /// HBRUSH->HBRUSH__*
        public System.IntPtr hbrBackground;

        /// LPCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpszMenuName;

        /// LPCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpszClassName;

        /// HICON->HICON__*
        public System.IntPtr hIconSm;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct WNDCLASSEXW
    {

        /// UINT->unsigned int
        public uint cbSize;

        /// UINT->unsigned int
        public uint style;

        /// WNDPROC
        public WNDPROC lpfnWndProc;

        /// int
        public int cbClsExtra;

        /// int
        public int cbWndExtra;

        /// HINSTANCE->HINSTANCE__*
        public System.IntPtr hInstance;

        /// HICON->HICON__*
        public System.IntPtr hIcon;

        /// HCURSOR->HICON->HICON__*
        public System.IntPtr hCursor;

        /// HBRUSH->HBRUSH__*
        public System.IntPtr hbrBackground;

        /// LPCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszMenuName;

        /// LPCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszClassName;

        /// HICON->HICON__*
        public System.IntPtr hIconSm;
    }
}