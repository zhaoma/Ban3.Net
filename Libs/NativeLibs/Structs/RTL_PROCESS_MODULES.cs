using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RTL_PROCESS_MODULES
    {
        public uint NumberOfModules;
        public RTL_PROCESS_MODULE_INFORMATION Modules;
    }
}
