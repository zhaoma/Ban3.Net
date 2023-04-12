using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CLFS_CONTAINER_INFORMATION structure holds descriptive information for an individual container in a Common Log File System (CLFS) log.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cls_container_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLS_CONTAINER_INFORMATION
    {
        /// <summary>
        /// A set of flags that specifies attributes of the container. 
        /// See the fFlagsAndAttributes parameter of the ClfsCreateLogFile function.
        /// </summary>
        public uint FileAttributes;

        /// <summary>
        /// The time that the container was created.
        /// </summary>
        public ulong CreationTime;

        /// <summary>
        /// The time that the container was last accessed.
        /// </summary>
        public ulong LastAccessTime;

        /// <summary>
        /// The time of the last write to the container.
        /// </summary>
        public ulong LastWriteTime;

        /// <summary>
        /// The size, in bytes, of the container.
        /// </summary>
        public long ContainerSize;

        /// <summary>
        /// The size, in characters, of the actual file name of the container.
        /// </summary>
        public uint FileNameActualLength;

        /// <summary>
        /// The size of the file name in the FileName buffer.
        /// </summary>
        public uint FileNameLength;

        /// <summary>
        /// An array of wide characters that holds the file name of the container.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst =255)]
        public string FileName;

        /// <summary>
        /// An integer that specifies the state of the container. This member must be one of the CLFS_CONTAINER_STATE.
        /// </summary>
        public CLFS_CONTAINER_STATE State;

        /// <summary>
        /// A 32-bit identifier that remains the same over the life of the log.
        /// </summary>
        public uint PhysicalContainerId;

        /// <summary>
        /// A 32-bit identifier that changes every time the container is recycled.
        /// </summary>
        public uint LogicalContainerId;

    }
}
