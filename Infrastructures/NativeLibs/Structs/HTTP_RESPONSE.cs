using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_RESPONSE_V1 structure contains data associated with an HTTP response.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_response_v1
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_RESPONSE_V1
    {

        /// ULONG->unsigned int
        public uint Flags;

        /// ULONG->unsigned int
        public HTTP_VERSION Version;

        /// USHORT->unsigned short
        public ushort StatusCode;

        /// USHORT->unsigned short
        public ushort ReasonLength;

        /// PCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string pReason;

        /// ULONG->unsigned int
        public HTTP_RESPONSE_HEADERS Headers;

        /// USHORT->unsigned short
        public ushort EntityChunkCount;

        /// PVOID->void*
        public System.IntPtr pEntityChunks;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_RESPONSE_V2
    {
        /// ULONG->unsigned int
        public uint Flags;

        /// ULONG->unsigned int
        public HTTP_VERSION Version;

        /// USHORT->unsigned short
        public ushort StatusCode;

        /// USHORT->unsigned short
        public ushort ReasonLength;

        /// PCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string pReason;

        /// ULONG->unsigned int
        public HTTP_RESPONSE_HEADERS Headers;

        /// USHORT->unsigned short
        public ushort EntityChunkCount;

        /// PVOID->void*
        public System.IntPtr pEntityChunks;

        /// USHORT->unsigned short
        public ushort ResponseInfoCount;

        /// PVOID->void*
        public System.IntPtr pResponseInfo;
    }

}