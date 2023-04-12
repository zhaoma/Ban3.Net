/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            访问者令牌
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

namespace Ban3.Infrastructures.Common.Models
{
    /// <summary>
    /// 访问者令牌
    /// </summary>
    public class GuestToken
    {
        /// ctor
        public GuestToken() { }

        /// <summary>
        /// 标识
        /// </summary>
        public int Identity { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 访问令牌
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        public long ExpireTime { get; set; }
    }
}