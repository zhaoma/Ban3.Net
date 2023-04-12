using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HWPROFILE_CHANGE_NOTIFICATION structure describes an event related to a hardware profile configuration change. 
    /// The PnP manager sends this structure to a driver that registered a callback routine for notification of EventCategoryHardwareProfileChange events.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_hwprofile_change_notification
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct HWPROFILE_CHANGE_NOTIFICATION
    {
        /// <summary>
        /// Specifies the version of the data structure, currently 1.
        /// </summary>
        public ushort Version;

        /// <summary>
        /// Specifies the size of the structure, in bytes including the size of the standard first three members plus the event-specific data.
        /// </summary>
        public ushort Size;

        /// <summary>
        /// Specifies a GUID identifying the event: GUID_HWPROFILE_QUERY_CHANGE, GUID_HWPROFILE_CHANGE_COMPLETE, or GUID_HWPROFILE_CHANGE_CANCELLED. 
        /// The GUIDs are defined in Wdmguid.h.
        /// </summary>
        public GUID Event;
    }
}
