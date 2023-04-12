using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_UNKNOWN_HEADER structure contains the name and value for a header in an HTTP request or response whose name does not appear in the enumeration.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_unknown_header
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_UNKNOWN_HEADER
    {

        /// USHORT->unsigned short
        public ushort NameLength;

        /// USHORT->unsigned short
        public ushort RawValueLength;

        /// PCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string pName;

        /// PCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string pRawValue;
    }

}