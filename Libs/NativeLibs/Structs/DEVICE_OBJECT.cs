using System;
using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The DEVICE_OBJECT structure is used by the operating system to represent a device object. 
    /// A device object represents a logical, virtual, or physical device for which a driver handles I/O requests.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_device_object
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEVICE_OBJECT
    {
        /// <summary>
        /// Used by the operating system to indicate that an object is a device object. 
        /// For device objects, the value of this member is 3. 
        /// This is a read-only member.
        /// </summary>
        public readonly ushort Type;

        /// <summary>
        /// Specifies the size, in bytes, of the device object. 
        /// This size includes the driver-specified device extension pointed to by the DeviceExtension member, 
        /// but does not include the opaque device object extension pointed to by the DeviceObjectExtension member. 
        /// Size is a read-only member.
        /// </summary>
        public readonly ushort Size;

        /// <summary>
        /// Used by the I/O manager to track the number of open handles for the device that are associated with the device object. 
        /// This allows the I/O manager to avoid unloading a driver when there are outstanding handles for the driver's device(s). 
        /// This is a read-only member.
        /// </summary>
        public int ReferenceCount;

        /// <summary>
        /// A pointer to the driver object (DRIVER_OBJECT), that represents the loaded image of the driver that was input to the DriverEntry and AddDevice routines. 
        /// This member is set by the I/O manager upon a successful call to IoCreateDevice or IoCreateDeviceSecure.
        /// This is a read-only member.
        /// </summary>
        public IntPtr DriverObject;

        /// <summary>
        /// A pointer to the next device object, if any, that was created by the same driver. 
        /// The I/O manager updates this list at each successful call to IoCreateDevice or IoCreateDeviceSecure.
        /// A non- Plug and Play(PnP) driver that is being unloaded must traverse("walk") the list of its device objects and delete them.
        /// A PnP driver does not have to walk this list of device objects.Instead, PnP drivers perform their cleanup during the device removal PnP operation (IRP_MN_REMOVE_DEVICE).
        /// A driver that recreates its device objects dynamically also uses this member.
        /// This is a read/write member.
        /// </summary>
        public IntPtr NextDevice;

        /// <summary>
        /// A pointer to the attached device object. 
        /// If there is no attached device object, this member is NULL.
        /// The device object that is pointed to by the AttachedDevice member typically is the device object of a filter driver, 
        /// which intercepts I/O requests originally targeted to the device represent by the device object. 
        /// For more information, see the IoAttachDevice and IoAttachDeviceByPointer topics.
        /// This is an opaque member.
        /// </summary>
        public IntPtr AttachedDevice;

        /// <summary>
        /// A pointer to the current IRP if the driver has a StartIo routine whose entry point was set in the driver object and if the driver is currently processing IRP(s). 
        /// Otherwise, this member is NULL. For more information, see the IoStartPacket and IoStartNextPacket topics. 
        /// This is a read-only member.
        /// </summary>
        public IntPtr CurrentIrp;

        /// <summary>
        /// A pointer to a timer object. This allows the I/O manager to call a driver-supplied timer routine every second. 
        /// For more information, see IoInitializeTimer. 
        /// This is a read/write member.
        /// </summary>
        public IntPtr Timer;

        /// <summary>
        /// Device drivers perform a bitwise OR operation with this member in their newly created device objects by 
        /// using one or more of the DEVICE_OBJECT_FLAGS
        /// </summary>
        public DEVICE_OBJECT_FLAGS Flags;

        /// <summary>
        /// Specifies one or more system-defined constants, combined with a bitwise OR operation, 
        /// that provide additional information about the driver's device.
        /// </summary>
        public DEVICE_OBJECT_CHARACTERISTICS Characteristics;

        /// <summary>
        /// A pointer to the volume parameter block (VPB) that is associated with the device object. 
        /// For file system drivers, the VPB can provide a connection to any unnamed logical device object that represents an instance of a mounted volume. 
        /// This is an opaque member.
        /// </summary>
        public IntPtr Vpb;

        /// <summary>
        /// A pointer to the device extension. 
        /// The structure and contents of the device extension are driver-defined. 
        /// The size is driver-determined, specified in the driver's call to IoCreateDevice or IoCreateDeviceSecure. 
        /// For more information about device extensions, see Device Extensions. 
        /// This is a read-only member. However, the object that the member points to can be modified by the driver.
        /// </summary>
        public IntPtr DeviceExtension;

        /// <summary>
        /// Set by IoCreateDevice and IoCreateDeviceSecure by using the value that is specified for that routine's DeviceType parameter. 
        /// For more information, see the Specifying Device Types topic.
        /// </summary>
        public uint DeviceType;

        /// <summary>
        /// Specifies the minimum number of stack locations in IRPs to be sent to this driver. 
        /// IoCreateDevice and IoCreateDeviceSecure set this member to 1 in newly created device objects; lowest-level drivers can therefore ignore this member. 
        /// The I/O manager automatically sets the StackSize member in a higher-level driver's device object to the appropriate value if the driver calls IoAttachDevice or IoAttachDeviceToDeviceStack. 
        /// Only a higher-level driver that chains itself over another driver with IoGetDeviceObjectPointer must explicitly set the value of StackSize in its own device object(s) to 1 + the StackSize value of the next-lower driver's device object.
        /// </summary>
        public byte StackSize;

        /// <summary>
        /// Used internally by the I/O manager to queue the device object when it is required. 
        /// This is an opaque member.
        /// </summary>
        public DEVICE_OBJECT_QUEUE Queue;

        /// <summary>
        /// Specifies the device's address alignment requirement for data transfers. 
        /// The value must be one of the FILE_XXX_ALIGNMENT values that are defined in Wdm.h. 
        /// For more information, see the Initializing a Device Object, GetDmaAlignment, and ZwQueryInformationFile topics.
        /// </summary>
        public uint AlignmentRequirement;

        /// <summary>
        /// The device queue object for the device object. 
        /// The device queue object contains any IRPs that are waiting to be processed by the driver that is associated with the device object. 
        /// For more information, see the Driver-Managed IRP Queues topic. 
        /// This is an opaque member.
        /// </summary>
        public IntPtr DeviceQueue;

        /// <summary>
        /// The deferred procedure call (DPC) object for the device object.
        /// For more information, see the Introduction to DPC Objects topic. 
        /// This is an opaque member.
        /// </summary>
        public IntPtr Dpc;

        /// <summary>
        /// Reserved for future use. This is an opaque member.
        /// </summary>
        public uint ActiveThreadCount;

        /// <summary>
        /// Specifies a security descriptor (SECURITY_DESCRIPTOR) for the device object when the device object is created. 
        /// If this member is NULL, the device object receives default security settings.
        /// This is a read-only member, although the member can be modified through the ZwSetSecurityObjectfunction.
        /// </summary>
        public IntPtr SecurityDescriptor;

        /// <summary>
        /// A synchronization event object that is allocated by the I/O manager. 
        /// The I/O manager obtains his event object before it dispatches a mount or mount-verify request to a file-system driver. 
        /// This is an opaque member.
        /// </summary>
        public IntPtr DeviceLock;

        /// <summary>
        /// If the device object does not represent a volume, this member is set to zero. 
        /// If the device object represents a volume, this member specifies the volume's sector size, in bytes. 
        /// The I/O manager uses this member to make sure that all read operations, write operations, 
        /// and set file position operations that are issued are aligned correctly when intermediate buffering is disabled. 
        /// A default system bytes-per-sector value is used when the device object is created, however, file system drivers; 
        /// and more rarely, legacy and minifilter drivers, can update this value that is based on the geometry of the underlying volume hardware when a mount occurs. 
        /// Other drivers should not modify this member.
        /// </summary>
        public ushort SectorSize;

        /// <summary>
        /// Reserved for system use. This is an opaque member.
        /// </summary>
        public ushort Spare1;

        /// <summary>
        /// A pointer to a device object extension that is used by the I/O manager and PnP manager to store information about the state of the device. 
        /// This is an opaque member.
        /// </summary>
        public IntPtr DeviceObjectExtension;

        /// <summary>
        /// Reserved for system use. This is an opaque member.
        /// </summary>
        public IntPtr Reserved;
    }

    /// <summary>
    /// Used internally by the I/O manager to queue the device object when it is required.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct DEVICE_OBJECT_QUEUE
    {
        /// <summary>
        /// A LIST_ENTRY structure that contains forward and backward pointers for a doubly linked list.
        /// </summary>
        [FieldOffsetAttribute(0)]
        public LIST_ENTRY ListEntry;

        /// <summary>
        /// Device context information used by I/O manager.
        /// </summary>
        [FieldOffsetAttribute(0)]
        public IntPtr Wcb;
    }
}
