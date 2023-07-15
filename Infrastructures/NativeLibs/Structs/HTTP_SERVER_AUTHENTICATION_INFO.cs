using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVER_AUTHENTICATION_INFO structure is used to enable server-side authentication on a URL group or server session.
    /// This structure is also used to query the existing authentication schemes enabled for a URL group or server session.
    /// This structure must be used when setting or querying the HttpServerAuthenticationProperty on a URL group, or server session.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_server_authentication_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVER_AUTHENTICATION_INFO
    {

        /// ULONG->unsigned int
        public HTTP_PROPERTY_FLAGS Flags;

        /// ULONG->unsigned int
        public uint AuthSchemes;

        /// BOOLEAN->BYTE->unsigned char
        public byte ReceiveMutualAuth;

        /// BOOLEAN->BYTE->unsigned char
        public byte ReceiveContextHandle;

        /// BOOLEAN->BYTE->unsigned char
        public byte DisableNTLMCredentialCaching;

        /// UCHAR->unsigned char
        public byte ExFlags;

        /// ULONG->unsigned int
        public HTTP_SERVER_AUTHENTICATION_DIGEST_PARAMS DigestParams;

        /// ULONG->unsigned int
        public HTTP_SERVER_AUTHENTICATION_BASIC_PARAMS BasicParams;
    }
}