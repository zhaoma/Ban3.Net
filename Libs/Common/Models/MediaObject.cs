/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            多媒体
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.ComponentModel;

namespace Ban3.Infrastructures.Common.Models
{
    /// <summary>
    /// 多媒体
    /// </summary>
    public class MediaObject
    {
        /// <summary>
        /// 多媒体封面
        /// </summary>
        [DisplayName("媒体封面")]
        public string MediaCover { get; set; } = string.Empty;

        /// <summary>
        /// 多媒体Webm
        /// </summary>
        [DisplayName("媒体Webm")]
        public string MediaWebm { get; set; } = string.Empty;

        /// <summary>
        /// 多媒体Mp4
        /// </summary>
        [DisplayName("媒体Mp4")]
        public string MediaMp4 { get; set; } = string.Empty;
    }
}