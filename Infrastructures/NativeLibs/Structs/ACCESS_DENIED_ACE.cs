using Ban3.Infrastructures.NativeLibs.Enums;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The ACCESS_DENIED_ACE structure defines an access control entry (ACE) for the discretionary access control list (DACL) that controls access to an object.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-access_denied_ace
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ACCESS_DENIED_ACE
    {
        public ACE_HEADER Header;
        public ACCESS_MASK Mask;
        public uint SidStart;
    }
}