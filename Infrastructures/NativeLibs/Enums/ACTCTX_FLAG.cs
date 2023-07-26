using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Flags that indicate how the values included in this structure are to be used. 
    /// Set any undefined bits in dwFlags to 0. 
    /// If any undefined bits are not set to 0, 
    /// the call to CreateActCtx that creates the activation context fails and returns an invalid parameter error code.
    /// </summary>
    [Flags]
    public enum ACTCTX_FLAG:uint
    {
        UNDEFINED=0,
        PROCESSOR_ARCHITECTURE_VALID = 0x001,
        LANGID_VALID = 0x002,
        ASSEMBLY_DIRECTORY_VALID = 0x004,
        RESOURCE_NAME_VALID =0x008,
        SET_PROCESS_DEFAULT = 0x010,
        APPLICATION_NAME_VALID = 0x020,
        HMODULE_VALID = 0x080
    }
}
