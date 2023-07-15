using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    [Flags]
    public enum FILE_OBJECT_FLAGS
    {
        /// <summary>
        /// Deprecated.
        /// </summary>
        FO_FILE_OPEN,

        /// <summary>
        /// The file object is opened for synchronous I/O.
        /// </summary>
        FO_SYNCHRONOUS_IO,

        /// <summary>
        /// Any wait in the I/O manager, as a result of a request made to this file object, is alertable.
        /// </summary>
        FO_ALERTABLE_IO,

        /// <summary>
        /// The file associated with the file object cannot be cached or buffered in a driver's internal buffers.
        /// </summary>
        FO_NO_INTERMEDIATE_BUFFERING,

        /// <summary>
        /// System services, file system drivers, and drivers that write data to the file must transfer the data into the file before any requested write operation is considered complete.
        /// </summary>
        FO_WRITE_THROUGH,

        /// <summary>
        /// The file associated with the file object was opened for sequential I/O operations only.
        /// </summary>
        FO_SEQUENTIAL_ONLY,

        /// <summary>
        /// The file associated with the file object is cacheable. This flag should be set only by a file system driver, and only if the FsContext member points to a valid FSRTL_ADVANCED_FCB_HEADER structure.
        /// </summary>
        FO_CACHE_SUPPORTED,

        /// <summary>
        /// The file object represents a named pipe.
        /// </summary>
        FO_NAMED_PIPE,

        /// <summary>
        /// The file object represents a file stream.
        /// </summary>
        FO_STREAM_FILE,

        /// <summary>
        /// The file object represents a mailslot.
        /// </summary>
        FO_MAILSLOT,

        /// <summary>
        /// Deprecated.
        /// </summary>
        FO_GENERATE_AUDIT_ON_CLOSE,

        /// <summary>
        /// IRPs will not be queued to this file object.
        /// </summary>
        FO_QUEUE_IRP_TO_THREAD,

        /// <summary>
        /// The device targeted by this file object was opened directly.
        /// </summary>
        FO_DIRECT_DEVICE_OPEN,

        /// <summary>
        /// The file associated with the file object has been modified.
        /// </summary>
        FO_FILE_MODIFIED,

        /// <summary>
        /// The file associated with the file object has changed in size.
        /// </summary>
        FO_FILE_SIZE_CHANGED,

        /// <summary>
        /// The file system has completed its cleanup for this file object.
        /// </summary>
        FO_CLEANUP_COMPLETE,

        /// <summary>
        /// The file associated with the file object is a temporary file.
        /// </summary>
        FO_TEMPORARY_FILE,

        /// <summary>
        /// The file associated with the file object will be deleted by the file system upon close.
        /// </summary>
        FO_DELETE_ON_CLOSE,

        /// <summary>
        /// The file name case of the file associated with the file object is respected.
        /// </summary>
        FO_OPENED_CASE_SENSITIVE,

        /// <summary>
        /// A file handle was created for file object.
        /// </summary>
        FO_HANDLE_CREATED,

        /// <summary>
        /// A fast I/O read was performed on this file object.
        /// </summary>
        FO_FILE_FAST_IO_READ,

        /// <summary>
        /// The file associated with the file object was opened for random access.
        /// </summary>
        FO_RANDOM_ACCESS,

        /// <summary>
        /// The create request for this file object was canceled before completing.
        /// </summary>
        FO_FILE_OPEN_CANCELLED,

        /// <summary>
        /// The file object represents a volume open request.
        /// </summary>
        FO_VOLUME_OPEN,

        /// <summary>
        /// The create request for the file associated with the file object originated on a remote machine.
        /// </summary>
        FO_REMOTE_ORIGIN,

        /// <summary>
        /// For a file object associated with a port, determines if the system should skip queuing to the completion port when the IRP is completed synchronously with a non-error status return value.
        /// </summary>
        FO_SKIP_COMPLETION_PORT,

        /// <summary>
        /// Skip setting the event for the file object upon IRP completion.
        /// </summary>
        FO_SKIP_SET_EVENT,

        /// <summary>
        /// Skip setting an event supplied to a system service when the fast I/O path is successful.
        /// </summary>
        FO_SKIP_SET_FAST_IO
    }
}
