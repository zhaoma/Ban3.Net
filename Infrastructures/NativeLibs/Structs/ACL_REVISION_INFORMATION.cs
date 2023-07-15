using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The ACL_REVISION_INFORMATION structure contains revision information about an ACL structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-acl_revision_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ACL_REVISION_INFORMATION
    {
        public uint AclRevision;
    }
}