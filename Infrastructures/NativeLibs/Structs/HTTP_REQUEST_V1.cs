using System;
using Ban3.Infrastructures.NativeLibs.Enums;
using System.Net;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Uses the HTTP_REQUEST structure to return data associated with a specific request.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_request_v1
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_REQUEST_V1
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
    }
}