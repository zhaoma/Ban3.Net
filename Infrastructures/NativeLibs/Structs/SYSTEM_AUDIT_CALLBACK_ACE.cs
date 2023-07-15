using Ban3.Infrastructures.NativeLibs.Enums;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The SYSTEM_AUDIT_CALLBACK_ACE structure defines an access control entry (ACE) for the system access control list (SACL) that specifies what types of access cause system-level notifications.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-system_audit_callback_ace
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_AUDIT_CALLBACK_ACE
    {
        public ACE_HEADER Header;
        public ACCESS_MASK Mask;
        public uint SidStart;

    }
}