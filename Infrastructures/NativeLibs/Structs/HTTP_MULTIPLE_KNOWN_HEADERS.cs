using System;
using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_MULTIPLE_KNOWN_HEADERS structure specifies the headers that are included in an HTTP response when more than one header is required.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_multiple_known_headers
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_MULTIPLE_KNOWN_HEADERS
    {

        /// ULONG->unsigned int
        public HTTP_HEADER_ID HeaderId;

        /// ULONG->unsigned int
        public uint Flags;

        /// USHORT->unsigned short
        public ushort KnownHeaderCount;

        /// ULONG->unsigned int
        public IntPtr KnownHeaders;
    }

}