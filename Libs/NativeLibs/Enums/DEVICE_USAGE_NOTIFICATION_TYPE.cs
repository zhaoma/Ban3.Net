using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-device_usage_notification_type
    /// </summary>
    public enum DEVICE_USAGE_NOTIFICATION_TYPE
    {
        DeviceUsageTypeUndefined,
        DeviceUsageTypePaging,
        DeviceUsageTypeHibernation,
        DeviceUsageTypeDumpFile,
        DeviceUsageTypeBoot,
        DeviceUsageTypePostDisplay,
        DeviceUsageTypeGuestAssigned
    }
}
