using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVICE_BINDING_BASE structure is a placeholder for the HTTP_SERVICE_BINDING_A structure and the HTTP_SERVICE_BINDING_W structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_binding_base
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_BINDING_BASE
    {
        /// <summary>
        /// Pointer to an HTTP_SERVICE_BINDING_TYPE value that indicates whether the data is in ASCII or Unicode.
        /// </summary>
        public HTTP_SERVICE_BINDING_TYPE Type;
    }
}