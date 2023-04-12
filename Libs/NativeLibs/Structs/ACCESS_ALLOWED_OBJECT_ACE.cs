using Ban3.Infrastructures.NativeLibs.Enums;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The ACCESS_ALLOWED_OBJECT_ACE structure defines an access control entry (ACE) that controls allowed access to an object, a property set, or property.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-access_allowed_object_ace
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ACCESS_ALLOWED_OBJECT_ACE
    {
        public ACE_HEADER Header;
        public ACCESS_MASK Mask;
        public uint Flags;
        public GUID ObjectType;
        public GUID InheritedObjectType;
        public uint SidStart;
    }
}