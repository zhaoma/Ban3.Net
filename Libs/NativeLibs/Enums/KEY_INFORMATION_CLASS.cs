using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The KEY_INFORMATION_CLASS enumeration type represents the type of information to supply about a registry key.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_key_information_class
    /// Use the KEY_INFORMATION_CLASS values to specify the type of data to be supplied by the ZwEnumerateKey and ZwQueryKey routines.
    /// </summary>
    public enum KEY_INFORMATION_CLASS
    {
        /// <summary>
        /// A KEY_BASIC_INFORMATION structure is supplied.
        /// </summary>
        KeyBasicInformation,

        /// <summary>
        /// A KEY_NODE_INFORMATION structure is supplied.
        /// </summary>
        KeyNodeInformation,

        /// <summary>
        /// A KEY_FULL_INFORMATION structure is supplied.
        /// </summary>
        KeyFullInformation,

        /// <summary>
        /// A KEY_NAME_INFORMATION structure is supplied.
        /// </summary>
        KeyNameInformation,

        /// <summary>
        /// A KEY_CACHED_INFORMATION structure is supplied.
        /// </summary>
        KeyCachedInformation,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        KeyFlagsInformation,

        /// <summary>
        /// A KEY_VIRTUALIZATION_INFORMATION structure is supplied.
        /// </summary>
        KeyVirtualizationInformation,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        KeyHandleTagsInformation,

        /// 
        KeyTrustInformation,

        /// 
        KeyLayerInformation,

        /// <summary>
        /// The maximum value in this enumeration type.
        /// </summary>
        MaxKeyInfoClass
    }
}
