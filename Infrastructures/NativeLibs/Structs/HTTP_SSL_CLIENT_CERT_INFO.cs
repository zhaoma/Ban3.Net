using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SSL_CLIENT_CERT_INFO structure contains data about a Secure Sockets Layer (SSL) client certificate that can be used to determine whether the certificate is valid.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_ssl_client_cert_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SSL_CLIENT_CERT_INFO
    {

        /// ULONG->unsigned int
        public uint CertFlags;

        /// ULONG->unsigned int
        public uint CertEncodedSize;

        /// PUCHAR->UCHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string pCertEncoded;

        /// HANDLE->void*
        public System.IntPtr Token;

        /// BOOLEAN->BYTE->unsigned char
        public byte CertDeniedByMapper;
    }

}