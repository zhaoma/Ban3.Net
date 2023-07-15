using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{

    [StructLayout(LayoutKind.Sequential)]
    public struct WNDCLASSA
    {

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
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct WNDCLASSW
    {

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
    }

    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
    public delegate int WNDPROC(System.IntPtr param0, uint param1, System.IntPtr param2, System.IntPtr param3);
}