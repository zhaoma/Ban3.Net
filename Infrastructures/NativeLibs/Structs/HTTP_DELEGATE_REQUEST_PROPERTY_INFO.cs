using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Describes additional property information when delegating a request.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_delegate_request_property_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_DELEGATE_REQUEST_PROPERTY_INFO
    {

        /// PVOID->void*
        public HTTP_DELEGATE_REQUEST_PROPERTY_ID PropertyId;

        /// ULONG->unsigned int
        public uint PropertyInfoLength;

        /// PVOID->void*
        public System.IntPtr PropertyInfo;
    }
}