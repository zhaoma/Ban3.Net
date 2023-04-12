using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_VERSION structure defines a version of the HTTP protocol that a request requires or a response provides.
    /// This is not to be confused with the version of the HTTP Server API used, which is stored in an HTTPAPI_VERSION structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_version
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_VERSION
    {

        /// USHORT->unsigned short
        public ushort MajorVersion;

        /// USHORT->unsigned short
        public ushort MinorVersion;
    }

}