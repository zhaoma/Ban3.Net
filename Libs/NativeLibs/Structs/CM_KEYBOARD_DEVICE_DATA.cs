using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CM_KEYBOARD_DEVICE_DATA structure defines a device-type-specific data record 
    /// that is stored in the \Registry\Machine\Hardware\Description tree for a keyboard peripheral 
    /// if the system can collect this information during the boot process.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cm_keyboard_device_data
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CM_KEYBOARD_DEVICE_DATA
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
        /// The type of the keyboard.
        /// </summary>
        public byte Type;

        /// <summary>
        /// The subtype of the keyboard.
        /// </summary>
        public byte Subtype;

        /// <summary>
        /// Defined by x86 BIOS INT 16h, function 02 as KEYBOARD_FLAGS
        /// </summary>
        public KEYBOARD_FLAGS KeyboardFlags;
    }
}
