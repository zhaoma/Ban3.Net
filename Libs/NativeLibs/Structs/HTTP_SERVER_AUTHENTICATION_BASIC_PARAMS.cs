using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVER_AUTHENTICATION_BASIC_PARAMS structure contains the information for Basic authentication on a URL Group.
    /// This structure is contained in the HTTP_SERVER_AUTHENTICATION_INFO structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_server_authentication_basic_params
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVER_AUTHENTICATION_BASIC_PARAMS
    {

        /// USHORT->unsigned short
        public ushort RealmLength;

        /// PWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Realm;
    }
}