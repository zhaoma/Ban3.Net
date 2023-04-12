using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The OBJECTS_AND_SID structure contains a security identifier (SID) that identifies a trustee and GUIDs that identify the object types of an object-specific access control entry (ACE).
    /// https://learn.microsoft.com/en-us/windows/win32/api/accctrl/ns-accctrl-objects_and_sid
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct OBJECTS_AND_SID
    {
        /// DWORD->unsigned int
        public uint ObjectsPresent;

        /// GUID->_GUID
        public GUID ObjectTypeGuid;

        /// GUID->_GUID
        public GUID InheritedObjectTypeGuid;

        /// SID*
        public System.IntPtr pSid;
    }
}