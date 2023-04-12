using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about the file that is found by the FindFirstFile, FindFirstFileEx, or FindNextFile function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/minwinbase/ns-minwinbase-win32_find_dataw
    /// </summary>
    public struct WIN32_FIND_DATAW
    {

        /// DWORD->unsigned int
        public uint dwFileAttributes;

        /// FILETIME->_FILETIME
        public FILETIME ftCreationTime;

        /// FILETIME->_FILETIME
        public FILETIME ftLastAccessTime;

        /// FILETIME->_FILETIME
        public FILETIME ftLastWriteTime;

        /// DWORD->unsigned int
        public uint nFileSizeHigh;

        /// DWORD->unsigned int
        public uint nFileSizeLow;

        /// DWORD->unsigned int
        public uint dwReserved0;

        /// DWORD->unsigned int
        public uint dwReserved1;

        /// WCHAR[260]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string cFileName;

        /// WCHAR[14]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string cAlternateFileName;

        /// DWORD->unsigned int
        public uint dwFileType;

        /// DWORD->unsigned int
        public uint dwCreatorType;

        /// WORD->unsigned short
        public ushort wFinderFlags;
    }

    public struct WIN32_FIND_DATAA
    {

        /// DWORD->unsigned int
        public uint dwFileAttributes;

        /// FILETIME->_FILETIME
        public FILETIME ftCreationTime;

        /// FILETIME->_FILETIME
        public FILETIME ftLastAccessTime;

        /// FILETIME->_FILETIME
        public FILETIME ftLastWriteTime;

        /// DWORD->unsigned int
        public uint nFileSizeHigh;

        /// DWORD->unsigned int
        public uint nFileSizeLow;

        /// DWORD->unsigned int
        public uint dwReserved0;

        /// DWORD->unsigned int
        public uint dwReserved1;

        /// WCHAR[260]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string cFileName;

        /// WCHAR[14]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string cAlternateFileName;

        /// DWORD->unsigned int
        public uint dwFileType;

        /// DWORD->unsigned int
        public uint dwCreatorType;

        /// WORD->unsigned short
        public ushort wFinderFlags;
    }
}