using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_PRIMARY_GROUP structure specifies a group security identifier (SID) for an access token.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_primary_group
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_PRIMARY_GROUP
    {
        public System.IntPtr PrimaryGroup;
    }
}