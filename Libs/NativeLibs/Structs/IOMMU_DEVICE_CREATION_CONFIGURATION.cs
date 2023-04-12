using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// IOMMU_DEVICE_CREATION_CONFIGURATION describes a configuration or list of configurations 
    /// to be used as part of creation and initialization of an IOMMU_DMA_DEVICE.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-iommu_device_creation_configuration
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IOMMU_DEVICE_CREATION_CONFIGURATION
    {
        /// <summary>
        /// Optional list to provide additional configurations.
        /// </summary>
        public LIST_ENTRY NextConfiguration;

        /// <summary>
        /// An enum describing which configuration is represented. See IOMMU_DEVICE_CREATION_CONFIGURATION_TYPE.
        /// </summary>
        public IOMMU_DEVICE_CREATION_CONFIGURATION_TYPE ConfigType;

        /// 
        public IOMMU_DEVICE_CREATION_CONFIGURATION_UNION Union1;
    }

    
    [StructLayout(LayoutKind.Explicit)]
    public struct IOMMU_DEVICE_CREATION_CONFIGURATION_UNION
    {
        /// <summary>
        /// If (ConfigType == IommuDeviceCreationConfigTypeAcpi), provides the input parameters necessary for device creation.
        /// </summary>
        [FieldOffset(0)]
        public IOMMU_DEVICE_CREATION_CONFIGURATION_ACPI Acpi;

        /// <summary>
        /// Defines the PVOID member DeviceId.
        /// </summary>
        [FieldOffset(0)]
        public IntPtr DeviceId;
    }

    /// <summary>
    /// IOMMU_DEVICE_CREATION_CONFIGURATION_ACPI provides the ACPI-specific configuration parameters of a IOMMU_DEVICE_CREATION_CONFIGURATION structure, 
    /// which is provided for creation of an ACPI-type IOMMU_DMA_DEVICE.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-iommu_device_creation_configuration_acpi
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IOMMU_DEVICE_CREATION_CONFIGURATION_ACPI
    {
        /// <summary>
        /// Provides the input mapping base for the device's desired stream.
        /// </summary>
        public uint InputMappingBase;

        /// <summary>
        /// Provides the count of mappings beginning at the base.
        /// </summary>
        public uint MappingsCount;
    }
}
