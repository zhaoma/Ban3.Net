using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The FILE_OBJECT structure is used by the system to represent a file object.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_file_object
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_OBJECT
    {
        /// <summary>
        /// A read-only member used by the system to indicate that the object is a file object. 
        /// If the object is a file object, the value of this member is 5.
        /// </summary>
        public uint Type;

        /// <summary>
        /// A read-only member that specifies the size, in bytes, of the file object. 
        /// This size does not include the file object extension, if one is present.
        /// </summary>
        public uint Size;

        /// <summary>
        /// A pointer to the device object on which the file is opened.
        /// </summary>
        public IntPtr DeviceObject;

        /// <summary>
        /// A pointer to the volume parameter block associated with the file object.
        /// Note that if the Vpb member is non-NULL, the file resides on a mounted volume.
        /// </summary>
        public IntPtr Vpb;

        /// <summary>
        /// A pointer to whatever optional state a driver maintains about the file object; 
        /// otherwise, NULL. For file system drivers, 
        /// this member must point to a FSRTL_ADVANCED_FCB_HEADER header structure that is contained within a file-system-specific structure; 
        /// otherwise system instability can result. Usually, 
        /// this header structure is embedded in a file control block (FCB). 
        /// However, on some file systems that support multiple data streams, such as NTFS, this header structure is a stream control block (SCB).
        /// 
        /// In a WDM device stack, only the functional device object (FDO) can use the two context pointers. 
        /// File system drivers share this member across multiple opens to the same data stream.
        /// </summary>
        public IntPtr FsContext;

        /// <summary>
        /// A pointer to whatever additional state a driver maintains about the file object; otherwise, NULL.
        /// This member is opaque for drivers in the file system stack because the underlying file system utilizes this member.
        /// </summary>
        public IntPtr FsContext2;

        /// <summary>
        /// A pointer to the file object's read-only section object. 
        /// This member is set only by file systems and used for Cache Manager interaction.
        /// </summary>
        public IntPtr SectionObjectPointer;

        /// <summary>
        /// An opaque member, set only by file systems, 
        /// that points to handle-specific information and that is used for Cache Manager interaction.
        /// </summary>
        public IntPtr PrivateCacheMap;

        /// <summary>
        /// A read-only member that is used, in certain synchronous cases, to indicate the final status of the file object's I/O request.
        /// </summary>
        public NTSTATUS FinalStatus;

        /// <summary>
        /// A pointer to a FILE_OBJECT structure used to indicate that the current file object has been opened relative to an already open file object.
        /// </summary>
        public IntPtr RelatedFileObject;

        /// <summary>
        /// A read-only member. If FALSE, a lock operation (NtLockFile) has never been performed on the file object.
        /// </summary>
        public byte LockOperation;

        /// <summary>
        /// A read-only member. If TRUE, a delete operation for the file associated with the file object exists. 
        /// If FALSE, there currently is no pending delete operation for the file object.
        /// </summary>
        public byte DeletePending;

        /// <summary>
        /// A read-only member. If TRUE, the file associated with the file object has been opened for read access. If FALSE, the file has been opened without read access. 
        /// This information is used when checking and/or setting the share access of the file.
        /// </summary>
        public byte ReadAccess;

        /// <summary>
        /// A read-only member. If TRUE, the file associated with the file object has been opened for write access. If FALSE, the file has been opened without write access. 
        /// This information is used when checking and/or setting the share access of the file.
        /// </summary>
        public byte WriteAccess;

        /// <summary>
        /// A read-only member. 
        /// If TRUE, the file associated with the file object has been opened for delete access. 
        /// If FALSE, the file has been opened without delete access. 
        /// This information is used when checking and/or setting the share access of the file.
        /// </summary>
        public byte DeleteAccess;

        /// <summary>
        /// A read-only member. 
        /// If TRUE, the file associated with the file object has been opened for read sharing access. 
        /// If FALSE, the file has been opened without read sharing access. 
        /// This information is used when checking and/or setting the share access of the file.
        /// </summary>
        public byte SharedRead;

        /// <summary>
        /// A read-only member. 
        /// If TRUE, the file associated with the file object has been opened for write sharing access. 
        /// If FALSE, the file has been opened without write sharing access. 
        /// This information is used when checking and/or setting the share access of the file.
        /// </summary>
        public byte SharedWrite;

        /// <summary>
        /// A read-only member. 
        /// If TRUE, the file associated with the file object has been opened for delete sharing access. 
        /// If FALSE, the file has been opened without delete sharing access. 
        /// This information is used when checking and/or setting the share access of the file.
        /// </summary>
        public byte SharedDelete;

        /// <summary>
        /// A read-only member used by the system to hold one or more (a bitwise inclusive OR combination) of the following private flag values.
        /// </summary>
        public FILE_OBJECT_FLAGS Flags;

        /// <summary>
        /// A UNICODE_STRING structure whose Buffer member points to a read-only Unicode string that holds the name of the file opened on the volume.
        /// </summary>
        public UNICODE_STRING FileName;

        /// <summary>
        /// A read-only member that specifies the file offset, in bytes, associated with the file object.
        /// </summary>
        public LARGE_INTEGER CurrentByteOffset;

        /// <summary>
        /// A read-only member used by the system to count the number of outstanding waiters on a file object opened for synchronous access.
        /// </summary>
        public IntPtr Waiters;

        /// <summary>
        /// A read-only member used by the system to indicate whether a file object opened for synchronous access is currently busy.
        /// </summary>
        public IntPtr Busy;

        /// <summary>
        /// An opaque pointer to the last lock applied to the file object.
        /// </summary>
        public IntPtr LastLock;

        /// <summary>
        /// An opaque member used by the system to hold a file object event lock. 
        /// The event lock is used to control synchronous access to the file object. 
        /// Applicable only to file objects that are opened for synchronous access.
        /// </summary>
        public IntPtr Lock;

        /// <summary>
        /// An opaque member used by the system to hold an event object for the file object. 
        /// The event object is used to signal the completion of an I/O request on the file object if no user event was supplied or a synchronous API was called.
        /// </summary>
        public IntPtr Event;

        /// <summary>
        /// An opaque pointer to completion port information (port pointer and key) associated with the file object, if any.
        /// </summary>
        public IntPtr CompletionContext;

        /// <summary>
        /// An opaque pointer to a KSPIN_LOCK structure that serves as the spin lock used to synchronize access to the file object's IRP list.
        /// </summary>
        public uint IrpListLock;

        /// <summary>
        /// An opaque pointer to the head of the IRP list associated with the file object.
        /// </summary>
        public LIST_ENTRY IrpList;

        /// <summary>
        /// An opaque pointer to the file object's file object extension (FOBX) structure. 
        /// The FOBX structure contains various opaque contexts used internally as well as the per-file object contexts available through FsRtlXxx routines.
        /// </summary>
        public IntPtr FileObjectExtension;

    }
}
