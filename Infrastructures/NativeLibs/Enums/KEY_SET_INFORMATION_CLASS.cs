using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The KEY_SET_INFORMATION_CLASS enumeration type represents the type of information to set for a registry key.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_key_set_information_class
    /// A RegistryCallback routine can receive a pointer to a KEY_SET_INFORMATION_CLASS structure as an input parameter.
    /// </summary>
    public enum KEY_SET_INFORMATION_CLASS
    {
        /// <summary>
        /// Indicates that a KEY_WRITE_TIME_INFORMATION structure is supplied.
        /// </summary>
        KeyWriteTimeInformation,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        KeyWow64FlagsInformation,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        KeyControlFlagsInformation,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        KeySetVirtualizationInformation,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        KeySetDebugInformation,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        KeySetHandleTagsInformation,
        
        /// <summary>
        /// Reserved for system use.
        /// </summary>
        KeySetLayerInformation,

        /// <summary>
        /// This member constant is always the maximum value in the enumeration.
        /// </summary>
        MaxKeySetInfoClass
    }
}
