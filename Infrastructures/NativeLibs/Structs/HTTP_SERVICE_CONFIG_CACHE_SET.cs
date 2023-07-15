using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Used in the pConfigInformation parameter of the HttpSetServiceConfiguration function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_cache_set
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_CONFIG_CACHE_SET
    {

        /// ULONG->unsigned int
        public HTTP_SERVICE_CONFIG_CACHE_KEY KeyDesc;

        /// HTTP_SERVICE_CONFIG_CACHE_PARAM
        public uint ParamDesc;
    }
}