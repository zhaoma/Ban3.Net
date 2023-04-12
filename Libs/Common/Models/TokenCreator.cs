/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            令牌请求者
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

namespace Ban3.Infrastructures.Common.Models
{
    /// <summary>
    /// 令牌请求者
    /// </summary>
    public class TokenCreator
    {
        /// ctor
        public TokenCreator() { }

        /// <summary>
        /// 标识
        /// </summary>
        public int Identity { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; } = string.Empty;
    }
}