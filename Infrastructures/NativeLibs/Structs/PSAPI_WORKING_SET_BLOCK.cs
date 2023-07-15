using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains working set information for a page.
    /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-psapi_working_set_block
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct PSAPI_WORKING_SET_BLOCK
    {
        /// <summary>
        /// The working set information.
        /// See the description of the structure members for information about the layout of this variable.
        /// </summary>
        [FieldOffset(0)]
        public uint Flags;

        /// Anonymous_87a803d5_770b_4c0e_8a93_a312f13f5adc
        [FieldOffset(0)]
        public PSAPI_WORKING_SET_BLOCK_STRUCT Struct1;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PSAPI_WORKING_SET_BLOCK_STRUCT
    {

        /// Protection : 5
        ///ShareCount : 3
        ///Shared : 1
        ///Reserved : 3
        ///VirtualPage : 20
        public uint bitvector1;

        /// <summary>
        /// The protection attributes of the page. 
        /// </summary>
        public uint Protection
        {
            get
            {
                return ((uint)((this.bitvector1 & 31u)));
            }
            set
            {
                this.bitvector1 = ((uint)((value | this.bitvector1)));
            }
        }

        /// <summary>
        /// The number of processes that share this page. The maximum value of this member is 7.
        /// </summary>
        public uint ShareCount
        {
            get
            {
                return ((uint)(((this.bitvector1 & 224u)
                                / 32)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 32)
                                           | this.bitvector1)));
            }
        }

        /// <summary>
        /// If this bit is 1, the page is sharable; otherwise, the page is not sharable.
        /// </summary>
        public uint Shared
        {
            get
            {
                return ((uint)(((this.bitvector1 & 256u)
                                / 256)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 256)
                                           | this.bitvector1)));
            }
        }

        /// <summary>
        /// This member is reserved.
        /// </summary>
        public uint Reserved
        {
            get
            {
                return ((uint)(((this.bitvector1 & 3584u)
                                / 512)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 512)
                                           | this.bitvector1)));
            }
        }

        /// <summary>
        /// The address of the page in the virtual address space.
        /// 64-bit Windows:  This member is 52 bits in length.
        /// </summary>
        public uint VirtualPage
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