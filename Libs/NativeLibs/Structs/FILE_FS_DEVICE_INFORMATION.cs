using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The FILE_FS_DEVICE_INFORMATION structure provides file system device information about the type of device object associated with a file object.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_file_fs_device_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_FS_DEVICE_INFORMATION
    {
        /// <summary>
        /// Set when a driver calls IoCreateDevice as appropriate for the type of underlying device.
        /// </summary>
        public DEVICE_TYPE DeviceType;

        /// <summary>
        /// The device characteristics.
        /// </summary>
        public DEVICE_OBJECT_CHARACTERISTICS Characteristics;
    }
}
