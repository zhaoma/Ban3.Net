using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVICE_CONFIG_SSL_QUERY structure is used to specify a particular record to query in the SSL configuration store.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_query
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_CONFIG_SSL_QUERY
    {

        /// DWORD->unsigned int
        public HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc;

        /// DWORD->unsigned int
        public HTTP_SERVICE_CONFIG_SSL_KEY KeyDesc;

        /// DWORD->unsigned int
        public uint dwToken;
    }
}