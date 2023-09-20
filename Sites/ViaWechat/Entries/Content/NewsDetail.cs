using System.ComponentModel;

namespace Ban3.Platforms.WeChatClient.Entries.Content
{
    /// <summary>
    /// 图文素材
    /// </summary>
    public class NewsDetail
        :MediaItem

    {
        /// <summary>
        /// rank
        /// </summary>
        public int rank { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [DisplayName("标题")]
        public string title { get; set; }

        /// <summary>
        /// 封面素材
        /// </summary>
        [DisplayName("封面素材")]
        public string thumb_media_id { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [DisplayName("作者")]
        public string author { get; set; }

        /// <summary>
        /// 导语
        /// </summary>
        [DisplayName("导语")]
        public string digest { get; set; }

        /// <summary>
        /// 显示封面
        /// </summary>
        [DisplayName("显示封面")]
        public int show_cover_pic { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        [DisplayName("正文")]
        public string content { get; set; }

        /// <summary>
        /// 来源地址
        /// </summary>
        [DisplayName("来源地址")]
        public string content_source_url { get; set; }
    }
}