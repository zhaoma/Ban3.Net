//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/3/26 09:34
//  function:	REG_CALLBACK_CONTEXT_CLEANUP_INFORMATION.cs
//  reference:	https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_reg_callback_context_cleanup_information
//  ————————————————————————————————————————————————————————————————————————————
using System;
namespace Ban3.Infrastructures.NativeLibs.Structs
{
	public struct REG_CALLBACK_CONTEXT_CLEANUP_INFORMATION
    {   
        /// PVOID->void*
        public System.IntPtr Object;

        /// PVOID->void*
        public System.IntPtr ObjectContext;

        /// PVOID->void*
        public System.IntPtr Reserved;
    }
}

