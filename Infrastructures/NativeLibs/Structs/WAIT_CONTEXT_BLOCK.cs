using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WAIT_CONTEXT_BLOCK
    {
        /// Anonymous_0908d3fe_4ea2_419a_bbb2_8dcab6f3aae7
        public WAIT_CONTEXT_BLOCK_UNION Union1;

        /// PVOID->void*
        public System.IntPtr DeviceRoutine;

        /// PVOID->void*
        public System.IntPtr DeviceContext;

        /// ULONG->unsigned int
        public uint NumberOfMapRegisters;

        /// PVOID->void*
        public System.IntPtr DeviceObject;

        /// PVOID->void*
        public System.IntPtr CurrentIrp;

        /// PVOID->void*
        public System.IntPtr BufferChainingDpc;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct WAIT_CONTEXT_BLOCK_UNION
    {

        /// PVOID->void*
        [FieldOffset(0)]
        public System.IntPtr WaitQueueEntry;

        /// Anonymous_e791549f_c477_4f88_aed7_ccffd2646b44
        [FieldOffset(0)]
        public WAIT_CONTEXT_BLOCK_STRUCT Struct1;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WAIT_CONTEXT_BLOCK_STRUCT
    {

        /// LIST_ENTRY->_LIST_ENTRY
        public LIST_ENTRY DmaWaitEntry;

        /// ULONG->unsigned int
        public uint NumberOfChannels;

        /// SyncCallback : 1
        ///DmaContext : 1
        ///ZeroMapRegisters : 1
        ///Reserved : 9
        ///NumberOfRemapPages : 20
        public uint bitvector1;

        public uint SyncCallback
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

        public uint DmaContext
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

        public uint ZeroMapRegisters
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4u)
                            / 4)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 4)
                            | this.bitvector1)));
            }
        }

        public uint Reserved
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4088u)
                            / 8)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 8)
                            | this.bitvector1)));
            }
        }

        public uint NumberOfRemapPages
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4294963200u)
                            / 4096)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 4096)
                            | this.bitvector1)));
            }
        }
    }
}
