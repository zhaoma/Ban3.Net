using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTPAPI_VERSION structure defines the version of the HTTP Server API.
    /// This is not to be confused with the version of the HTTP protocol used, which is stored in an HTTP_VERSION structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-httpapi_version
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTPAPI_VERSION
    {

        /// USHORT->unsigned short
        public ushort HttpApiMajorVersion;

        /// USHORT->unsigned short
        public ushort HttpApiMinorVersion;
    }
}