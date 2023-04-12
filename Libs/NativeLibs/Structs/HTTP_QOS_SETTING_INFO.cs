using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_QOS_SETTING_INFO structurecontains information about a QOS setting.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_qos_setting_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_QOS_SETTING_INFO
    {

        /// ULONG->unsigned int
        public HTTP_QOS_SETTING_TYPE QosType;

        /// PVOID->void*
        public System.IntPtr QosSetting;
    }

}