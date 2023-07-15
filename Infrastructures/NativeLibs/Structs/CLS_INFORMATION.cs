using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CLFS_INFORMATION structure holds metadata and state information for a Common Log File System (CLFS) stream 
    /// and/or its underlying physical log.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cls_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLS_INFORMATION
    {
        /// <summary>
        /// The total available space allocated to the log. 
        /// This is calculated as the sum of the sizes of all containers in the log.
        /// </summary>
        public long TotalAvailable;

        /// <summary>
        /// The amount of space available in the log for new records and reservation allocations. 
        /// This space is the total available space minus the undo commitment space 
        /// and space used for storing owner pages in a multiplexed log.
        /// </summary>
        public long CurrentAvailable;

        /// <summary>
        /// The amount of space reserved in the stream (or physical log) for undo operations.
        /// </summary>
        public long TotalReservation;

        /// <summary>
        /// The size, in bytes, of the base log file.
        /// </summary>
        public ulong BaseFileSize;

        /// <summary>
        /// The size, in bytes, of an individual container in the log. 
        /// Note that all containers in the log are the same size.
        /// </summary>
        public ulong ContainerSize;

        /// <summary>
        /// The number of containers in the log.
        /// </summary>
        public uint TotalContainers;

        /// <summary>
        /// The number of containers in the log that are not active.
        /// </summary>
        public uint FreeContainers;

        /// <summary>
        /// The number of streams that share the log.
        /// </summary>
        public uint TotalClients;

        /// <summary>
        /// A set of flags that specify stream (or physical log) attributes. 
        /// See the fFlagsAndAttributes parameter of the ClfsCreateLogFile function.
        /// </summary>
        public uint Attributes;

        /// <summary>
        /// The number of bytes of data (including headers) that are allowed 
        /// to remain pending on the internal flush queue before CLFS automatically schedules a thread 
        /// to write the flush queue to stable storage.
        /// </summary>
        public uint FlushThreshold;

        /// <summary>
        /// The sector size, in bytes, of the underlying disk geometry. 
        /// The sector size is assumed to be a multiple of 512 and consistent across containers.
        /// </summary>
        public uint SectorSize;

        /// <summary>
        /// The LSN of the oldest record in the log for which archiving has not taken place. 
        /// The minimum of this and the base LSN determines the last container 
        /// that can be reused when containers are recycled.
        /// </summary>
        public CLS_LSN MinArchiveTailLsn;

        /// <summary>
        /// The LSN of the oldest record in the stream (or physical log) that is still needed by the stream (or log) clients.
        /// </summary>
        public CLS_LSN BaseLsn;

        /// <summary>
        /// The LSN of the last record that was flushed to stable storage.
        /// </summary>
        public CLS_LSN LastFlushedLsn;

        /// <summary>
        /// The LSN of the youngest record in the stream (or physical log) that is still needed by the stream (or log) clients.
        /// </summary>
        public CLS_LSN LastLsn;

        /// <summary>
        /// The LSN of the last restart record written to the stream (or physical log).
        /// If there are no restart records, this member is equal to CLFS_LSN_INVALID.
        /// </summary>
        public CLS_LSN RestartLsn;

        /// <summary>
        /// A GUID that serves as a unique identifier for the log.
        /// </summary>
        public GUID Identity;

    }
}
