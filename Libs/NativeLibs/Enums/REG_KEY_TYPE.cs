using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Specifies the system-defined type for the value entry in the registry key
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_key_value_basic_information
    /// </summary>
    public enum REG_KEY_TYPE:uint
    {
        /// <summary>
        /// Binary data in any form 
        /// </summary>
        REG_BINARY,

        /// <summary>
        /// A 4-byte numerical value 
        /// </summary>
        REG_DWORD,

        /// <summary>
        /// A 4-byte numerical value whose least significant byte is at the lowest address 
        /// </summary>
        REG_DWORD_LITTLE_ENDIAN,

        /// <summary>
        /// A 4-byte numerical value whose least significant byte is at the highest address 
        /// </summary>
        REG_DWORD_BIG_ENDIAN,

        /// <summary>
        /// A null-terminated Unicode string, 
        /// containing unexpanded references to environment variables, such as "%PATH%" 
        /// </summary>
        REG_EXPAND_SZ,

        /// <summary>
        /// A Unicode string naming a symbolic link. 
        /// This type is irrelevant to device and intermediate drivers 
        /// </summary>
        REG_LINK,

        /// <summary>
        /// An array of null-terminated strings, terminated by another zero 
        /// </summary>
        REG_MULTI_SZ,

        /// <summary>
        /// Data with no particular type 
        /// </summary>
        REG_NONE,

        /// <summary>
        /// A null-terminated Unicode string 
        /// </summary>
        REG_SZ,

        /// <summary>
        /// A device driver's list of hardware resources, 
        /// used by the driver or one of the physical devices it controls, 
        /// in the \ResourceMap tree 
        /// </summary>
        REG_RESOURCE_LIST,

        /// <summary>
        /// A device driver's list of possible hardware resources it or one of the physical devices it controls can use, 
        /// from which the system writes a subset into the \ResourceMap tree 
        /// </summary>
        REG_RESOURCE_REQUIREMENTS_LIST,

        /// <summary>
        /// A list of hardware resources that a physical device is using, 
        /// detected and written into the \HardwareDescription tree by the system 
        /// </summary>
        REG_FULL_RESOURCE_DESCRIPTOR
    }

}
