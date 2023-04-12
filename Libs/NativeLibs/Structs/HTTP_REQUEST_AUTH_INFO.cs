using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_REQUEST_AUTH_INFO structure contains the authentication status of the request with a handle to the client token that the receiving process can use to impersonate the authenticated client.
    /// This structure is contained in the HTTP_REQUEST_INFO structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_request_auth_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_REQUEST_AUTH_INFO
    {

        /// ULONG->unsigned int
        public HTTP_AUTH_STATUS AuthStatus;

        /// ULONG->unsigned int
        public uint SecStatus;

        /// ULONG->unsigned int
        public uint Flags;

        /// ULONG->unsigned int
        public HTTP_REQUEST_AUTH_TYPE AuthType;

        /// HANDLE->void*
        public System.IntPtr AccessToken;

        /// ULONG->unsigned int
        public uint ContextAttributes;

        /// ULONG->unsigned int
        public uint PackedContextLength;

        /// ULONG->unsigned int
        public uint PackedContextType;

        /// PVOID->void*
        public System.IntPtr PackedContext;

        /// ULONG->unsigned int
        public uint MutualAuthDataLength;

        /// PCHAR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string pMutualAuthData;

        /// USHORT->unsigned short
        public ushort PackageNameLength;

        /// PWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pPackageName;
    }

}