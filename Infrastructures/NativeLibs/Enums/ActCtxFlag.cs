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
    public enum ActCtxFlag:uint
    {
        Undefined=0,
        ProcessorArchitectureValid=0x001,
        AssemblyDirectoryValid=0x002,
        ResourceNameValid=0x004,
        SetProcessDefault=0x010,
        ApplicationNameValid=0x020,
        HmoduleValid=0x080
    }
}
