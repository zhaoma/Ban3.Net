using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CLAIM_SECURITY_ATTRIBUTE_RELATIVE_V1 structure defines a resource attribute that is defined in continuous memory for persistence within a serialized security descriptor.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-claim_security_attribute_relative_v1
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLAIM_SECURITY_ATTRIBUTE_RELATIVE_V1
    {

        /// DWORD->unsigned int
        public uint Name;

        /// WORD->unsigned short
        public ushort ValueType;

        /// WORD->unsigned short
        public ushort Reserved;

        /// DWORD->unsigned int
        public uint Flags;

        /// DWORD->unsigned int
        public uint ValueCount;

        /// Anonymous_a16cddb8_ae7e_4828_baea_a2dccae6bcc2
        public CLAIM_SECURITY_ATTRIBUTE_RELATIVE_V1_VALUES Values;
    }


    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct CLAIM_SECURITY_ATTRIBUTE_RELATIVE_V1_VALUES
    {

        /// DWORD[1]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.U4)]
        [FieldOffset(0)]
        public uint[] pInt64;

        /// DWORD[1]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.U4)]
        [FieldOffset(0)]
        public uint[] pUint64;

        /// DWORD[1]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.U4)]
        [FieldOffset(0)]
        public uint[] ppString;

        /// DWORD[1]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.U4)]
        [FieldOffset(0)]
        public uint[] pFqbn;

        /// DWORD[1]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.U4)]
        [FieldOffset(0)]
        public uint[] pOctetString;
    }
}