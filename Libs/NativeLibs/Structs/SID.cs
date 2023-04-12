using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The security identifier (SID) structure is a variable-length structure used to uniquely identify users or groups.
    /// Applications should not modify a SID directly. To create and manipulate a security identifier, use the functions listed in the See Also section.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-sid
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SID
    {
        /// BYTE->unsigned char
        public byte Revision;

        /// BYTE->unsigned char
        public byte SubAuthorityCount;

        /// SID_IDENTIFIER_AUTHORITY->_SID_IDENTIFIER_AUTHORITY
        public SID_IDENTIFIER_AUTHORITY IdentifierAuthority;

        /// DWORD*[]
        public System.IntPtr[] SubAuthority;
    }
}