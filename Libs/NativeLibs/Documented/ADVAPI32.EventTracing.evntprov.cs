using Ban3.Infrastructures.NativeLibs.Enums;
using Ban3.Infrastructures.NativeLibs.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// evntprov.h This header is used by multiple technologies.
    ///     Driver Development Tools Reference
    ///     Event Tracing
    /// This file is Event Tracing parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/
    /// </summary>
    public static partial class ADVAPI32
    {
        /*
         
        1288 (0x0508),  (0x), EventActivityIdControl, ntdll.EtwEventActivityIdControl, None
        1289 (0x0509),  (0x), EventEnabled, ntdll.EtwEventEnabled, None
        1290 (0x050a),  (0x), EventProviderEnabled, ntdll.EtwEventProviderEnabled, None
        1291 (0x050b),  (0x), EventRegister, ntdll.EtwEventRegister, None
        1292 (0x050c),  (0x), EventSetInformation, ntdll.EtwEventSetInformation, None
        1293 (0x050d),  (0x), EventUnregister, ntdll.EtwEventUnregister, None
        1294 (0x050e),  (0x), EventWrite, ntdll.EtwEventWrite, None
        1295 (0x050f),  (0x), EventWriteEndScenario, ntdll.EtwEventWriteEndScenario, None
        1296 (0x0510),  (0x), EventWriteEx, ntdll.EtwEventWriteEx, None
        1297 (0x0511),  (0x), EventWriteStartScenario, ntdll.EtwEventWriteStartScenario, None
        1298 (0x0512),  (0x), EventWriteString, ntdll.EtwEventWriteString, None
        1299 (0x0513),  (0x), EventWriteTransfer, ntdll.EtwEventWriteTransfer, None
         
         */

        /// <summary>
        /// Creates, queries, and sets activity identifiers for use in ETW events.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/nf-evntprov-eventactivityidcontrol
        /// </summary>
        /// <param name="ControlCode"></param>
        /// <param name="ActivityId">
        /// A pointer to a buffer that contains a 128-bit activity ID.
        /// This buffer may be read-from and/or written-to, depending on the value of the ControlCode parameter.
        /// </param>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint EventActivityIdControl(
            EVENT_ACTIVITY_CTRLCODE ControlCode, 
            ref GUID ActivityId
            );

        /// <summary>
        /// Determines whether an event provider should generate a particular event based on the event's EVENT_DESCRIPTOR.
        /// Returns FALSE if ETW can quickly determine that no session is listening for a specified event from the given provider. Otherwise returns TRUE.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/nf-evntprov-eventenabled
        /// </summary>
        /// <param name="RegHandle">
        /// Registration handle of the provider.
        /// The handle comes from EventRegister.
        /// If RegHandle is NULL, EventEnabled will return FALSE.
        /// </param>
        /// <param name="EventDescriptor">
        /// EVENT_DESCRIPTOR that provides information that will be used to determine whether the event is enabled.
        /// This includes the event's Level (severity) and Keyword (categories).
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool EventEnabled(
            System.IntPtr RegHandle, 
            System.IntPtr EventDescriptor
            );

        /// <summary>
        /// Determines whether an event provider should generate a particular event based on the event's Level and Keyword.
        /// Returns FALSE if ETW can quickly determine that no session is listening for a specified event from the given provider. Otherwise returns TRUE.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/nf-evntprov-eventproviderenabled
        /// </summary>
        /// <param name="RegHandle">
        /// Registration handle of the provider. The handle comes from EventRegister.
        /// If RegHandle is NULL, EventProviderEnabled will return FALSE.
        /// </param>
        /// <param name="Level">
        /// An 8-bit number used to describe an event's severity or importance.
        /// See EVENT_DESCRIPTOR for more information about event level values.
        /// </param>
        /// <param name="Keyword">
        /// A 64-bit bitmask used to indicate an event's membership in a set of event categories.
        /// See EVENT_DESCRIPTOR for more information about event keyword values.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool EventProviderEnabled(
            System.IntPtr RegHandle,
            byte Level, 
            ulong Keyword
            );

        /// <summary>
        /// Registers an ETW event provider, creating a handle that can be used to write ETW events.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/nf-evntprov-eventregister
        /// </summary>
        /// <param name="ProviderId">
        /// GUID that uniquely identifies the provider, sometimes called a control GUID.
        /// This must be a stable identifier so that trace controllers can use the GUID to subscribe to events from this provider.
        /// </param>
        /// <param name="EnableCallback">
        /// Optional EnableCallback that ETW will invoke when a trace session enables or disables this provider. Use NULL if no callback is needed.
        /// </param>
        /// <param name="CallbackContext">
        /// Optional context data that ETW will provide when invoking EnableCallback. Use NULL if no callback context is needed.
        /// </param>
        /// <param name="RegHandle">
        /// Receives the event provider registration handle. The handle is used in subsequent calls to provider APIs such as EventWrite, EventProviderEnabled, and EventRegister.
        /// Before your provider unloads or exits, free the provider registration handle by calling EventUnregister. A DLL that unloads without freeing all of the provider handles that it registered may cause the process to crash.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint EventRegister(
            ref GUID ProviderId, 
            IntPtr EnableCallback, 
            IntPtr CallbackContext,
            IntPtr RegHandle
            );

        /// <summary>
        /// Configures an ETW event provider.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/nf-evntprov-eventsetinformation
        /// </summary>
        /// <param name="RegHandle">Event provider registration handle. This is a handle returned by EventRegister.</param>
        /// <param name="InformationClass">EVENT_INFO_CLASS value that specifies the configuration operation to be performed on the event provider.</param>
        /// <param name="EventInformation">
        /// Pointer to a buffer that contains data to be used when configuring the event provider.
        /// The format of the data in this buffer depends on the value specified in the InformationClass parameter.
        /// This value may be NULL if InformationLength is zero.
        /// </param>
        /// <param name="InformationLength">The size (in bytes) of the data in the EventInformation buffer.</param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void EventSetInformation(
            IntPtr RegHandle,
            EVENT_INFO_CLASS InformationClass, 
            IntPtr EventInformation, 
            uint InformationLength
            );

        /// <summary>
        /// Unregisters an ETW event provider.
        /// All event providers registered by a component must be unregistered before the component unloads.
        /// If a DLL registers an event provider and then unloads without unregistering the event provider, the process may crash.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/nf-evntprov-eventunregister
        /// </summary>
        /// <param name="RegHandle">Event provider registration handle returned by EventRegister.</param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void EventUnregister(
            IntPtr RegHandle
            );

        /// <summary>
        /// Writes an ETW event that uses the current thread's activity ID.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/nf-evntprov-eventwrite
        /// </summary>
        /// <param name="RegHandle">
        /// Registration handle of the provider. The handle comes from EventRegister.
        /// The generated event will use the ProviderId associated with the handle.
        /// </param>
        /// <param name="EventDescriptor">
        /// EVENT_DESCRIPTOR with event information (metadata) including ID, Version, Level, Keyword, Channel, Opcode, and Task.
        /// </param>
        /// <param name="UserDataCount">Number of EVENT_DATA_DESCRIPTOR structures in UserData. The maximum number is 128.</param>
        /// <param name="UserData">
        /// An array of UserDataCount EVENT_DATA_DESCRIPTOR structures that describe the data to be included in the event.
        /// UserData may be NULL if UserDataCount is zero.
        /// Each EVENT_DATA_DESCRIPTOR describes one block of memory to be included in the event.
        /// The specified blocks will be concatenated in order with no padding or alignment to form the event content.
        /// If using manifest-based decoding, the event content must match the layout specified in the template associated with the event in the manifest.
        /// </param>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint EventWrite(
            IntPtr RegHandle,
            IntPtr EventDescriptor,
            uint UserDataCount, 
            IntPtr UserData
            );

        [DllImport(Dll, SetLastError = true)]
        public static extern void EventWriteEndScenario();

        /// <summary>
        /// Writes an ETW event with an activity ID, an optional related activity ID, session filters, and special options.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/nf-evntprov-eventwriteex
        /// </summary>
        /// <param name="RegHandle"></param>
        /// <param name="EventDescriptor"></param>
        /// <param name="Filter"></param>
        /// <param name="Flags"></param>
        /// <param name="ActivityId"></param>
        /// <param name="RelatedActivityId"></param>
        /// <param name="UserDataCount"></param>
        /// <param name="UserData"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint EventWriteEx(
            System.IntPtr RegHandle, 
            System.IntPtr EventDescriptor, 
            ulong Filter, 
            uint Flags, 
            ref GUID ActivityId,
            ref GUID RelatedActivityId,
            uint UserDataCount,
            System.IntPtr UserData
            );

        /// <summary>
        /// @ ntdll
        /// </summary>
        [DllImport(Dll, SetLastError = true)]
        public static extern void EventWriteStartScenario();

        /// <summary>
        /// Writes an ETW event that contains a string as its data. This function should not be used.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/nf-evntprov-eventwritestring
        /// </summary>
        /// <param name="RegHandle"></param>
        /// <param name="Level"></param>
        /// <param name="Keyword"></param>
        /// <param name="String"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint EventWriteString(
            System.IntPtr RegHandle, 
            byte Level, 
            ulong Keyword, 
            [In][MarshalAs(UnmanagedType.LPWStr)] string String
            );

        /// <summary>
        /// Writes an ETW event with an activity ID and an optional related activity ID.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/nf-evntprov-eventwritetransfer
        /// </summary>
        /// <param name="RegHandle"></param>
        /// <param name="EventDescriptor"></param>
        /// <param name="ActivityId"></param>
        /// <param name="RelatedActivityId"></param>
        /// <param name="UserDataCount"></param>
        /// <param name="UserData"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint EventWriteTransfer(
            System.IntPtr RegHandle,
            System.IntPtr EventDescriptor,
            ref GUID ActivityId, 
            ref GUID RelatedActivityId,
            uint UserDataCount,
            System.IntPtr UserData
            );


    }
}
