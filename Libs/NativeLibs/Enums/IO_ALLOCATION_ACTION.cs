using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The IO_ALLOCATION_ACTION enumerated type is used to specify 
    /// return values for AdapterControl and ControllerControl routines.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_io_allocation_action
    /// </summary>
    public enum IO_ALLOCATION_ACTION
    {
        /// <summary>
        /// Indicates that you want the driver to retain ownership of the adapter or controller object.
        /// </summary>
        KeepObject,

        /// <summary>
        /// Indicates that you do not want the driver to retain ownership of the adapter or controller object.
        /// </summary>
        DeallocateObject,

        /// <summary>
        /// For adapter objects only. 
        /// Indicates that you do not want the driver to retain ownership of the adapter object,
        /// but you do want the driver to retain ownership of the allocated map registers.
        /// </summary>
        DeallocateObjectKeepRegisters
    }
}
