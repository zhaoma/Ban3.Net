using Ban3.Infrastructures.NativeLibs.Enums;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_ACCESS_INFORMATION structure specifies all the information in a token that is necessary to perform an access check.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_access_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_ACCESS_INFORMATION
    {
        /// PVOID->void*
        public System.IntPtr SidHash;

        /// PVOID->void*
        public System.IntPtr RestrictedSidHash;

        /// PVOID->void*
        public System.IntPtr Privileges;

        /// LUID->_LUID
        public LUID AuthenticationId;

        /// TOKEN_TYPE->_TOKEN_TYPE
        public TOKEN_TYPE TokenType;

        /// SECURITY_IMPERSONATION_LEVEL->_SECURITY_IMPERSONATION_LEVEL
        public SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;

        /// PVOID->void*
        public TOKEN_MANDATORY_POLICY MandatoryPolicy;

        /// DWORD->unsigned int
        public uint Flags;

        /// DWORD->unsigned int
        public uint AppContainerNumber;

        /// PSID->PVOID->void*
        public System.IntPtr PackageSid;

        /// PVOID->void*
        public System.IntPtr CapabilitiesHash;

        /// PSID->PVOID->void*
        public System.IntPtr TrustLevelSid;

        /// PVOID->void*
        public System.IntPtr SecurityAttributes;
    }
}