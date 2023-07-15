
using System.Runtime.InteropServices;
using System;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The SECURITY_DESCRIPTOR structure contains the security information associated with an object. 
    /// Applications use this structure to set and query an object's security status.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-security_descriptor?redirectedfrom=MSDN
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_DESCRIPTOR
    {
        /*
            winnt.h
            typedef struct _SECURITY_DESCRIPTOR {
              BYTE                        Revision;
              BYTE                        Sbz1;
              SECURITY_DESCRIPTOR_CONTROL Control;
              PSID                        Owner;
              PSID                        Group;
              PACL                        Sacl;
              PACL                        Dacl;
            } SECURITY_DESCRIPTOR, *PISECURITY_DESCRIPTOR;
         */

        /// BYTE->unsigned char
        public byte Revision;

        /// BYTE->unsigned char
        public byte Sbz1;

        /// SECURITY_DESCRIPTOR_CONTROL->WORD->unsigned short
        public ushort Control;

        /// PSID->PVOID->void*
        public IntPtr Owner;

        /// PSID->PVOID->void*
        public IntPtr Group;

        /// PACL->ACL*
        public IntPtr Sacl;

        /// PACL->ACL*
        public IntPtr Dacl;
    }
}
