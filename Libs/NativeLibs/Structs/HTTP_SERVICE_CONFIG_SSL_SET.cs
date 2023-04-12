using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVICE_CONFIG_SSL_SET structure is used to add a new record to the SSL store or retrieve an existing record from it.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_set
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_CONFIG_SSL_SET
    {
        public HTTP_SERVICE_CONFIG_SSL_KEY KeyDesc;
        public HTTP_SERVICE_CONFIG_SSL_PARAM ParamDesc;
    }
}