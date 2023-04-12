using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVICE_CONFIG_IP_LISTEN_QUERY structure is used by HttpQueryServiceConfiguration to return a list of the Internet Protocol (IP) addresses to which the HTTP service binds.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ip_listen_query
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_CONFIG_IP_LISTEN_QUERY
    {

        /// ULONG->unsigned int
        public uint AddrCount;

        /// ULONG[1]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public SOCKADDR_STORAGE[] AddrList;
    }
}