namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_LOG_DATA_TYPE enumeration identifies the type of log data.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_log_data_type
    /// </summary>
    public enum HTTP_LOG_DATA_TYPE
    {
        /// <summary>
        /// The HTTP_LOG_FIELDS_DATA structure is used for logging a request.
        /// This structure is passed to an HttpSendHttpResponse or HttpSendResponseEntityBody call.
        /// </summary>
        HttpLogDataTypeFields = 0
    }
}