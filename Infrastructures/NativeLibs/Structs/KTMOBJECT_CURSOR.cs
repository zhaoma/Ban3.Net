using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The KTMOBJECT_CURSOR structure receives enumeration information about KTM objects 
    /// when a component calls ZwEnumerateTransactionObject.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ktmobject_cursor
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KTMOBJECT_CURSOR
    {
        /// <summary>
        /// After ZwEnumerateTransactionObject returns, this member contains the GUID of the last object that ZwEnumerateTransactionObject enumerated. 
        /// Before it calls ZwEnumerateTransactionObject the first time, the caller must set this value to zero.
        /// </summary>
        public GUID LastQuery;

        /// <summary>
        /// After ZwEnumerateTransactionObject returns, 
        /// this member contains the number of GUIDs that the ObjectIds array contains.
        /// </summary>
        public uint ObjectIdCount;

        /// <summary>
        /// A caller-allocated array of GUID-typed elements.
        /// After ZwEnumerateTransactionObject returns, this array contains GUIDs that identify enumerated objects.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public GUID[] ObjectIds;
    }
}
