using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The OB_POST_OPERATION_INFORMATION structure provides information about a process or thread handle operation to an ObjectPostCallback routine.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ob_post_operation_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct OB_POST_OPERATION_INFORMATION
    {    
        /// ULONG->unsigned int
        public OB_OPERATION Operation;

        /// Anonymous_a042da44_8926_41e5_b61c_ab6cf9a0988c
        public OB_POST_OPERATION_INFORMATION_UNION Union1;

        /// PVOID->void*
        public System.IntPtr Object;

        /// PVOID->void*
        public System.IntPtr ObjectType;

        /// PVOID->void*
        public System.IntPtr CallContext;

        /// PVOID->void*
        public NTSTATUS ReturnStatus;

        /// PVOID->void*
        public System.IntPtr Parameters;
    }


    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct OB_POST_OPERATION_INFORMATION_UNION
    {

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint Flags;

        /// Anonymous_ca2ede5e_82cc_4151_b0bb_6f5d7234084a
        [FieldOffset(0)]
        public OB_POST_OPERATION_INFORMATION_STRUCT Struct1;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct OB_POST_OPERATION_INFORMATION_STRUCT
    {

        /// KernelHandle : 1
        ///Reserved : 31
        public uint bitvector1;

        public uint KernelHandle
        {
            get
            {
                return ((uint)((this.bitvector1 & 1u)));
            }
            set
            {
                this.bitvector1 = ((uint)((value | this.bitvector1)));
            }
        }

        public uint Reserved
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4294967294u)
                            / 2)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 2)
                            | this.bitvector1)));
            }
        }
    }
}
