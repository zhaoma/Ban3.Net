using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The RESOURCEMANAGER_INFORMATION_CLASS enumeration identifies the type of information that the ZwQueryInformationResourceManager routine can retrieve for a resource manager object.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_resourcemanager_information_class
    /// </summary>
    public enum RESOURCEMANAGER_INFORMATION_CLASS
    {
        /// <summary>
        /// Information about a resource manager object is stored in a RESOURCEMANAGER_BASIC_INFORMATION structure.
        /// </summary>
        ResourceManagerBasicInformation,

        /// <summary>
        /// Information about a resource manager object is stored in a RESOURCEMANAGER_COMPLETION_INFORMATION structure.
        /// </summary>
        ResourceManagerCompletionInformation
    }
}
