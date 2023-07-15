using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_RESPONSE_INFO structure extends the HTTP_RESPONSE structure with additional information for the response.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_response_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_RESPONSE_INFO
    {

        /// ULONG->unsigned int
        public HTTP_RESPONSE_INFO_TYPE Type;

        /// ULONG->unsigned int
        public uint Length;

        /// PVOID->void*
        public System.IntPtr pInfo;
    }

}