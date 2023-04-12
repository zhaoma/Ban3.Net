using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CM_MCA_POS_DATA structure is obsolete. It defines IBM-compatible MCA POS configuration information for a slot.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cm_mca_pos_data
    /// This structure is used by the obsolete HalGetBusData and HalGetBusDataByOffset routines.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CM_MCA_POS_DATA
    {    
        /// USHORT->unsigned short
        public ushort AdapterId;

        /// UCHAR->unsigned char
        public byte PosData1;

        /// UCHAR->unsigned char
        public byte PosData2;

        /// UCHAR->unsigned char
        public byte PosData3;

        /// UCHAR->unsigned char
        public byte PosData4;
    }
}
