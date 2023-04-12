using Ban3.Infrastructures.NativeLibs.Enums;
using Ban3.Infrastructures.NativeLibs.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// evntrace.h This header is used by multiple technologies.
    ///     Event Tracing
    ///     Kernel-Mode Driver Reference
    /// This file is Event Tracing parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/
    /// </summary>
    public static partial class ADVAPI32
    {
        /*
         
        1105 (0x0451),  (0x), CloseTrace, 0x00020410, None
        1111 (0x0457),  (0x), ControlTraceA, 0x00025380, None
        1112 (0x0458),  (0x), ControlTraceW, 0x00023300, None
        1148 (0x047c),  (0x), CreateTraceInstanceId, ntdll.EtwCreateTraceInstanceId, None
        1265 (0x04f1),  (0x), EnableTrace, 0x00024380, None
        1266 (0x04f2),  (0x), EnableTraceEx2, 0x000232c0, None
        1267 (0x04f3),  (0x), EnableTraceEx, 0x000243b0, None
        1280 (0x0500),  (0x), EnumerateTraceGuids, 0x00022260, None
        1281 (0x0501),  (0x), EnumerateTraceGuidsEx, 0x00020590, None
        1304 (0x0518),  (0x), FlushTraceA, 0x00043990, None
        1305 (0x0519),  (0x), FlushTraceW, 0x000439c0, None
        1371 (0x055b),  (0x), GetTraceEnableFlags, ntdll.EtwGetTraceEnableFlags, None
        1372 (0x055c),  (0x), GetTraceEnableLevel, ntdll.EtwGetTraceEnableLevel, None
        1373 (0x055d),  (0x), GetTraceLoggerHandle, ntdll.EtwGetTraceLoggerHandle, None
        1544 (0x0608),  (0x), OpenTraceA, 0x00043b30, None
        1545 (0x0609),  (0x), OpenTraceW, 0x00020460, None
        1582 (0x062e),  (0x), ProcessTrace, 0x000202f0, None
        1583 (0x062f),  (0x), QueryAllTracesA, 0x00025390, None
        1584 (0x0630),  (0x), QueryAllTracesW, 0x000356e0, None
        1598 (0x063e),  (0x), QueryTraceA, 0x000439f0, None
        1599 (0x063f),  (0x), QueryTraceProcessingHandle, 0x00035790, None
        1600 (0x0640),  (0x), QueryTraceW, 0x000121a0, None
        1696 (0x06a0),  (0x), RegisterTraceGuidsA, ntdll.EtwRegisterTraceGuidsA, None
        1697 (0x06a1),  (0x), RegisterTraceGuidsW, ntdll.EtwRegisterTraceGuidsW, None
        1705 (0x06a9),  (0x), RemoveTraceCallback, sechost.RemoveTraceCallback, None
        1761 (0x06e1),  (0x), SetTraceCallback, sechost.SetTraceCallback, None
        1768 (0x06e8),  (0x), StartTraceA, 0x000253a0, None
        1769 (0x06e9),  (0x), StartTraceW, 0x00023900, None
        1770 (0x06ea),  (0x), StopTraceA, 0x00043a20, None
        1771 (0x06eb),  (0x), StopTraceW, 0x00035c20, None
        1810 (0x0712),  (0x), TraceEvent, ntdll.EtwLogTraceEvent, None
        1811 (0x0713),  (0x), TraceEventInstance, ntdll.EtwTraceEventInstance, None
        1812 (0x0714),  (0x), TraceMessage, ntdll.EtwTraceMessage, None
        1813 (0x0715),  (0x), TraceMessageVa, ntdll.EtwTraceMessageVa, None
        1814 (0x0716),  (0x), TraceQueryInformation, api-ms-win-eventing-controller-l1-1-0.TraceQueryInformation, None
        1815 (0x0717),  (0x), TraceSetInformation, 0x00035c40, None
        1825 (0x0721),  (0x), UnregisterTraceGuids, ntdll.EtwUnregisterTraceGuids, None
        1826 (0x0722),  (0x), UpdateTraceA, 0x00043a50, None
        1827 (0x0723),  (0x), UpdateTraceW, 0x00043a80, None
         
         */

        /// <summary>
        /// The CloseTrace function closes a trace processing session that was created with OpenTrace.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-closetrace
        /// </summary>
        /// <param name="TraceHandle">
        /// Handle to the trace processing session to close.
        /// The OpenTrace function returns this handle.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint CloseTrace(
            IntPtr TraceHandle
        );

        /// <summary>
        /// The ControlTrace function flushes, queries, updates, or stops the specified event tracing session.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-controltracea
        /// </summary>
        /// <param name="TraceHandle"></param>
        /// <param name="InstanceName"></param>
        /// <param name="Properties"></param>
        /// <param name="ControlCode"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint ControlTraceA(
            IntPtr TraceHandle,
            [In][MarshalAs(UnmanagedType.LPStr)] string InstanceName,
            IntPtr Properties,
            uint ControlCode
        );

        /// almost same as ControlTraceA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint ControlTraceW(
            IntPtr TraceHandle,
            [In][MarshalAs(UnmanagedType.LPWStr)] string InstanceName,
            IntPtr Properties,
            uint ControlCode
        );

        /// <summary>
        /// A RegisterTraceGuids-based ("Classic") event provider may use the CreateTraceInstanceId function to create a unique transaction identifier and map it to a registration handle.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-createtraceinstanceid
        /// </summary>
        /// <param name="RegHandle"></param>
        /// <param name="InstInfo"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint CreateTraceInstanceId(
            IntPtr RegHandle,
            ref IntPtr InstInfo
        );

        /// <summary>
        /// A trace session controller calls EnableTrace to configure how an ETW event provider logs events to a trace session.
        /// This function is obsolete. The EnableTraceEx2 function supersedes this function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-enabletrace
        /// </summary>
        /// <param name="Enable"></param>
        /// <param name="EnableFlag"></param>
        /// <param name="EnableLevel"></param>
        /// <param name="ControlGuid"></param>
        /// <param name="TraceHandle"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint EnableTrace(
            uint Enable,
            uint EnableFlag,
            uint EnableLevel,
            ref GUID ControlGuid,
            System.IntPtr TraceHandle
        );

        /// <summary>
        /// A trace session controller calls EnableTraceEx to configure how an ETW event provider logs events to a trace session.
        /// This function is obsolete. The EnableTraceEx2 function supersedes this function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-enabletraceex
        /// </summary>
        /// <param name="ProviderId"></param>
        /// <param name="SourceId"></param>
        /// <param name="TraceHandle"></param>
        /// <param name="IsEnabled"></param>
        /// <param name="Level"></param>
        /// <param name="MatchAnyKeyword"></param>
        /// <param name="MatchAllKeyword"></param>
        /// <param name="EnableProperty"></param>
        /// <param name="EnableFilterDesc"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint EnableTraceEx(
            ref GUID ProviderId,
            ref GUID SourceId,
            IntPtr TraceHandle,
            uint IsEnabled,
            byte Level,
            ulong MatchAnyKeyword,
            ulong MatchAllKeyword,
            uint EnableProperty,
            IntPtr EnableFilterDesc
        );

        /// <summary>
        /// A trace session controller calls EnableTraceEx2 to configure how an ETW event provider logs events to a trace session.
        /// This function supersedes the EnableTrace and EnableTraceEx functions.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-enabletraceex2
        /// </summary>
        /// <param name="TraceHandle"></param>
        /// <param name="ProviderId"></param>
        /// <param name="ControlCode"></param>
        /// <param name="Level"></param>
        /// <param name="MatchAnyKeyword"></param>
        /// <param name="MatchAllKeyword"></param>
        /// <param name="Timeout"></param>
        /// <param name="EnableParameters"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint EnableTraceEx2(
            System.IntPtr TraceHandle,
            ref GUID ProviderId,
            uint ControlCode,
            byte Level,
            ulong MatchAnyKeyword,
            ulong MatchAllKeyword,
            uint Timeout,
            System.IntPtr EnableParameters
        );

        /// <summary>
        /// The EnumerateTraceGuids function retrieves information about event trace providers that are currently running on the computer.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-enumeratetraceguids
        /// </summary>
        /// <param name="GuidPropertiesArray"></param>
        /// <param name="PropertyArrayCount"></param>
        /// <param name="GuidCount"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint EnumerateTraceGuids(
            IntPtr GuidPropertiesArray,
            uint PropertyArrayCount,
            ref uint GuidCount
        );

        /// <summary>
        /// Retrieves information about event trace providers that are currently running on the computer.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-enumeratetraceguidsex
        /// </summary>
        /// <param name="TraceQueryInfoClass"></param>
        /// <param name="InBuffer"></param>
        /// <param name="InBufferSize"></param>
        /// <param name="OutBuffer"></param>
        /// <param name="OutBufferSize"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint EnumerateTraceGuidsEx(
            IntPtr TraceQueryInfoClass,
            IntPtr InBuffer,
            uint InBufferSize,
            ref IntPtr OutBuffer,
            ref uint OutBufferSize,
            ref uint ReturnLength
        );

        /// <summary>
        /// The FlushTrace function causes an event tracing session to immediately deliver buffered events for the specified session. By default, an event tracing session will deliver events when an the buffer is full, the session's FlushTimer expires, or the session is closed.
        /// This function is obsolete. The ControlTrace function supersedes this function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-flushtracea
        /// </summary>
        /// <param name="TraceHandle"></param>
        /// <param name="InstanceName"></param>
        /// <param name="Properties"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint FlushTraceA(
            IntPtr TraceHandle,
            [MarshalAs(UnmanagedType.LPStr)] string InstanceName,
            ref IntPtr Properties
        );

        /// almost same as FlushTraceA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint FlushTraceW(
            IntPtr TraceHandle,
            [MarshalAs(UnmanagedType.LPWStr)] string InstanceName,
            ref IntPtr Properties
        );

        /// <summary>
        /// A RegisterTraceGuids-based ("Classic") event provider uses the GetTraceEnableFlags function to retrieve the enable flags specified by the trace controller to indicate which category of events to trace.
        /// Providers call this function from their ControlCallback function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-gettraceenableflags
        /// </summary>
        /// <param name="TraceHandle"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetTraceEnableFlags(
            IntPtr TraceHandle
        );

        /// <summary>
        /// A RegisterTraceGuids-based ("Classic") event provider uses the GetTraceEnableLevel function to retrieve the enable level specified by the trace controller to indicate which level of events to trace.
        /// Providers call this function from their ControlCallback function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-gettraceenablelevel
        /// </summary>
        /// <param name="TraceHandle"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetTraceEnableLevel(
            IntPtr TraceHandle
        );

        /// <summary>
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-gettraceloggerhandle
        /// </summary>
        /// <param name="Buffer"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetTraceLoggerHandle(
            IntPtr Buffer
        );


        /// <summary>
        /// The OpenTrace function opens an ETW trace processing handle for consuming events from an ETW real-time trace session or an ETW log file.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-opentracea
        /// </summary>
        /// <param name="Logfile"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr OpenTraceA(
            IntPtr Logfile
        );

        /// almost same as OpenTraceA
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr OpenTraceW(
            IntPtr Logfile
        );

        /// <summary>
        /// The ProcessTrace function delivers events from one or more ETW trace processing sessions to the consumer.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-processtrace
        /// </summary>
        /// <param name="HandleArray"></param>
        /// <param name="HandleCount"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint ProcessTrace(
            IntPtr HandleArray,
            uint HandleCount,
            ref FILETIME StartTime,
            ref FILETIME EndTime
        );

        /// <summary>
        /// The QueryAllTraces function retrieves the properties and statistics for all event tracing sessions for which the caller has permissions to query.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-queryalltracesa
        /// </summary>
        /// <param name="PropertyArray"></param>
        /// <param name="PropertyArrayCount"></param>
        /// <param name="LoggerCount"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint QueryAllTracesA(
            ref IntPtr PropertyArray,
            uint PropertyArrayCount,
            ref uint LoggerCount
        );

        /// almost same as QueryAllTracesA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint QueryAllTracesW(
            ref IntPtr PropertyArray,
            uint PropertyArrayCount,
            ref uint LoggerCount
        );

        /// <summary>
        /// The QueryTrace function retrieves the property settings and session statistics for the specified event tracing session.
        /// This function is obsolete. The ControlTrace function supersedes this function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-querytracea
        /// </summary>
        /// <param name="TraceHandle"></param>
        /// <param name="InstanceName"></param>
        /// <param name="Properties"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint QueryTraceA(
            IntPtr TraceHandle,
            [MarshalAs(UnmanagedType.LPStr)] string InstanceName,
            IntPtr Properties
        );

        /// almost same as QueryTraceA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint QueryTraceW(
            IntPtr TraceHandle,
            [MarshalAs(UnmanagedType.LPWStr)] string InstanceName,
            IntPtr Properties
        );

        /// <summary>
        /// Retrieves information about an ETW trace processing session opened by OpenTrace.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-querytraceprocessinghandle
        /// </summary>
        /// <param name="ProcessingHandle"></param>
        /// <param name="InformationClass"></param>
        /// <param name="InBuffer"></param>
        /// <param name="InBufferSize"></param>
        /// <param name="OutBuffer"></param>
        /// <param name="OutBufferSize"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint QueryTraceProcessingHandle(
            System.IntPtr ProcessingHandle,
            ETW_PROCESS_HANDLE_INFO_TYPE InformationClass,
            System.IntPtr InBuffer,
            uint InBufferSize,
            System.IntPtr OutBuffer,
            uint OutBufferSize,
            ref uint ReturnLength
        );

        /// <summary>
        /// The RegisterTraceGuids function registers a Classic (Windows 2000-style) ETW event trace provider and the event trace classes that it uses to generate events.
        /// This function also specifies the callback function the system uses to enable and disable tracing from the provider.
        /// This function is obsolete. New code should use EventRegister to register a Windows Vista-style (Crimson) ETW event trace provider.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-registertraceguidsa
        /// </summary>
        /// <param name="RequestAddress"></param>
        /// <param name="RequestContext"></param>
        /// <param name="ControlGuid"></param>
        /// <param name="GuidCount"></param>
        /// <param name="TraceGuidReg"></param>
        /// <param name="MofImagePath"></param>
        /// <param name="MofResourceName"></param>
        /// <param name="RegistrationHandle"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegisterTraceGuidsA(
            System.IntPtr RequestAddress,
            System.IntPtr RequestContext,
            ref GUID ControlGuid,
            uint GuidCount,
            System.IntPtr TraceGuidReg,
            [MarshalAs(UnmanagedType.LPStr)] string MofImagePath,
            [MarshalAs(UnmanagedType.LPStr)] string MofResourceName,
            System.IntPtr RegistrationHandle
        );

        /// almost same as RegisterTraceGuidsA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegisterTraceGuidsW(
            System.IntPtr RequestAddress,
            System.IntPtr RequestContext,
            ref GUID ControlGuid,
            uint GuidCount,
            System.IntPtr TraceGuidReg,
            [MarshalAs(UnmanagedType.LPWStr)] string MofImagePath,
            [MarshalAs(UnmanagedType.LPWStr)] string MofResourceName,
            System.IntPtr RegistrationHandle
        );

        /// <summary>
        /// Do not use this function. It may be unavailable in subsequent versions.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-removetracecallback
        /// </summary>
        /// <param name="pGuid"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RemoveTraceCallback(
            ref GUID pGuid
        );

        /// <summary>
        /// Do not use this function; it may be unavailable in subsequent versions. Instead, filter for the event trace class in your EventRecordCallback function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-settracecallback
        /// </summary>
        /// <param name="pGuid"></param>
        /// <param name="EventCallback"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint SetTraceCallback(
            ref GUID pGuid,
            IntPtr EventCallback
        );

        /// <summary>
        /// The StartTrace function registers and starts an event tracing session.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-starttracea
        /// </summary>
        /// <param name="TraceHandle"></param>
        /// <param name="InstanceName"></param>
        /// <param name="Properties"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint StartTraceA(
            ref IntPtr TraceHandle,
            [In][MarshalAs(UnmanagedType.LPStr)] string InstanceName,
            IntPtr Properties
        );

        /// almost same as StartTraceA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint StartTraceW(
            ref IntPtr TraceHandle,
            [In][MarshalAs(UnmanagedType.LPWStr)] string InstanceName,
            IntPtr Properties
        );

        /// <summary>
        /// The StopTrace function stops the specified event tracing session.
        /// This function is obsolete. The ControlTrace function supersedes this function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-stoptracea
        /// </summary>
        /// <param name="TraceHandle"></param>
        /// <param name="InstanceName"></param>
        /// <param name="Properties"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint StopTraceA(
            IntPtr TraceHandle,
            [In][MarshalAs(UnmanagedType.LPStr)] string InstanceName,
            IntPtr Properties
        );

        /// almost same as StopTraceA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint StopTraceW(
            IntPtr TraceHandle,
            [In][MarshalAs(UnmanagedType.LPWStr)] string InstanceName,
            IntPtr Properties
        );

        /// <summary>
        /// A RegisterTraceGuids-based ("Classic") event provider uses the TraceEvent function to send a structured event to an event tracing session.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-traceevent
        /// </summary>
        /// <param name="TraceHandle"></param>
        /// <param name="EventTrace"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint TraceEvent(
            IntPtr TraceHandle,
            IntPtr EventTrace
        );

        /// <summary>
        /// A RegisterTraceGuids-based ("Classic") event provider uses the TraceEventInstance function to send a structured event to an event tracing session with an instance identifier.
        /// The event uses an instance identifier to associate the event with a transaction. This function may also be used to trace hierarchical relationships between related events.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-traceeventinstance
        /// </summary>
        /// <param name="TraceHandle"></param>
        /// <param name="EventTrace"></param>
        /// <param name="InstInfo"></param>
        /// <param name="ParentInstInfo"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint TraceEventInstance(
            IntPtr TraceHandle,
            IntPtr EventTrace,
            IntPtr InstInfo,
            IntPtr ParentInstInfo
        );

        /// <summary>
        /// A RegisterTraceGuids-based ("Classic") event provider uses the TraceMessageVa function to send a message-based (TMF-based WPP) event to an event tracing session using va_list parameters.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-tracemessageva
        /// </summary>
        /// <param name="LoggerHandle"></param>
        /// <param name="MessageFlags"></param>
        /// <param name="MessageGuid"></param>
        /// <param name="MessageNumber"></param>
        /// <param name="MessageArgList"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint TraceMessageVa(
            System.IntPtr LoggerHandle,
            uint MessageFlags,
            ref GUID MessageGuid,
            ushort MessageNumber,
            System.IntPtr MessageArgList
        );

        /// <summary>
        /// The TraceQueryInformation function provides information about an event tracing session.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-tracequeryinformation
        /// </summary>
        /// <param name="SessionHandle"></param>
        /// <param name="InformationClass"></param>
        /// <param name="TraceInformation"></param>
        /// <param name="InformationLength"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint TraceQueryInformation(
            IntPtr SessionHandle,
            TRACE_QUERY_INFO_CLASS InformationClass,
            ref IntPtr TraceInformation,
            uint InformationLength,
            ref uint ReturnLength
        );

        /// <summary>
        /// The TraceSetInformation function configures event tracing session settings.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-tracesetinformation
        /// </summary>
        /// <param name="SessionHandle"></param>
        /// <param name="InformationClass"></param>
        /// <param name="TraceInformation"></param>
        /// <param name="InformationLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint TraceQueryInformation(
            IntPtr SessionHandle,
            TRACE_QUERY_INFO_CLASS InformationClass,
            IntPtr TraceInformation,
            uint InformationLength
        );

        /// <summary>
        /// The UnregisterTraceGuids function unregisters a Classic (Windows 2000-style) ETW event trace provider that was registered using RegisterTraceGuids.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-unregistertraceguids
        /// </summary>
        /// <param name="RegistrationHandle"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint UnregisterTraceGuids(
            IntPtr RegistrationHandle
        );

        /// <summary>
        /// The UpdateTrace function updates the property setting of the specified event tracing session.
        /// This function is obsolete. The ControlTrace function supersedes this function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/nf-evntrace-updatetracea
        /// </summary>
        /// <param name="TraceHandle"></param>
        /// <param name="InstanceName"></param>
        /// <param name="Properties"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint UpdateTraceA(
            IntPtr TraceHandle,
            [In][MarshalAs(UnmanagedType.LPStr)] string InstanceName,
            IntPtr Properties
        );

        /// almost same as StopTraceA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint UpdateTraceW(
            IntPtr TraceHandle,
            [In][MarshalAs(UnmanagedType.LPWStr)] string InstanceName,
            IntPtr Properties
        );
    }
}
