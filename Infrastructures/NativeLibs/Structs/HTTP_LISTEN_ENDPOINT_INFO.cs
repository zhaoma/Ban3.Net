using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Controls whether IP-based URLs should listen on the specific IP address or on a wildcard.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_listen_endpoint_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_LISTEN_ENDPOINT_INFO
    {

        /// ULONG->unsigned int
        public HTTP_PROPERTY_FLAGS Flags;

        /// BOOLEAN->BYTE->unsigned char
        public byte EnableSharing;
    }
}