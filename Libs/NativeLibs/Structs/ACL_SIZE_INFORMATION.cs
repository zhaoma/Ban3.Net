using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The ACL_SIZE_INFORMATION structure contains information about the size of an ACL structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-acl_size_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ACL_SIZE_INFORMATION
    {
        public uint AceCount;
        public uint AclBytesInUse;
        public uint AclBytesFree;
    }
}