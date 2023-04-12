using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_KNOWN_HEADER structure contains the header values for a known header from an HTTP request or HTTP response.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_known_header
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_KNOWN_HEADER
    {

        /// USHORT->unsigned short
        public ushort RawValueLength;

        /// PCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string pRawValue;
    }
}