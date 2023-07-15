using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_REQUEST_HEADERS structure contains headers sent with an HTTP request.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_request_headers
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_REQUEST_HEADERS
    {

        /// USHORT->unsigned short
        public ushort UnknownHeaderCount;

        /// PVOID->void*
        public System.IntPtr pUnknownHeaders;

        /// USHORT->unsigned short
        public ushort TrailerCount;

        /// PVOID->void*
        public System.IntPtr pTrailers;

        /// ULONG[]
        public HTTP_KNOWN_HEADER[] KnownHeaders;
    }

}