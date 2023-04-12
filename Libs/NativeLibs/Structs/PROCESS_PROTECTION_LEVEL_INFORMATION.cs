using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Specifies whether Protected Process Light (PPL) is enabled.
    /// https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-process_protection_level_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_PROTECTION_LEVEL_INFORMATION
    {
        public uint ProtectionLevel;
    }
}