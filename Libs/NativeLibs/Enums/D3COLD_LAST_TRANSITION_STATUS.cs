using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The D3COLD_LAST_TRANSITION_STATUS enumeration indicates whether the most recent transition 
    /// to the D3hot device power state was followed by a transition to the D3cold device power state.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_d3cold_last_transition_status
    /// </summary>
    public enum D3COLD_LAST_TRANSITION_STATUS
    {
        /// <summary>
        /// Information is not available from the bus driver or platform firmware 
        /// about whether the most recent transition to D3hot was followed by a transition to D3cold.
        /// </summary>
        LastDStateTransitionStatusUnknown,

        /// <summary>
        /// The most recent transition to the D3hot device power state was not followed by a transition to the D3cold device power state.
        /// </summary>
        LastDStateTransitionD3hot,

        /// <summary>
        /// The most recent transition to the D3hot device power state was followed by a transition to the D3cold device power state.
        /// </summary>
        LastDStateTransitionD3cold
    }
}
