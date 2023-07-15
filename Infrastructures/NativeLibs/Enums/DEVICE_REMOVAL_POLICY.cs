using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The DEVICE_REMOVAL_POLICY enumeration describes a device's removal policy.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_device_removal_policy
    /// </summary>
    public enum DEVICE_REMOVAL_POLICY
    {
        /// <summary>
        /// The device is not typically removed.
        /// </summary>
        RemovalPolicyExpectNoRemoval,

        /// <summary>
        /// The device is typically removed in an orderly fashion. 
        /// (Before the device is removed, the Plug and Play [PnP] manager sends 
        /// an IRP_MN_QUERY_REMOVE_DEVICE request to the device's driver.)
        /// </summary>
        RemovalPolicyExpectOrderlyRemoval,

        /// <summary>
        /// The device can be removed suddenly. 
        /// (The driver receives no advance warning that the device will be removed. 
        /// The Plug and Play [PnP] manager sends an IRP_MN_SURPRISE_REMOVAL request when the device is removed.)
        /// </summary>
        RemovalPolicyExpectSurpriseRemoval
    }
}
