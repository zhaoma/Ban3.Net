namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 循环周期枚举
    /// </summary>
    public enum Frequencies
    {
        /// <summary>
        /// 每分钟
        /// </summary>
        Minutely,

        /// <summary>
        /// 每小时
        /// </summary>
        Hourly,

        /// <summary>
        /// 每天
        /// </summary>
        Daily,

        /// <summary>
        /// 每周
        /// </summary>
        Weekly,

        /// <summary>
        /// 每月(两种)
        /// absolute和relative
        /// </summary>
        Monthly,

        /// <summary>
        /// 每年(两种)
        /// absolute和relative
        /// </summary>
        Yearly
    }
}