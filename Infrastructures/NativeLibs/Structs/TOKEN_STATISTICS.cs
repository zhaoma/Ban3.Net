using Ban3.Infrastructures.NativeLibs.Enums;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_STATISTICS structure contains information about an access token.
    /// An application can retrieve this information by calling the GetTokenInformation function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_statistics
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_STATISTICS
    {
        /// LUID->_LUID
        public LUID TokenId;

        /// LUID->_LUID
        public LUID AuthenticationId;

        /// LARGE_INTEGER->_LARGE_INTEGER
        public LARGE_INTEGER ExpirationTime;

        /// TOKEN_TYPE->_TOKEN_TYPE
        public TOKEN_TYPE TokenType;

        /// SECURITY_IMPERSONATION_LEVEL->_SECURITY_IMPERSONATION_LEVEL
        public SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;

        /// DWORD->unsigned int
        public uint DynamicCharged;

        /// DWORD->unsigned int
        public uint DynamicAvailable;

        /// DWORD->unsigned int
        public uint GroupCount;

        /// DWORD->unsigned int
        public uint PrivilegeCount;

        /// LUID->_LUID
        public LUID ModifiedId;
    }
}