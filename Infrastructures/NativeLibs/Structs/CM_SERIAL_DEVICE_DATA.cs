using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CM_SERIAL_DEVICE_DATA structure defines a device-type-specific data record 
    /// that is stored in the \Registry\Machine\Hardware\Description tree for a serial controller 
    /// if the system can collect this information during the boot process.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cm_serial_device_data
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CM_SERIAL_DEVICE_DATA
    {
        /// <summary>
        /// The version number of this structure.
        /// </summary>
        public ushort Version;

        /// <summary>
        /// The revision of this structure.
        /// </summary>
        public ushort Revision;

        /// <summary>
        /// The clock baud rate, in megahertz, at which data is transferred.
        /// </summary>
        public uint BaudClock;
    }
}
