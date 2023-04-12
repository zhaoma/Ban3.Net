using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TARGET_DEVICE_REMOVAL_NOTIFICATION structure describes a device-removal event. 
    /// The PnP manager sends this structure to a driver that registered a callback routine for notification of EventCategoryTargetDeviceChange events.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_target_device_removal_notification
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TARGET_DEVICE_REMOVAL_NOTIFICATION
    {
        /// USHORT->unsigned short
        public ushort Version;

        /// USHORT->unsigned short
        public ushort Size;

        /// GUID->_GUID
        public GUID Event;

        /// PVOID->void*
        public System.IntPtr FileObject;
    }
}
