using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CLAIM_SECURITY_ATTRIBUTE_V1 structure defines a security attribute that can be associated with a token or authorization context.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-claim_security_attribute_v1
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLAIM_SECURITY_ATTRIBUTE_V1
    {

        /// PWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Name;

        /// WORD->unsigned short
        public ushort ValueType;

        /// WORD->unsigned short
        public ushort Reserved;

        /// DWORD->unsigned int
        public uint Flags;

        /// DWORD->unsigned int
        public uint ValueCount;

        /// Anonymous_be8f13ad_f3b9_4c82_8bb6_cfadd5a93ec2
        public Anonymous_be8f13ad_f3b9_4c82_8bb6_cfadd5a93ec2 Values;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct Anonymous_be8f13ad_f3b9_4c82_8bb6_cfadd5a93ec2
    {

        /// PLONG64->__int64*
        [FieldOffset(0)]
        public System.IntPtr pInt64;

        /// PDWORD64->unsigned __int64*
        [FieldOffset(0)]
        public System.IntPtr pUint64;

        /// PWSTR*
        [FieldOffset(0)]
        public System.IntPtr ppString;

        /// PVOID->void*
        [FieldOffset(0)]
        public System.IntPtr pFqbn;

        /// PVOID->void*
        [FieldOffset(0)]
        public System.IntPtr pOctetString;
    }
}