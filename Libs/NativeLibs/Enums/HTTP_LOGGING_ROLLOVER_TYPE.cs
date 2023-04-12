namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_LOGGING_ROLLOVER_TYPE enumeration defines the log file rollover types.
    /// This enumeration is used in the HTTP_LOGGING_INFO structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_logging_rollover_type
    /// </summary>
    public enum HTTP_LOGGING_ROLLOVER_TYPE
    {
        /// <summary>
        /// The log files are rolled over when they reach a specified size.
        /// </summary>
        HttpLoggingRolloverSize,

        /// <summary>
        /// The log files are rolled over every day.
        /// </summary>
        HttpLoggingRolloverDaily,

        /// <summary>
        /// The log files are rolled over every week.
        /// </summary>
        HttpLoggingRolloverWeekly,

        /// <summary>
        /// The log files are rolled over every month.
        /// </summary>
        HttpLoggingRolloverMonthly,

        /// <summary>
        /// The log files are rolled over every hour, based on GMT.
        /// </summary>
        HttpLoggingRolloverHourly
    }
}