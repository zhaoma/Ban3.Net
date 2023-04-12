using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The CLFS_LOG_INFORMATION_CLASS enumeration indicates the type of information that is requested by a call to ClfsQueryLogFileInformation.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_cls_log_information_class
    /// </summary>
    public enum CLS_LOG_INFORMATION_CLASS
    {
        /// <summary>
        /// Indicates that the request is for basic information about a CLFS stream and its underlying physical log. 
        /// The information is returned in a CLFS_INFORMATION structure. 
        /// Most of the structure members contain information about the underlying physical log, 
        /// but some members contain information that is specific to the stream.
        /// </summary>
        ClfsLogBasicInformation,

        /// <summary>
        /// Indicates that the request is for basic information about the physical log that underlies a CLFS stream. 
        /// The information is returned in a CLFS_INFORMATION structure. 
        /// All of the structure members contain information about the underlying physical log.
        /// </summary>
        ClfsLogBasicInformationPhysical,

        /// <summary>
        /// Indicates that the request is for information about the name of a physical CLFS log. 
        /// The information is returned in a CLFS_LOG_NAME_INFORMATION structure.
        /// </summary>
        ClfsLogPhysicalNameInformation,

        /// <summary>
        /// Indicates that the request is for a CLFS stream identifier.
        /// The information is returned in a CLFS_STREAM_ID_INFORMATION structure.
        /// </summary>
        ClfsLogStreamIdentifierInformation,

        /// <summary>
        /// Count of system marking references. 
        /// This enumeration constant is supported only in Windows Vista and later versions of Windows.
        /// </summary>
        ClfsLogSystemMarkingInformation,

        /// <summary>
        /// Maps virtual LSNs to physical LSNs; only valid for physical logs. 
        /// This enumeration constant is supported only in Windows Vista and later versions of Windows.
        /// </summary>
        ClfsLogPhysicalLsnInformation
    }
}
