using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The SYSTEM_POWER_STATE enumeration type is used to indicate a system power state.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_system_power_state
    /// </summary>
    public enum SYSTEM_POWER_STATE
    {
        /// <summary>
        /// Indicates an unspecified system power state.
        /// </summary>
        PowerSystemUnspecified = 0,

        /// <summary>
        /// Indicates maximum system power, which corresponds to system working state S0.
        /// </summary>
        PowerSystemWorking = 1,

        /// <summary>
        /// Indicates a system sleeping state less than PowerSystemWorking and greater than PowerSystemSleeping2, 
        /// which corresponds to system power state S1.
        /// </summary>
        PowerSystemSleeping1 = 2,

        /// <summary>
        /// Indicates a system sleeping state less than PowerSystemSleeping1 and greater than PowerSystemSleeping3, 
        /// which corresponds to system power state S2.
        /// </summary>
        PowerSystemSleeping2 = 3,

        /// <summary>
        /// Indicates a system sleeping state less than PowerSystemSleeping2 and greater than PowerSystemHibernate, 
        /// which corresponds to system power state S3.
        /// </summary>
        PowerSystemSleeping3 = 4,

        /// <summary>
        /// Indicates the lowest-powered sleeping state, 
        /// which corresponds to system power state S4.
        /// </summary>
        PowerSystemHibernate = 5,

        /// <summary>
        /// Indicates the system is turned off, 
        /// which corresponds to system shutdown state S5.
        /// </summary>
        PowerSystemShutdown = 6,

        /// <summary>
        /// The number of system power state values for this enumeration type that represents actual power states. 
        /// This value is the number of elements in the DeviceState member of the DEVICE_CAPABILITIES structure for a device. 
        /// The other system power state values are less than this value.
        /// </summary>
        PowerSystemMaximum = 7,
    }
}
