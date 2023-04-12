using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_LOG_FIELDS_DATA structure is used to pass the fields that are logged for an HTTP response when WC3 logging is enabled.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_log_fields_data
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_LOG_FIELDS_DATA
    {

        /// ULONG->unsigned int
        public HTTP_LOG_DATA Base;

        /// USHORT->unsigned short
        public ushort UserNameLength;

        /// USHORT->unsigned short
        public ushort UriStemLength;

        /// USHORT->unsigned short
        public ushort ClientIpLength;

        /// USHORT->unsigned short
        public ushort ServerNameLength;

        /// USHORT->unsigned short
        public ushort ServiceNameLength;

        /// USHORT->unsigned short
        public ushort ServerIpLength;

        /// USHORT->unsigned short
        public ushort MethodLength;

        /// USHORT->unsigned short
        public ushort UriQueryLength;

        /// USHORT->unsigned short
        public ushort HostLength;

        /// USHORT->unsigned short
        public ushort UserAgentLength;

        /// USHORT->unsigned short
        public ushort CookieLength;

        /// USHORT->unsigned short
        public ushort ReferrerLength;

        /// PWCHAR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string UserName;

        /// PWCHAR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string UriStem;

        /// PCHAR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string ClientIp;

        /// PCHAR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string ServerName;

        /// PCHAR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string ServiceName;

        /// PCHAR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string ServerIp;

        /// PCHAR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string Method;

        /// PCHAR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string UriQuery;

        /// PCHAR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string Host;

        /// PCHAR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string UserAgent;

        /// PCHAR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string Cookie;

        /// PCHAR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string Referrer;

        /// USHORT->unsigned short
        public ushort ServerPort;

        /// USHORT->unsigned short
        public ushort ProtocolStatus;

        /// ULONG->unsigned int
        public uint Win32Status;

        /// ULONG->unsigned int
        public HTTP_VERB MethodNum;

        /// USHORT->unsigned short
        public ushort SubStatus;
    }

}