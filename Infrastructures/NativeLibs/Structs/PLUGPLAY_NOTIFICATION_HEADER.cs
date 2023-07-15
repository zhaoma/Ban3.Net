using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// A PLUGPLAY_NOTIFICATION_HEADER structure is included at the beginning of each PnP notification structure, 
    /// such as a DEVICE_INTERFACE_CHANGE_NOTIFICATION structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_plugplay_notification_header
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PLUGPLAY_NOTIFICATION_HEADER
    {
        /// <summary>
        /// Specifies the version of the data structure, currently set to 1.
        /// </summary>
        public ushort Version;

        /// <summary>
        /// Specifies the size of the structure, in bytes.
        /// </summary>
        public ushort Size;

        /// <summary>
        /// Specifies a GUID identifying the event.
        /// </summary>
        public GUID Event;
    }
}
