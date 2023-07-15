using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// flags that describe the add-page request. 
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_kbugcheck_add_pages
    /// </summary>
    [Flags]
    public enum KB_ADD_PAGES_FLAGS
    {
        /// <summary>
        /// Indicates that the Address member contains a virtual address.
        /// </summary>
        KB_ADD_PAGES_FLAG_VIRTUAL_ADDRESS,

        /// <summary>
        /// Indicates that the Address member contains a physical address.
        /// </summary>
        KB_ADD_PAGES_FLAG_PHYSICAL_ADDRESS,

        /// <summary>
        /// Indicates that the callback routine requests that it be called again so that it can add more pages.
        /// </summary>
        KB_ADD_PAGES_FLAG_ADDITIONAL_RANGES_EXIST
    }
}
