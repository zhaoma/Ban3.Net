using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_REQUEST_V2 structure extends the HTTP_REQUEST_V1 request structure with more information about the request.
    /// Do not use HTTP_REQUEST_V2 directly in your code; use HTTP_REQUEST instead to ensure that the proper version, based on the operating system the code is compiled under, is used.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_request_v2
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_REQUEST_V2
    {

        /// ULONG->unsigned int
        public uint Flags;

        /// ULONG->unsigned int
        public uint ConnectionId;

        /// ULONG->unsigned int
        public uint RequestId;

        /// ULONG->unsigned int
        public uint UrlContext;

        /// ULONG->unsigned int
        public HTTP_VERSION Version;

        /// ULONG->unsigned int
        public HTTP_VERB Verb;

        /// USHORT->unsigned short
        public ushort UnknownVerbLength;

        /// USHORT->unsigned short
        public ushort RawUrlLength;

        /// PCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string pUnknownVerb;

        /// PCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string pRawUrl;

        /// ULONG->unsigned int
        public HTTP_COOKED_URL CookedUrl;

        /// ULONG->unsigned int
        public HTTP_TRANSPORT_ADDRESS Address;

        /// ULONG->unsigned int
        public HTTP_REQUEST_HEADERS Headers;

        /// ULONGLONG->unsigned __int64
        public ulong BytesReceived;

        /// USHORT->unsigned short
        public ushort EntityChunkCount;

        /// ULONG->unsigned int
        public IntPtr pEntityChunks;

        /// ULONG->unsigned int
        public uint RawConnectionId;

        /// PVOID->void*
        public System.IntPtr pSslInfo;

        public uint RequestInfoCount;

        public IntPtr pRequestInfo;
    }
}