/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            搜索内容
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

namespace Ban3.Infrastructures.Common.Requests.DataTables
{
    /// <summary>
    /// 搜索内容
    /// </summary>
    public class ColumnsSearch
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 使用正则
        /// </summary>
        public bool Regex { get; set; }
    }
}
