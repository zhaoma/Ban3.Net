using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_KEY_HANDLE_CLOSE_INFORMATION
    {
        public IntPtr Object;
        public IntPtr CallContext;
        public IntPtr ObjectContext;
        public IntPtr Reserved;
    }
}
