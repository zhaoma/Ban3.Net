using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The PCI_SLOT_NUMBER structure is obsolete. 
    /// It defines the format of the Slot parameter to the obsolete HalXxxBusData routines when they are called with the BusDataType value PCIConfiguration.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_pci_slot_number
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PCI_SLOT_NUMBER
    {
        public PCI_SLOT_NUMBER_U u;
    }


    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct PCI_SLOT_NUMBER_U
    {

        /// Anonymous_3f178825_1658_4f91_9ec3_0d4bbaefccce
        [FieldOffset(0)]
        public PCI_SLOT_NUMBER_BITS bits;

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint AsULONG;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct PCI_SLOT_NUMBER_BITS
    {

        /// DeviceNumber : 5
        ///FunctionNumber : 3
        ///Reserved : 24
        public uint bitvector1;

        public uint DeviceNumber
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

        public uint FunctionNumber
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

        public uint Reserved
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4294967040u)
                            / 256)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 256)
                            | this.bitvector1)));
            }
        }
    }
}
