namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Specifies the operation that will be performed on a trace processing session.
    /// Used with the QueryTraceProcessingHandle function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ne-evntrace-etw_process_handle_info_type
    /// </summary>
    public enum ETW_PROCESS_HANDLE_INFO_TYPE
    {
        EtwQueryPartitionInformation = 1,
        EtwQueryPartitionInformationV2 = 2,
        EtwQueryLastDroppedTimes = 3,
        EtwQueryLogFileHeader,
        EtwQueryProcessHandleInfoMax
    }
}