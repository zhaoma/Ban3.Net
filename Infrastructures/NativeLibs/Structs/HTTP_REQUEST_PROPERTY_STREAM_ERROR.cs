using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_REQUEST_PROPERTY_STREAM_ERROR structure represents an HTTP/2 or HTTP/3 stream error code.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_request_property_stream_error
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_REQUEST_PROPERTY_STREAM_ERROR
    {

        /// ULONG->unsigned int
        public uint ErrorCode;
    }
}