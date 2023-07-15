using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVICE_CONFIG_SSL_SNI_QUERY structure is used to specify a particular Secure Sockets Layer (SSL) Server Name Indication (SNI) certificate record to query in the SSL SNI store. It is passed to the HttpQueryServiceConfiguration function using the pInputConfigInfo parameter when the ConfigId parameter is set to HttpServiceConfigSslSniCertInfo.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_sni_query
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_CONFIG_SSL_SNI_QUERY
    {

        /// DWORD->unsigned int
        public HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc;

        /// DWORD->unsigned int
        public HTTP_SERVICE_CONFIG_SSL_SNI_KEY KeyDesc;

        /// DWORD->unsigned int
        public uint dwToken;
    }
}