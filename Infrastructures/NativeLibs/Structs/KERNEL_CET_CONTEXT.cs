using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Reserved for system use only. Do not use.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-kernel_cet_context
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KERNEL_CET_CONTEXT
    {    
        /// ULONG64->unsigned __int64
        public ulong Ssp;

        /// ULONG64->unsigned __int64
        public ulong Rip;

        /// USHORT->unsigned short
        public ushort SegCs;

        /// Anonymous_f64bd81c_234d_4024_af22_54530647762e
        public KERNEL_CET_CONTEXT_UNION Union1;

        /// USHORT[2]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U2)]
        public ushort[] Fill;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct KERNEL_CET_CONTEXT_UNION
    {

        /// USHORT->unsigned short
        [FieldOffset(0)]
        public ushort AllFlags;

        /// Anonymous_ccff517e_25c3_41fb_a7b7_12df760bc02b
        [FieldOffset(0)]
        public KERNEL_CET_CONTEXT_DUMMY DUMMYSTRUCTNAME;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KERNEL_CET_CONTEXT_DUMMY
    {

        /// UseWrss : 1
        ///PopShadowStackOne : 1
        ///Unused : 14
        public uint bitvector1;

        public uint UseWrss
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

        public uint PopShadowStackOne
        {
            get
            {
                return ((uint)(((this.bitvector1 & 2u)
                            / 2)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 2)
                            | this.bitvector1)));
            }
        }

        public uint Unused
        {
            get
            {
                return ((uint)(((this.bitvector1 & 65532u)
                            / 4)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 4)
                            | this.bitvector1)));
            }
        }
    }
}
