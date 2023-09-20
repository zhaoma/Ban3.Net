using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.WeChat
{
    /// <summary>
    /// 模板信息（公众号）
    /// </summary>
    public class SendTemplateMessage
    {
        /// <summary>
        /// 收件人
        /// </summary>
        public string touser { get; set; } = string.Empty;

        /// <summary>
        /// 模板主键（微信）
        /// </summary>
        public string template_id { get; set; } = string.Empty;

        /// <summary>
        /// 链接地址
        /// </summary>
        public string url { get; set; } = string.Empty;
    }
}