using Ban3.Infrastructures.NativeLibs.Enums;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EXPLICIT_ACCESS structure defines access control information for a specified trustee.
    /// Access control functions, such as SetEntriesInAcl and GetExplicitEntriesFromAcl,
    /// use this structure to describe the information in an access control entry(ACE) of an access control list (ACL).
    /// https://learn.microsoft.com/en-us/windows/win32/api/accctrl/ns-accctrl-explicit_access_a
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EXPLICIT_ACCESS_A
    {
        /// DWORD->unsigned int
        public uint grfAccessPermissions;

        /// DWORD->unsigned int
        public ACCESS_MODE grfAccessMode;

        /// DWORD->unsigned int
        public uint grfInheritance;

        /// DWORD->unsigned int
        public uint Trustee;

    }
    
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EXPLICIT_ACCESS_W
    {
        /// DWORD->unsigned int
        public uint grfAccessPermissions;

        /// DWORD->unsigned int
        public ACCESS_MODE grfAccessMode;

        /// DWORD->unsigned int
        public uint grfInheritance;

        /// DWORD->unsigned int
        public uint Trustee;

    }
}