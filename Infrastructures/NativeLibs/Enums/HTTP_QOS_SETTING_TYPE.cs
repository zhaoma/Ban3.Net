namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_QOS_SETTING_TYPE enumeration identifies the type of a QOS setting contained in a HTTP_QOS_SETTING_INFO structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_qos_setting_type
    /// </summary>
    public enum HTTP_QOS_SETTING_TYPE
    {
        /// <summary>
        /// The setting is a bandwidth limit represented by a HTTP_BANDWIDTH_LIMIT_INFO structure.
        /// </summary>
        HttpQosSettingTypeBandwidth,

        /// <summary>
        /// The setting is a connection limit represented by a HTTP_CONNECTION_LIMIT_INFO structure.
        /// </summary>
        HttpQosSettingTypeConnectionLimit,

        /// <summary>
        /// A flow rate represented by HTTP_FLOWRATE_INFO.
        /// </summary>
        HttpQosSettingTypeFlowRate
    }
}