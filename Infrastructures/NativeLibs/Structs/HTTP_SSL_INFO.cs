using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SSL_INFO structure contains data for a connection that uses Secure Sockets Layer (SSL), obtained through the SSL handshake.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_ssl_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SSL_INFO
    {

        /// USHORT->unsigned short
        public ushort ServerCertKeySize;

        /// USHORT->unsigned short
        public ushort ConnectionKeySize;

        /// ULONG->unsigned int
        public uint ServerCertIssuerSize;

        /// ULONG->unsigned int
        public uint ServerCertSubjectSize;

        /// PCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string pServerCertIssuer;

        /// PCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string pServerCertSubject;

        /// PVOID->void*
        public System.IntPtr pClientCertInfo;

        /// ULONG->unsigned int
        public uint SslClientCertNegotiated;
    }
}