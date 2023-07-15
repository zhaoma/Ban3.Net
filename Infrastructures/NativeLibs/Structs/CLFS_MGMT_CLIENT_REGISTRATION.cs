using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CLFS_MGMT_CLIENT_REGISTRATION structure is given to CLFS management by clients who manage their own logs.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_clfs_mgmt_client_registration
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLFS_MGMT_CLIENT_REGISTRATION
    {
        /// <summary>
        /// The version of the CLFS_MGMT_CLIENT_REGISTRATION structure. 
        /// Set this to CLFS_MGMT_CLIENT_REGISTRATION_VERSION.
        /// </summary>
        public uint Version;

        /// <summary>
        /// A pointer to the log's ClfsAdvanceTailCallback function.
        /// </summary>
        public System.IntPtr AdvanceTailCallback;

        /// <summary>
        /// A pointer to user-defined data that will be supplied to the ClfsAdvanceTailCallback function when the function is invoked.
        /// </summary>
        public System.IntPtr AdvanceTailCallbackData;

        /// <summary>
        /// A pointer to the log's ClfsLogGrowthCompleteCallback function.
        /// </summary>
        public System.IntPtr LogGrowthCompleteCallback;

        /// <summary>
        /// A pointer to user-defined data that will be supplied to the ClfsLogGrowthCompleteCallback function when the function is invoked.
        /// </summary>
        public System.IntPtr LogGrowthCompleteCallbackData;

        /// <summary>
        /// A pointer to the log's ClfsLogUnpinnedCallback function.
        /// </summary>
        public System.IntPtr LogUnpinnedCallback;

        /// <summary>
        /// A pointer to user-defined data that will be supplied to the ClfsLogUnpinnedCallback function when the function is invoked.
        /// </summary>
        public System.IntPtr LogUnpinnedCallbackData;

    }
}
