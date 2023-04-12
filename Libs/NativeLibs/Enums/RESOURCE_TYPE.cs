using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// These flags are used within both CM_PARTIAL_RESOURCE_DESCRIPTOR and IO_RESOURCE_DESCRIPTOR structures, 
    /// except where noted.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cm_partial_resource_descriptor
    /// </summary>
    public enum RESOURCE_TYPE:byte
    {
        /// <summary>
        /// u.Port
        /// </summary>
        CmResourceTypePort,

        /// <summary>
        /// u.Interrupt or u.MessageInterrupt.If the CM_RESOURCE_INTERRUPT_MESSAGE flag of Flags is set, 
        /// use u.MessageInterrupt; otherwise, use u.Interrupt.
        /// </summary>
        CmResourceTypeInterrupt,

        /// <summary>
        /// u.Memory
        /// </summary>
        CmResourceTypeMemory,

        /// <summary>
        /// One of u.Memory40, u.Memory48, or u.Memory64.
        /// The CM_RESOURCE_MEMORY_LARGE_XXX flags set in the Flags member determines which structure is used.
        /// </summary>
        CmResourceTypeMemoryLarge,

        /// <summary>
        /// u.Dma (if CM_RESOURCE_DMA_V3 is not set) or u.DmaV3 (if CM_RESOURCE_DMA_V3 flag is set)
        /// </summary>
        CmResourceTypeDma,

        /// <summary>
        /// u.DevicePrivate
        /// </summary>
        CmResourceTypeDevicePrivate,

        /// <summary>
        /// u.BusNumber
        /// </summary>
        CmResourceTypeBusNumber,

        /// <summary>
        /// u.DeviceSpecificData(Not used within IO_RESOURCE_DESCRIPTOR.)
        /// </summary>
        CmResourceTypeDeviceSpecific,

        /// <summary>
        /// u.DevicePrivate
        /// </summary>
        CmResourceTypePcCardConfig,

        /// <summary>
        /// u.DevicePrivate
        /// </summary>
        CmResourceTypeMfCardConfig,

        /// <summary>
        /// u.Connection
        /// </summary>
        CmResourceTypeConnection,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        CmResourceTypeConfigData,

        /// <summary>
        /// Not used.
        /// </summary>
        CmResourceTypeNonArbitrated
    }
}
