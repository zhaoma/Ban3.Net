using Ban3.Infrastructures.NativeLibs.Enums;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The SYSTEM_AUDIT_CALLBACK_OBJECT_ACE structure defines an access control entry (ACE) for a system access control list (SACL).
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-system_audit_callback_object_ace
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_AUDIT_CALLBACK_OBJECT_ACE
    {

        public ACE_HEADER Header;
        public ACCESS_MASK Mask;
        public uint Flags;
        public GUID ObjectType;
        public GUID InheritedObjectType;
        public uint SidStart;
    }
}