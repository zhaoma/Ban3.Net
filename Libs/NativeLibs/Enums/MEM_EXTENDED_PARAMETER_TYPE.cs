using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Defines values for extended parameters are used for file mapping into an address space.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-mem_extended_parameter_type
    /// </summary>
    public enum MEM_EXTENDED_PARAMETER_TYPE
    {
        MemExtendedParameterInvalidType = 0,
        MemExtendedParameterAddressRequirements = 1,
        MemExtendedParameterNumaNode = 2,
        MemExtendedParameterPartitionHandle = 3,
        MemExtendedParameterUserPhysicalHandle = 4,
        MemExtendedParameterAttributeFlags = 5,
        MemExtendedParameterImageMachine = 6,
        MemExtendedParameterMax
    }
}
