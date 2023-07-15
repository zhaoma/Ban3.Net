using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IO_STACK_LOCATION structure defines an I/O stack location,
    /// which is an entry in the I/O stack that is associated with each IRP. 
    /// Each I/O stack location in an IRP has some common members and some request-type-specific members.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_io_stack_location
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IO_STACK_LOCATION
    {
    }
}
