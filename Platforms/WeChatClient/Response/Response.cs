namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
{
    /// <summary>
    /// 响应基类
    /// </summary>
    public class Response
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public string errcode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string errmsg { get; set; }
    }
}