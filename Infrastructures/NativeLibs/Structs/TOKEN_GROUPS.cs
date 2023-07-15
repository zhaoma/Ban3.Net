using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_GROUPS structure contains information about the group security identifiers (SIDs) in an access token.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_groups
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_GROUPS
    {
        /// DWORD->unsigned int
        public uint GroupCount;

        /// SID_AND_ATTRIBUTES*[]
        public System.IntPtr[] Groups;
    }
}