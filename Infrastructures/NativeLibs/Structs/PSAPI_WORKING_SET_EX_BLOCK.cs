using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains extended working set information for a page.
    /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-psapi_working_set_ex_block
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct PSAPI_WORKING_SET_EX_BLOCK
    {
        /// ULONG_PTR->unsigned int
        [FieldOffset(0)]
        public uint Flags;

        /// Anonymous_0c11d28e_6b19_4768_8771_3d6d267b85a1
        [FieldOffset(0)]
        public PSAPI_WORKING_SET_EX_BLOCK_UNION Union1;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct PSAPI_WORKING_SET_EX_BLOCK_UNION
    {

        /// Anonymous_40e399d5_3029_46fd_b02b_752e3fc88f74
        [FieldOffset(0)]
        public PSAPI_WORKING_SET_EX_BLOCK_STRUCT Struct1;

        /// Anonymous_a23d1404_7cbd_43f4_a51b_b66e7455d03b
        [FieldOffset(0)]
        public PSAPI_WORKING_SET_EX_BLOCK_INVALID Invalid;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PSAPI_WORKING_SET_EX_BLOCK_STRUCT
    {

        /// Valid : 1
        ///ShareCount : 3
        ///Win32Protection : 11
        ///Shared : 1
        ///Node : 6
        ///Locked : 1
        ///LargePage : 1
        ///Reserved : 7
        ///Bad : 1
        ///ReservedUlong : 32
        public uint bitvector1;

        public uint Valid
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

        public uint ShareCount
        {
            get
            {
                return ((uint)(((this.bitvector1 & 14u)
                            / 2)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 2)
                            | this.bitvector1)));
            }
        }

        public uint Win32Protection
        {
            get
            {
                return ((uint)(((this.bitvector1 & 32752u)
                            / 16)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 16)
                            | this.bitvector1)));
            }
        }

        public uint Shared
        {
            get
            {
                return ((uint)(((this.bitvector1 & 32768u)
                            / 32768)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 32768)
                            | this.bitvector1)));
            }
        }

        public uint Node
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4128768u)
                            / 65536)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 65536)
                            | this.bitvector1)));
            }
        }

        public uint Locked
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4194304u)
                            / 4194304)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 4194304)
                            | this.bitvector1)));
            }
        }

        public uint LargePage
        {
            get
            {
                return ((uint)(((this.bitvector1 & 8388608u)
                            / 8388608)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 8388608)
                            | this.bitvector1)));
            }
        }

        public uint Reserved
        {
            get
            {
                return ((uint)(((this.bitvector1 & 2130706432u)
                            / 16777216)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 16777216)
                            | this.bitvector1)));
            }
        }

        public uint Bad
        {
            get
            {
                return ((uint)(((this.bitvector1 & 2147483648u)
                            / 2147483648)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 2147483648)
                            | this.bitvector1)));
            }
        }

        public uint ReservedUlong
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4294967295u)
                            / 4294967296)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 4294967296)
                            | this.bitvector1)));
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PSAPI_WORKING_SET_EX_BLOCK_INVALID
    {

        /// Valid : 1
        ///Reserved0 : 14
        ///Shared : 1
        ///Reserved1 : 15
        ///Bad : 1
        ///ReservedUlong : 32
        public uint bitvector1;

        public uint Valid
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

        public uint Reserved0
        {
            get
            {
                return ((uint)(((this.bitvector1 & 32766u)
                            / 2)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 2)
                            | this.bitvector1)));
            }
        }

        public uint Shared
        {
            get
            {
                return ((uint)(((this.bitvector1 & 32768u)
                            / 32768)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 32768)
                            | this.bitvector1)));
            }
        }

        public uint Reserved1
        {
            get
            {
                return ((uint)(((this.bitvector1 & 2147418112u)
                            / 65536)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 65536)
                            | this.bitvector1)));
            }
        }

        public uint Bad
        {
            get
            {
                return ((uint)(((this.bitvector1 & 2147483648u)
                            / 2147483648)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 2147483648)
                            | this.bitvector1)));
            }
        }

        public uint ReservedUlong
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4294967295u)
                            / 4294967296)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 4294967296)
                            | this.bitvector1)));
            }
        }
    }
}