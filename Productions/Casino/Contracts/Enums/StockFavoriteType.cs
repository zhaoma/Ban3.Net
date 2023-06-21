/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            收藏模式
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.ComponentModel;

namespace Ban3.Productions.Casino.Contracts.Enums
{
    /// <summary>
    /// 收藏模式
    /// </summary>
    public enum StockFavoriteType
    {
        /// <summary>
        /// 持仓
        /// </summary>
        [Description("持仓")]
        Position = 1,

        /// <summary>
        /// 关注/收藏
        /// </summary>
        [Description("关注")]
        Focus = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("备选")]
        Pool =3,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("不理")]
        Ignore = 4,

        /// <summary>
        /// 黑名单
        /// </summary>
        [Description("黑名单")]
        BlackList = 5
    }
}
