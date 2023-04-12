/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            响应状态码
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.ComponentModel;

namespace Ban3.Infrastructures.Common.Enums
{
    /// <summary>
    /// 响应状态码
    /// </summary>
    public enum ResponseStatusCode
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("OK")]
        Code200,

        /// <summary>
        /// 
        /// </summary>
        [Description("Denied")]
        Code401,

        /// <summary>
        /// 
        /// </summary>
        [Description("Not found")]
        Code404,

        /// <summary>
        /// 
        /// </summary>
        [Description("Error")]
        Code500
    }
}