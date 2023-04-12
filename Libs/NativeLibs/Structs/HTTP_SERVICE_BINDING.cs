using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVICE_BINDING_A structure provides Service Principle Name (SPN) in ASCII.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_binding_a
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_BINDING_A
    {

        /// ULONG->unsigned int
        public HTTP_SERVICE_BINDING_BASE Base;

        /// PCHAR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string Buffer;

        /// ULONG->unsigned int
        public uint BufferSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_BINDING_W
    {

        /// ULONG->unsigned int
        public HTTP_SERVICE_BINDING_BASE Base;

        /// PWCHAR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Buffer;

        /// ULONG->unsigned int
        public uint BufferSize;
    }


}