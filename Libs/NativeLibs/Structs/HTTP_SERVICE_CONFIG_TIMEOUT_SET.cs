using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVICE_CONFIG_TIMEOUT_SET structure is used to set the HTTP Server API wide timeout value.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_timeout_set
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_CONFIG_TIMEOUT_SET
    {

        public HTTP_SERVICE_CONFIG_SSL_KEY KeyDesc;
        public HTTP_SERVICE_CONFIG_SSL_PARAM ParamDesc;
    }
}