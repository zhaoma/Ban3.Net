using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Device drivers perform a bitwise OR operation with this member in their newly created device objects
    /// by using one or more of the following system-defined values.
    /// </summary>
    [Flags]
    public enum DEVICE_OBJECT_FLAGS
    {
        DO_BUFFERED_IO,
        DO_DIRECT_IO,

        /// <summary>
        /// The operating system sets this flag in each physical device object (PDO). 
        /// Drivers must not modify this flag.
        /// </summary>
        DO_BUS_ENUMERATED_DEVICE,

        /// <summary>
        /// The I/O manager sets this flag when it creates the device object. 
        /// A device function driver or filter driver clears the flag in its AddDevice routine, 
        /// after it does the following:
        /// 
        /// Attaches the device object to the device stack.
        /// Establishes the device power state.
        /// Performs a bitwise OR operation on the member with one of the power flags (if it is necessary).
        /// 
        /// The Plug and Play (PnP) manager checks that the flag is clear after the AddDevice routine returns.
        /// </summary>
        DO_DEVICE_INITIALIZING,

        /// <summary>
        /// Indicates that the driver services an exclusive device, such as a video, serial, parallel, or sound device. 
        /// WDM drivers must not set this flag. 
        /// For more information, see the Specifying Exclusive Access to Device Objects topic.
        /// </summary>
        DO_EXCLUSIVE,

        /// <summary>
        /// This flag is no longer used. Drivers should not set this flag.
        /// </summary>
        DO_MAP_IO_BUFFER,

        /// <summary>
        /// Drivers of devices that require inrush current when the device is turned on must set this flag. 
        /// A driver cannot set both this flag and DO_POWER_PAGABLE.
        /// </summary>
        DO_POWER_INRUSH,

        /// <summary>
        /// Pageable drivers that are compatible with Microsoft Windows 2000 and later versions of Windows, 
        /// are not part of the paging path, and do not require inrush current must set this flag. 
        /// The system calls such drivers at IRQL = PASSIVE_LEVEL. 
        /// Drivers cannot set both this flag and DO_POWER_INRUSH. 
        /// All drivers for WDM, Microsoft Windows 98, and Windows Millennium Edition must set DO_POWER_PAGABLE.
        /// </summary>
        DO_POWER_PAGABLE,

        /// <summary>
        /// Used by the I/O manager to indicate that a driver has registered the device object for shutdown notifications. 
        /// This flag should not be used by drivers.
        /// </summary>
        DO_SHUTDOWN_REGISTERED,

        /// <summary>
        /// Removable-media drivers set this flag while they process transfer requests. 
        /// Such drivers should also check for this flag in the target for a transfer request before they transfer any data. 
        /// For more information, see the Supporting Removable Media topic.
        /// </summary>
        DO_VERIFY_VOLUME
    }
}
