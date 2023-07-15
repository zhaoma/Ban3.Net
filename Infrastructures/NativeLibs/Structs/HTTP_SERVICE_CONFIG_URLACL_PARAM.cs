using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVICE_CONFIG_URLACL_PARAM structure is used to specify the permissions associated with a particular record in the URL namespace reservation store.
    /// It is a member of the HTTP_SERVICE_CONFIG_URLACL_SET structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_urlacl_param
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_CONFIG_URLACL_PARAM
    {

        /// PWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pStringSecurityDescriptor;
    }

}