using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines an extended item Performance Monitoring Unit (PMC) counter.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_pmc_counters
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_EXTENDED_ITEM_PMC_COUNTERS
    {
        /// <summary>
        /// The counter.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.U8)]
        public ulong[] Counter;
    }
}