using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PO_FX_PERF_STATE_CHANGE
    {    
        /// ULONG->unsigned int
        public uint Set;

        /// Anonymous_b3be0327_0379_468f_8607_fa5df5d6346a
        public PO_FX_PERF_STATE_CHANGE_UNION Union1;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct PO_FX_PERF_STATE_CHANGE_UNION
    {

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint StateIndex;

        /// ULONGLONG->unsigned __int64
        [FieldOffset(0)]
        public ulong StateValue;
    }
}
