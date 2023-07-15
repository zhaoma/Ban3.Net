using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_BYTE_RANGE structure is used to specify a byte range within a cached response fragment, file, or other data block.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_byte_range
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_BYTE_RANGE
    {
        /// ULARGE_INTEGER->_ULARGE_INTEGER
        public LARGE_INTEGER StartingOffset;

        /// ULARGE_INTEGER->_ULARGE_INTEGER
        public LARGE_INTEGER Length;
    }
}