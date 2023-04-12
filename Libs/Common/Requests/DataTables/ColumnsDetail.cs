/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            列设置
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

namespace Ban3.Infrastructures.Common.Requests.DataTables
{
    /// <summary>
    /// 列设置（暂时没用）
    /// </summary>
    public class ColumnsDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Data { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public bool Searchable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Orderable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ColumnsSearch? Search { get; set; }
    }
}
