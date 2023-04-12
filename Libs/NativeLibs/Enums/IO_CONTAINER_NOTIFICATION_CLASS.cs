using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The IO_CONTAINER_NOTIFICATION_CLASS enumeration contains constants 
    /// that indicate the classes of events for 
    /// which a kernel-mode driver can register to receive notifications.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_io_container_notification_class
    /// </summary>
    public enum IO_CONTAINER_NOTIFICATION_CLASS
    {
        /// <summary>
        /// Session state notifications. 
        /// The driver uses this enumeration constant to request notifications about changes 
        /// in the state of user sessions that the driver is interested in.
        /// </summary>
        IoSessionStateNotification,

        /// <summary>
        /// Specifies the maximum value in this enumeration type.
        /// </summary>
        IoMaxContainerNotificationClass
    }
}
