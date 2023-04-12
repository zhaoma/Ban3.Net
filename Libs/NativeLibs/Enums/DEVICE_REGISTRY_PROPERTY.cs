using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The DEVICE_REGISTRY_PROPERTY enumeration identifies device properties that are stored in the registry.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-device_registry_property
    /// </summary>
    public enum DEVICE_REGISTRY_PROPERTY
    {
        DevicePropertyDeviceDescription,
        DevicePropertyHardwareID,
        DevicePropertyCompatibleIDs,
        DevicePropertyBootConfiguration,
        DevicePropertyBootConfigurationTranslated,
        DevicePropertyClassName,
        DevicePropertyClassGuid,
        DevicePropertyDriverKeyName,
        DevicePropertyManufacturer,
        DevicePropertyFriendlyName,
        DevicePropertyLocationInformation,
        DevicePropertyPhysicalDeviceObjectName,
        DevicePropertyBusTypeGuid,
        DevicePropertyLegacyBusType,
        DevicePropertyBusNumber,
        DevicePropertyEnumeratorName,
        DevicePropertyAddress,
        DevicePropertyUINumber,
        DevicePropertyInstallState,
        DevicePropertyRemovalPolicy,
        DevicePropertyResourceRequirements,
        DevicePropertyAllocatedResources,
        DevicePropertyContainerID
    }
}
