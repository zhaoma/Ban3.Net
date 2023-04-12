using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The PROCESSOR_NUMBER structure identifies a processor by its group number and group-relative processor number.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/miniport/ns-miniport-_processor_number
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESSOR_NUMBER
    {
        /// <summary>
        /// The group number. 
        /// If multiprocessor system contains n groups, the groups are numbered from 0 to n-1.
        /// </summary>
        public ushort Group;

        /// <summary>
        /// The group-relative processor number. 
        /// If a group contains m logical processors, the processors are numbered from 0 to m-1.
        /// </summary>
        public byte Number;

        /// <summary>
        /// Reserved for future use. Initialize to zero.
        /// </summary>
        public byte Reserved;
    }
}
