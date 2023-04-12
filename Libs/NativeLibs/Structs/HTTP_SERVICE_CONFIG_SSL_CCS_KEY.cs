using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Serves as the key by which identifies the SSL certificate record that specifies that Http.sys should consult the Centralized Certificate Store (CCS) store to find certificates if the port receives a Transport Layer Security (TLS) handshake.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_ccs_key
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_CONFIG_SSL_CCS_KEY
    {
        public SOCKADDR_STORAGE LocalAddress;
    }
}