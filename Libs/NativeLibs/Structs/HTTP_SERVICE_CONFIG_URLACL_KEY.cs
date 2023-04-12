using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVICE_CONFIG_URLACL_KEY structure is used to specify a particular reservation record in the URL namespace reservation store.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_urlacl_key
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_CONFIG_URLACL_KEY
    {

        /// PWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pUrlPrefix;
    }
}