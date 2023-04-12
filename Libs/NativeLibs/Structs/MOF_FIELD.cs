using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// You may use the MOF_FIELD structures to append event data to the EVENT_TRACE_HEADER or EVENT_INSTANCE_HEADER structures.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-mof_field
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MOF_FIELD
    {
        /// <summary>
        /// Pointer to a event data item.
        /// </summary>
        public ulong DataPtr;

        /// <summary>
        /// Length of the item pointed to by DataPtr, in bytes.
        /// </summary>
        public uint Length;

        /// <summary>
        /// Reserved.
        /// </summary>
        public uint DataType;
    }
}