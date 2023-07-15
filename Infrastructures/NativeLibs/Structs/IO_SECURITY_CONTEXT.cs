using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IO_SECURITY_CONTEXT structure represents the security context of an IRP_MJ_CREATE request.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_io_security_context
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IO_SECURITY_CONTEXT
    {
        /// <summary>
        /// Reserved for system use.
        /// </summary>
        public IntPtr SecurityQos;

        /// <summary>
        /// Reserved for use by file systems and file system filter drivers. 
        /// This member is a pointer to an ACCESS_STATE structure 
        /// that contains the object's subject context, granted access types, and remaining desired access types.
        /// </summary>
        public IntPtr AccessState;

        /// <summary>
        /// An ACCESS_MASK value that expresses the access rights that are requested in the IRP_MJ_CREATE request.
        /// </summary>
        public ACCESS_MASK DesiredAccess;

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        public uint FullCreateOptions;

    }
}
