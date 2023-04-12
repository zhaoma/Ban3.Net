using Ban3.Platforms.WeChatClient.Entries.Entries;

namespace Ban3.Platforms.WeChatClient.Entries
{
    /// <summary>
    /// 
    /// </summary>
    public class TemplateMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public TemplateMessageItem first { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TemplateMessageItem keyword1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TemplateMessageItem keyword2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TemplateMessageItem keyword3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TemplateMessageItem remark { get; set; }
    }
}