using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POOL_EXTENDED_PARAMETER
    {    
        /// Anonymous_69271b2f_55b7_482e_a213_f60c76745b0f
        public POOL_EXTENDED_PARAMETER_DUMMY DUMMYSTRUCTNAME;

        /// Anonymous_c92feb13_f583_41de_b6c3_966937af23dc
        public POOL_EXTENDED_PARAMETER_UNION Union1;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct POOL_EXTENDED_PARAMETER_DUMMY
    {

        /// ULONG64->unsigned __int64
        public ulong Type;

        /// ULONG64->unsigned __int64
        public ulong Optional;

        /// ULONG64->unsigned __int64
        public ulong Reserved;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct POOL_EXTENDED_PARAMETER_UNION
    {

        /// ULONG64->unsigned __int64
        [FieldOffset(0)]
        public ulong Reserved2;

        /// PVOID->void*
        [FieldOffset(0)]
        public System.IntPtr Reserved3;

        /// PVOID->void*
        [FieldOffset(0)]
        public System.IntPtr Priority;

        /// PVOID*
        [FieldOffset(0)]
        public System.IntPtr SecurePoolParams;

        /// PVOID->void*
        [FieldOffset(0)]
        public System.IntPtr PreferredNode;
    }
}
