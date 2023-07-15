using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_REQUEST_CHANNEL_BIND_STATUS structure contains secure channel endpoint binding information.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_request_channel_bind_status
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_REQUEST_CHANNEL_BIND_STATUS
    {

        /// PVOID->void*
        public System.IntPtr ServiceName;

        /// PUCHAR->UCHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string ChannelToken;

        /// ULONG->unsigned int
        public uint ChannelTokenSize;

        /// ULONG->unsigned int
        public uint Flags;
    }

}