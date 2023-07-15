using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVICE_CONFIG_SSL_PARAM structure defines a record in the SSL configuration store.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_param
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_CONFIG_SSL_PARAM
    {

        /// ULONG->unsigned int
        public uint SslHashLength;

        /// PVOID->void*
        public System.IntPtr pSslHash;

        /// GUID->_GUID
        public GUID AppId;

        /// PWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pSslCertStoreName;

        /// DWORD->unsigned int
        public uint DefaultCertCheckMode;

        /// DWORD->unsigned int
        public uint DefaultRevocationFreshnessTime;

        /// DWORD->unsigned int
        public uint DefaultRevocationUrlRetrievalTimeout;

        /// PWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pDefaultSslCtlIdentifier;

        /// PWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pDefaultSslCtlStoreName;

        /// DWORD->unsigned int
        public uint DefaultFlags;
    }
}