using Ban3.Infrastructures.NativeLibs.Enums;
using Ban3.Infrastructures.NativeLibs.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// evntcons.h This header is used by Event Tracing.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/
    /// </summary>
    public static partial class ADVAPI32
    {
        /// <summary>
        /// Retrieves an individual trait from the ETW provider.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/nf-evntcons-etwgettraitfromprovidertraits
        /// </summary>
        /// <param name="ProviderTraits">The Provider traits.</param>
        /// <param name="TraitType">The ETW_PROVIDER_TRAIT_TYPE.</param>
        /// <param name="Trait">The Provider trait.</param>
        /// <param name="Size">The trait size.</param>
        [DllImport("<Unknown>")]
        public static extern void EtwGetTraitFromProviderTraits(
            IntPtr ProviderTraits,
            ETW_PROVIDER_TRAIT_TYPE TraitType, 
            ref IntPtr Trait, 
            ref ushort Size
            );

        /// <summary>
        /// Retrieves the Event Processor index.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/nf-evntcons-geteventprocessorindex
        /// </summary>
        /// <param name="EventRecord">The event record.</param>
        /// <returns></returns>
        [DllImport("<Unknown>")]
        public static extern uint GetEventProcessorIndex(
            IntPtr EventRecord
            );

        /*
         
        1285 (0x0505),  (0x), EventAccessControl, 0x00034e90, None
        1286 (0x0506),  (0x), EventAccessQuery, 0x00034eb0, None
        1287 (0x0507),  (0x), EventAccessRemove, 0x00034ed0, None
         
         */

        /// <summary>
        /// Adds or modifies the permissions of the specified provider or session.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/nf-evntcons-eventaccesscontrol
        /// </summary>
        /// <param name="Guid">
        /// GUID that uniquely identifies the provider or session whose permissions you want to add or modify.
        /// </param>
        /// <param name="Operation">
        /// Type of operation to perform, for example, add a DACL to the session's GUID or provider's GUID.
        /// </param>
        /// <param name="Sid">
        /// The security identifier (SID) of the user or group to whom you want to grant or deny permissions.
        /// </param>
        /// <param name="Rights">
        ///
        /// </param>
        /// <param name="AllowOrDeny"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint EventAccessControl(
            ref GUID Guid, 
            uint Operation, 
            System.IntPtr Sid,
            EVENT_ACCESS_RIGHTS Rights,
            byte AllowOrDeny
            );

        /// <summary>
        /// Retrieves the permissions for the specified controller or provider.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/nf-evntcons-eventaccessquery
        /// </summary>
        /// <param name="Guid">GUID that uniquely identifies the provider or session.</param>
        /// <param name="Buffer">
        /// Application-allocated buffer that will contain the security descriptor of the controller or provider.
        /// </param>
        /// <param name="BufferSize">
        /// Size of the security descriptor buffer, in bytes.
        /// If the function succeeds, this parameter receives the size of the buffer used.
        /// If the buffer is too small, the function returns ERROR_MORE_DATA and this parameter receives the required buffer size.
        /// If the buffer size is zero on input, no data is returned in the buffer and this parameter receives the required buffer size.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint EventAccessQuery(
            ref GUID Guid, 
            IntPtr Buffer, 
            ref uint BufferSize
            );

        /// <summary>
        /// Removes the permissions defined in the registry for the specified provider or session.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/nf-evntcons-eventaccessremove
        /// </summary>
        /// <param name="Guid">
        /// GUID that uniquely identifies the provider or session whose permissions you want to remove from the registry.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint EventAccessRemove(
            ref GUID Guid
            );
    }
}
