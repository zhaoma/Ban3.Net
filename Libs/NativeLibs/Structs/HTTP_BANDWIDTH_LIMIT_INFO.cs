using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_BANDWIDTH_LIMIT_INFO structure is used to set or query the bandwidth throttling limit.
    /// This structure must be used when setting or querying the HttpServerBandwidthProperty on a URL Group or server session.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_bandwidth_limit_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_BANDWIDTH_LIMIT_INFO
    {

        /// ULONG->unsigned int
        public HTTP_PROPERTY_FLAGS Flags;

        /// ULONG->unsigned int
        public uint MaxBandwidth;
    }

}