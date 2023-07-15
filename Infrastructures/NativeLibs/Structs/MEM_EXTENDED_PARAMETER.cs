using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-mem_extended_parameter
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MEM_EXTENDED_PARAMETER
    {
        /// Anonymous_34d344ca_e9aa_455c_9c1d_a3c1e7811a63
        public MEM_EXTENDED_PARAMETER_DUMMY DUMMYSTRUCTNAME;

        /// Anonymous_6ca8b287_b730_427f_b82c_e142ae854df6
        public MEM_EXTENDED_PARAMETER_UNION Union1;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MEM_EXTENDED_PARAMETER_DUMMY
    {

        /// ULONG64->unsigned __int64
        public ulong Type;

        /// ULONG64->unsigned __int64
        public ulong Reserved;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct MEM_EXTENDED_PARAMETER_UNION
    {

        /// ULONG64->unsigned __int64
        [FieldOffset(0)]
        public ulong ULong64;

        /// PVOID->void*
        [FieldOffset(0)]
        public System.IntPtr Pointer;

        /// SIZE_T->ULONG_PTR->unsigned int
        [FieldOffset(0)]
        public uint Size;

        /// HANDLE->void*
        [FieldOffset(0)]
        public System.IntPtr Handle;

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint ULong;
    }
}
