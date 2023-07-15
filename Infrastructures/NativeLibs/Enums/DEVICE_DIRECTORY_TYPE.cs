using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Defines values for the type of directory used by the driver to load and store files specific to a device instance. 
    /// This enumeration is used by the IoGetDeviceDirectory function.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_device_directory_type
    /// </summary>
    public enum DEVICE_DIRECTORY_TYPE
    {
        /// <summary>
        /// The requested directory is a general-purpose directory in which the driver stores files, specific to a device instance.
        /// </summary>
        DeviceDirectoryData
    }
}
