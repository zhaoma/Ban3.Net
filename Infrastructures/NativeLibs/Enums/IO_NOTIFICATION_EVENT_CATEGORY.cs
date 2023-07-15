using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Specifies the category of PnP event for which the callback routine is being registered. 
    /// Used in IoRegisterPlugPlayNotification.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-io_notification_event_category
    /// </summary>
    public enum IO_NOTIFICATION_EVENT_CATEGORY
    {
        /// <summary>
        /// Reserved for system use.
        /// </summary>
        EventCategoryReserved,

        /// <summary>
        /// PnP events in this category include query-change (GUID_HWPROFILE_QUERY_CHANGE), 
        /// change-complete (GUID_HWPROFILE_CHANGE_COMPLETE), 
        /// and change-cancel (GUID_HWPROFILE_CHANGE_CANCELLED) of a hardware profile.
        /// </summary>
        EventCategoryHardwareProfileChange,

        /// <summary>
        /// PnP events in this category include the arrival (enabling) of 
        /// a new instance of a device interface class (GUID_DEVICE_INTERFACE_ARRIVAL), 
        /// or the removal (disabling) of an existing device interface instance (GUID_DEVICE_INTERFACE_REMOVAL).
        /// </summary>
        EventCategoryDeviceInterfaceChange,

        /// <summary>
        /// PnP events in this category include events related to removing a device: 
        /// the device's drivers received a query-remove IRP (GUID_TARGET_DEVICE_QUERY_REMOVE), 
        /// the drivers completed a remove IRP (GUID_TARGET_DEVICE_REMOVE_COMPLETE), 
        /// or the drivers received a cancel-remove IRP (GUID_TARGET_DEVICE_REMOVE_CANCELLED). 
        /// This category is also used for custom notification events.
        /// </summary>
        EventCategoryTargetDeviceChange,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        EventCategoryKernelSoftRestart
    }
}
