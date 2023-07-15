using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Specifies the window station, desktop, standard handles, and appearance of the main window for a process at creation time.
    /// https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-startupinfoa
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct STARTUPINFOA
    {
        /// DWORD->unsigned int
        public uint cb;

        /// LPSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpReserved;

        /// LPSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpDesktop;

        /// LPSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpTitle;

        /// DWORD->unsigned int
        public uint dwX;

        /// DWORD->unsigned int
        public uint dwY;

        /// DWORD->unsigned int
        public uint dwXSize;

        /// DWORD->unsigned int
        public uint dwYSize;

        /// DWORD->unsigned int
        public uint dwXCountChars;

        /// DWORD->unsigned int
        public uint dwYCountChars;

        /// DWORD->unsigned int
        public uint dwFillAttribute;

        /// DWORD->unsigned int
        public uint dwFlags;

        /// WORD->unsigned short
        public ushort wShowWindow;

        /// WORD->unsigned short
        public ushort cbReserved2;

        /// LPBYTE->BYTE*
        public System.IntPtr lpReserved2;

        /// HANDLE->void*
        public System.IntPtr hStdInput;

        /// HANDLE->void*
        public System.IntPtr hStdOutput;

        /// HANDLE->void*
        public System.IntPtr hStdError;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct STARTUPINFOW
    {

        /// DWORD->unsigned int
        public uint cb;

        /// LPWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpReserved;

        /// LPWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpDesktop;

        /// LPWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpTitle;

        /// DWORD->unsigned int
        public uint dwX;

        /// DWORD->unsigned int
        public uint dwY;

        /// DWORD->unsigned int
        public uint dwXSize;

        /// DWORD->unsigned int
        public uint dwYSize;

        /// DWORD->unsigned int
        public uint dwXCountChars;

        /// DWORD->unsigned int
        public uint dwYCountChars;

        /// DWORD->unsigned int
        public uint dwFillAttribute;

        /// DWORD->unsigned int
        public uint dwFlags;

        /// WORD->unsigned short
        public ushort wShowWindow;

        /// WORD->unsigned short
        public ushort cbReserved2;

        /// LPBYTE->BYTE*
        public System.IntPtr lpReserved2;

        /// HANDLE->void*
        public System.IntPtr hStdInput;

        /// HANDLE->void*
        public System.IntPtr hStdOutput;

        /// HANDLE->void*
        public System.IntPtr hStdError;
    }
}