using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_TIMEOUT_LIMIT_INFO structure defines the application-specific connection timeout limits.
    /// This structure must be used when setting or querying the HttpServerTimeoutsProperty on a URL Group, server session, or request queue.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_timeout_limit_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_TIMEOUT_LIMIT_INFO
    {

        /// ULONG->unsigned int
        public HTTP_PROPERTY_FLAGS Flags;

        /// USHORT->unsigned short
        public ushort EntityBody;

        /// USHORT->unsigned short
        public ushort DrainEntityBody;

        /// USHORT->unsigned short
        public ushort RequestQueue;

        /// USHORT->unsigned short
        public ushort IdleConnection;

        /// USHORT->unsigned short
        public ushort HeaderWait;

        /// ULONG->unsigned int
        public uint MinSendRate;
    }
}