using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// An SLIST_ENTRY structure describes an entry in a sequenced singly linked list.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_slist_entry
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SLIST_ENTRY
    {
        public System.IntPtr Next;
    }
}
