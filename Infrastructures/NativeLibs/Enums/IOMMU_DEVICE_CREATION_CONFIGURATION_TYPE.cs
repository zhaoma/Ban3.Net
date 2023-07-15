using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Describes the configuration types 
    /// that are used upon IOMMU_DMA_DEVICE creation depending on the device type and the system.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-iommu_device_creation_configuration_type
    /// </summary>
    public enum IOMMU_DEVICE_CREATION_CONFIGURATION_TYPE
    {
        /// <summary>
        /// Default no type.
        /// </summary>
        IommuDeviceCreationConfigTypeNone,

        /// <summary>
        /// Provides ACPI device specific parameters. This is currently used for ARM64 only.
        /// </summary>
        IommuDeviceCreationConfigTypeAcpi,

        /// <summary>
        /// Defines the IommuDeviceCreationConfigTypeDeviceId constant.
        /// </summary>
        IommuDeviceCreationConfigTypeDeviceId,

        /// <summary>
        /// Invalid type.
        /// </summary>
        IommuDeviceCreationConfigTypeMax
    }
}
