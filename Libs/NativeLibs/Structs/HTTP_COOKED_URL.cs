using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_COOKED_URL structure contains a validated, canonical, UTF-16 Unicode-encoded URL request string together with pointers into it and element lengths.
    /// This is the string that the HTTP Server API matches against registered UrlPrefix strings in order to route the request appropriately.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_cooked_url
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_COOKED_URL
    {

        /// USHORT->unsigned short
        public ushort FullUrlLength;

        /// USHORT->unsigned short
        public ushort HostLength;

        /// USHORT->unsigned short
        public ushort AbsPathLength;

        /// USHORT->unsigned short
        public ushort QueryStringLength;

        /// PCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pFullUrl;

        /// PCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pHost;

        /// PCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pAbsPath;

        /// PCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pQueryString;
    }

}