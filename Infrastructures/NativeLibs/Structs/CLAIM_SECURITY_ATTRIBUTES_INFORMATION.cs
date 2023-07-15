using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CLAIM_SECURITY_ATTRIBUTES_INFORMATION structure defines the security attributes for the claim.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-claim_security_attributes_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLAIM_SECURITY_ATTRIBUTES_INFORMATION
    {    
        /// WORD->unsigned short
        public ushort Version;

        /// WORD->unsigned short
        public ushort Reserved;

        /// DWORD->unsigned int
        public uint AttributeCount;

        /// Anonymous_4562a7d2_6c13_4e3d_922c_d827dda58318
        public CLAIM_SECURITY_ATTRIBUTES_INFORMATION_ATTRIBUTE Attribute;

    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct CLAIM_SECURITY_ATTRIBUTES_INFORMATION_ATTRIBUTE
    {

        /// PVOID->void*
        [FieldOffset(0)]
        public System.IntPtr pAttributeV1;
    }
}