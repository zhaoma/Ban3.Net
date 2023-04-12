using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about a pointer device. An array of these structures is returned from the GetPointerDevices function.
    /// A single structure is returned from a call to the GetPointerDevice function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-pointer_device_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINTER_DEVICE_INFO
    {

        /// DWORD->unsigned int
        public uint displayOrientation;

        /// HANDLE->void*
        public System.IntPtr device;

        /// PVOID->void*
        public System.IntPtr pointerDeviceType;

        /// HMONITOR->HMONITOR__*
        public System.IntPtr monitor;

        /// ULONG->unsigned int
        public uint startingCursorId;

        /// USHORT->unsigned short
        public ushort maxActiveContacts;

        /// WCHAR[]
        public string productString;
    }
}