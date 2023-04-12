namespace Ban3.Protocols.Rfc2445.Enums
{
    /// <summary>
    /// 状态枚举
    /// </summary>
    public enum Statuses
    {
        /// <summary>
        /// 完成
        /// </summary>
        COMPLETED,

        /// <summary>
        /// 取消
        /// </summary>
        CANCELED,

        /// <summary>
        /// 不确定/接受
        /// </summary>
        TENTATIVE,

        /// <summary>
        /// 待办
        /// </summary>
        NEEDS_ACTION,

        /// <summary>
        /// 丢弃
        /// </summary>
        DRAFT,

        /// <summary>
        /// 委派
        /// </summary>
        DELEGATED
    }
}