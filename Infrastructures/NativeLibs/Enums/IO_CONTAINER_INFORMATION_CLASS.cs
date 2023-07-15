using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The IO_CONTAINER_INFORMATION_CLASS enumeration contains constants 
    /// that indicate the classes of system information that a kernel-mode driver can request.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_io_container_information_class
    /// </summary>
    public enum IO_CONTAINER_INFORMATION_CLASS
    {
        /// <summary>
        /// Session state information. 
        /// A driver uses this enumeration constant to request information about a user session.
        /// </summary>
        IoSessionStateInformation,

        /// <summary>
        /// Specifies the maximum value in this enumeration type.
        /// </summary>
        IoMaxContainerInformationClass
    }
}
