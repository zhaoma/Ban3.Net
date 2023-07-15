using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CM_INT13_DRIVE_PARAMETER structure defines a device-type-specific data record 
    /// that is stored in the \Registry\Machine\Hardware\Description tree for a disk controller 
    /// if the system can collect this information during the boot process.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cm_int13_drive_parameter
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CM_INT13_DRIVE_PARAMETER
    {
        /// <summary>
        /// The drive selected value.
        /// </summary>
        public ushort DriveSelect;

        /// <summary>
        /// The maximum number of cylinders.
        /// </summary>
        public uint MaxCylinders;

        /// <summary>
        /// The number of sectors per track.
        /// </summary>
        public ushort SectorsPerTrack;

        /// <summary>
        /// The maximum number of heads.
        /// </summary>
        public ushort MaxHeads;

        /// <summary>
        /// The number of drives.
        /// </summary>
        public ushort NumberDrives;
    }
}
