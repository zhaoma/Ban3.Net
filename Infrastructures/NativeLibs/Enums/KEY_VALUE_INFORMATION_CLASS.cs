using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The KEY_VALUE_INFORMATION_CLASS enumeration type specifies the type of information to supply about the value of a registry key.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_key_value_information_class
    /// </summary>
    public enum KEY_VALUE_INFORMATION_CLASS
    {
        /// <summary>
        /// The information is stored as a KEY_VALUE_BASIC_INFORMATION structure.
        /// </summary>
        KeyValueBasicInformation,

        /// <summary>
        /// The information is stored as a KEY_VALUE_FULL_INFORMATION structure.
        /// </summary>
        KeyValueFullInformation,

        /// <summary>
        /// The information is stored as a KEY_VALUE_PARTIAL_INFORMATION structure.
        /// </summary>
        KeyValuePartialInformation,

        /// <summary>
        /// The information is stored as a KEY_VALUE_FULL_INFORMATION structure 
        /// that is aligned to a 64-bit (that is, 8-byte) boundary in memory. 
        /// If the caller-supplied buffer does not start on a 64-bit boundary, 
        /// ZwQueryValueKey returns STATUS_DATATYPE_MISALIGNMENT.
        /// </summary>
        KeyValueFullInformationAlign64,

        /// <summary>
        /// The information is stored as a KEY_VALUE_PARTIAL_INFORMATION_ALIGN64 structure 
        /// that is aligned to a 64-bit (that is, 8-byte) boundary in memory. 
        /// If the caller-supplied buffer does not start on a 64-bit boundary, 
        /// ZwQueryValueKey returns STATUS_DATATYPE_MISALIGNMENT.
        /// </summary>
        KeyValuePartialInformationAlign64,

        /// 
        KeyValueLayerInformation,

        /// 
        MaxKeyValueInfoClass

    }
}
