using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The POWER_REQUEST_TYPE enumeration indicates the power request type.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_power_request_type
    /// </summary>
    public enum POWER_REQUEST_TYPE
    {
        /// <summary>
        /// Not used by drivers. For more information, see Remarks.
        /// </summary>
        PowerRequestDisplayRequired,

        /// <summary>
        /// Prevents the computer from automatically entering sleep mode after a period of user inactivity.
        /// </summary>
        PowerRequestSystemRequired,

        /// <summary>
        /// Not used by drivers. 
        /// </summary>
        PowerRequestAwayModeRequired,

        /// <summary>
        /// Not used by drivers.
        /// </summary>
        PowerRequestExecutionRequired
    }
}
