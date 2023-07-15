using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Defines values for the type of registry key to be used by a driver. 
    /// This enumeration is used by the IoOpenDriverRegistryKey function.
    /// </summary>
    public enum DRIVER_REGKEY_TYPE
    {
        /// <summary>
        /// The requested registry key is the immutable parameters key for the driver.
        /// </summary>
        DriverRegKeyParameters,

        /// <summary>
        /// The requested registry key is a location for mutable state to be read/written that will persist across reboots. 
        /// This mutable state is specific to the internals of the driver and only accessible by the driver itself.
        /// </summary>
        DriverRegKeyPersistentState,

        /// <summary>
        /// The requested registry key is a location for mutable state to be read/written that will persist across reboots. 
        /// This mutable state is meant to be shared between the driver and other components. 
        /// Other components can access this registry key using GetSharedServiceRegistryStateKey. 
        /// This value is available on Windows Server 2022 and later versions of Windows.
        /// </summary>
        DriverRegKeySharedPersistentState
    }
}
