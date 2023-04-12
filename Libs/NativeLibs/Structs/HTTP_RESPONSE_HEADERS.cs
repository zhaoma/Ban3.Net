using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_RESPONSE_HEADERS structure contains the headers sent with an HTTP response.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_response_headers
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_RESPONSE_HEADERS
    {

        /// USHORT->unsigned short
        public ushort UnknownHeaderCount;

        /// PVOID->void*
        public System.IntPtr pUnknownHeaders;

        /// USHORT->unsigned short
        public ushort TrailerCount;

        /// PVOID->void*
        public System.IntPtr pTrailers;

        /// PVOID[]
        public HTTP_KNOWN_HEADER[] KnownHeaders;
    }
}