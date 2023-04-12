using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Defines values for the type of extended parameters.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-mem_section_extended_parameter_type
    /// </summary>
    public enum MEM_SECTION_EXTENDED_PARAMETER_TYPE
    {
        MemSectionExtendedParameterInvalidType = 0,
        MemSectionExtendedParameterUserPhysicalFlags,
        MemSectionExtendedParameterNumaNode,
        MemSectionExtendedParameterSigningLevel,
        MemSectionExtendedParameterMax
    }
}
