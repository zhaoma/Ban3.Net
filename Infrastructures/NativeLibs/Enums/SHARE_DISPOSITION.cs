using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Indicates whether the described resource can be shared. 
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cm_partial_resource_descriptor
    /// </summary>
    public enum SHARE_DISPOSITION:byte
    {
        /// <summary>
        /// The device requires exclusive use of the resource.
        /// </summary>
        CmResourceShareDeviceExclusive,

        /// <summary>
        /// The driver requires exclusive use of the resource. 
        /// Not supported for WDM drivers.
        /// </summary>
        CmResourceShareDriverExclusive,

        /// <summary>
        /// The resource can be shared without restriction.
        /// </summary>
        CmResourceShareShared
    }
}
