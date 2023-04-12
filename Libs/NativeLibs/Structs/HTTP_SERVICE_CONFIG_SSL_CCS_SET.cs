using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Represents the SSL certificate record that specifies that Http.sys should consult the Centralized Certificate Store (CCS) store to find certificates if the port receives a Transport Layer Security (TLS) handshake. Use this structure to add, delete, retrieve, or update that SSL certificate.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_ccs_set
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_CONFIG_SSL_CCS_SET
    {
        public HTTP_SERVICE_CONFIG_SSL_CCS_KEY KeyDesc;

        public HTTP_SERVICE_CONFIG_SSL_PARAM ParamDesc;
    }
}