/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022-09-01 08:00
 * function:            文章信息
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

namespace Ban3.Platforms.WeChatClient.Entries.Content
{
    /// <summary>
    /// 
    /// </summary>
    public class ArticleInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string PicUrl { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; } = string.Empty;
    }
}