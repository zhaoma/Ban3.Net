using Ban3.Infrastructures.NativeLibs.Enums;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The SYSTEM_MANDATORY_LABEL_ACE structure defines an access control entry (ACE) for the system access control list (SACL) that specifies the mandatory access level and policy for a securable object.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-system_mandatory_label_ace
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_MANDATORY_LABEL_ACE
    {

        public ACE_HEADER Header;
        public ACCESS_MASK Mask;
        public uint SidStart;
    }
}