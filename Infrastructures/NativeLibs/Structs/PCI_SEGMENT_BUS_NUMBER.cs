using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Reserved for system use.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-pci_segment_bus_number
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PCI_SEGMENT_BUS_NUMBER
    {    
        /// Anonymous_0008e907_d3e8_465f_b5b5_1ced81cd7537
        public PCI_SEGMENT_BUS_NUMBER_U u;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct PCI_SEGMENT_BUS_NUMBER_U
    {

        /// Anonymous_a8122682_f893_4eef_b337_b7fbdcc9f137
        [FieldOffset(0)]
        public PCI_SEGMENT_BUS_NUMBER_BITS bits;

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint AsULONG;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PCI_SEGMENT_BUS_NUMBER_BITS
    {

        /// BusNumber : 8
        ///SegmentNumber : 16
        ///Reserved : 8
        public uint bitvector1;

        public uint BusNumber
        {
            get
            {
                return ((uint)((this.bitvector1 & 255u)));
            }
            set
            {
                this.bitvector1 = ((uint)((value | this.bitvector1)));
            }
        }

        public uint SegmentNumber
        {
            get
            {
                return ((uint)(((this.bitvector1 & 16776960u)
                            / 256)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 256)
                            | this.bitvector1)));
            }
        }

        public uint Reserved
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4278190080u)
                            / 16777216)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 16777216)
                            | this.bitvector1)));
            }
        }
    }
}
