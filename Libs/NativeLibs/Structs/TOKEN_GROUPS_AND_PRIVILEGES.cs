using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_GROUPS_AND_PRIVILEGES structure contains information about the group security identifiers (SIDs) and privileges in an access token.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_groups_and_privileges
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_GROUPS_AND_PRIVILEGES
    {
        /// DWORD->unsigned int
        public uint SidCount;

        /// DWORD->unsigned int
        public uint SidLength;

        /// PSID_AND_ATTRIBUTES->_SID_AND_ATTRIBUTES*
        public System.IntPtr Sids;

        /// DWORD->unsigned int
        public uint RestrictedSidCount;

        /// DWORD->unsigned int
        public uint RestrictedSidLength;

        /// PSID_AND_ATTRIBUTES->_SID_AND_ATTRIBUTES*
        public System.IntPtr RestrictedSids;

        /// DWORD->unsigned int
        public uint PrivilegeCount;

        /// DWORD->unsigned int
        public uint PrivilegeLength;

        /// PLUID_AND_ATTRIBUTES->_LUID_AND_ATTRIBUTES*
        public System.IntPtr Privileges;

        /// LUID->_LUID
        public LUID AuthenticationId;
    }
}