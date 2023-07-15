using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_REQUEST_INFO structure extends the HTTP_REQUEST structure with additional information about the request.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_request_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_REQUEST_INFO
    {
        /// <summary>
        /// A member of the HTTP_REQUEST_INFO_TYPE enumeration specifying the type of information contained in this structure.
        /// </summary>
        public HTTP_REQUEST_INFO_TYPE InfoType;

        /// <summary>
        /// The length, in bytes, of the pInfo member.
        /// </summary>
        public uint InfoLength;

        /// <summary>
        /// A pointer to the HTTP_REQUEST_AUTH_INFO structure when the InfoType member is HttpRequestInfoTypeAuth; otherwise NULL.
        /// </summary>
        public System.IntPtr pInfo;
    }

}