using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Specifies a Secure Sockets Layer (SSL) configuration to query for an SSL Centralized Certificate Store (CCS) record on the port when you call the HttpQueryServiceConfiguration function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_ccs_query
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_CONFIG_SSL_CCS_QUERY
    {

        /// ULONG->unsigned int
        public HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc;

        /// ULONG->unsigned int
        public HTTP_SERVICE_CONFIG_SSL_CCS_KEY KeyDesc;

        /// DWORD->unsigned int
        public uint dwToken;
    }

}