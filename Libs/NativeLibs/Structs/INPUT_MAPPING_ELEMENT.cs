using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains the input mapping IDs for a device.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_input_mapping_element
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct INPUT_MAPPING_ELEMENT
    {
        /// <summary>
        /// The input mapping ID for a device.
        /// </summary>
        public uint InputMappingId;

    }
}
