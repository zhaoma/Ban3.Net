using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The TRACE_INFORMATION_CLASS enumeration type is used to indicate types of information associated with a WMI event tracing session.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_trace_information_class
    /// </summary>
    public enum TRACE_INFORMATION_CLASS
    {
        TraceIdClass,
        TraceHandleClass,
        TraceEnableFlagsClass,
        TraceEnableLevelClass,
        GlobalLoggerHandleClass,
        EventLoggerHandleClass,
        AllLoggerHandlesClass,
        TraceHandleByNameClass,
        LoggerEventsLostClass,
        TraceSessionSettingsClass,
        LoggerEventsLoggedClass,
        DiskIoNotifyRoutinesClass,
        TraceInformationClassReserved1,
        FltIoNotifyRoutinesClass,
        TraceInformationClassReserved2,
        WdfNotifyRoutinesClass,
        MaxTraceInformationClass
    }
}
