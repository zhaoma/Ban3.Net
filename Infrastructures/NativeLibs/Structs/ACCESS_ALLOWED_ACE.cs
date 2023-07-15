using Ban3.Infrastructures.NativeLibs.Enums;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The ACCESS_ALLOWED_ACE structure defines an access control entry (ACE) for the discretionary access control list (DACL) that controls access to an object.
    /// An access-allowed ACE allows access to an object for a specific trustee identified by a security identifier (SID).
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-access_allowed_ace
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ACCESS_ALLOWED_ACE
    {
        public ACE_HEADER Header;
        public ACCESS_MASK Mask;
        public uint SidStart;
    }
}