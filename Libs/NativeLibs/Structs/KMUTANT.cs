using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-kmutant
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KMUTANT
    {
        /// PVOID->void*
        public System.IntPtr Header;

        /// LIST_ENTRY->_LIST_ENTRY
        public LIST_ENTRY MutantListEntry;

        /// _KTHREAD*
        public System.IntPtr OwnerThread;

        /// Anonymous_d526acf2_4865_4df7_8972_09f2649edb79
        public KMUTANT_UNION Union1;

        /// UCHAR->unsigned char
        public byte ApcDisable;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct KMUTANT_UNION
    {

        /// UCHAR->unsigned char
        [FieldOffset(0)]
        public byte MutantFlags;

        /// Anonymous_a9246ec7_c9a9_430b_8c25_e395fc6763ca
        [FieldOffset(0)]
        public KMUTANT_DUMMY DUMMYSTRUCTNAME;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KMUTANT_DUMMY
    {

        /// Abandoned : 1
        ///Spare1 : 7
        public uint bitvector1;

        public uint Abandoned
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

        public uint Spare1
        {
            get
            {
                return ((uint)(((this.bitvector1 & 254u)
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
