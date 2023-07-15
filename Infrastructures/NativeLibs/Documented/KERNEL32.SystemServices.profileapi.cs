using Ban3.Infrastructures.NativeLibs.Structs;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// profileapi.h This header is used by System Services.
    /// https://learn.microsoft.com/en-us/windows/win32/api/profileapi/
    /// </summary>
    public static partial class KERNEL32
    {
        /*
        
        1107 (0x0453),  (0x), QueryPerformanceCounter, 0x000161f0, None
        1108 (0x0454),  (0x), QueryPerformanceFrequency, 0x0001b670, None
        
         */

        /// <summary>
        /// Retrieves the current value of the performance counter,
        /// which is a high resolution (<1us) time stamp that can be used for time-interval measurements.
        /// </summary>
        /// <param name="lpPerformanceCount">
        /// A pointer to a variable that receives the current performance-counter value, in counts.
        /// </param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool QueryPerformanceCounter(
            out LARGE_INTEGER lpPerformanceCount
        );

        /// <summary>
        /// Retrieves the frequency of the performance counter.
        /// The frequency of the performance counter is fixed at system boot and is consistent across all processors.
        /// Therefore, the frequency need only be queried upon application initialization, and the result can be cached.
        /// https://learn.microsoft.com/en-us/windows/win32/api/profileapi/nf-profileapi-queryperformancefrequency
        /// </summary>
        /// <param name="lpFrequency">
        /// A pointer to a variable that receives the current performance-counter frequency,
        /// in counts per second. If the installed hardware doesn't support a high-resolution performance counter,
        /// this parameter can be zero (this will not occur on systems that run Windows XP or later).
        /// </param>
        /// <returns>
        /// If the installed hardware supports a high-resolution performance counter, the return value is nonzero.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool QueryPerformanceFrequency(
            out LARGE_INTEGER lpFrequency
        );
    }
}
