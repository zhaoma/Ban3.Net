/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            Datatables请求
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Requests.DataTables
{
    /// <summary>
    /// 请求Datatables数据源
    /// </summary>
    public class DataTables
    {
        /// <summary>
        /// 请求序号，结果需与其一直
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        /// 从哪里开始显示，下标0开始
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// 显示记录数
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 各列详情
        /// </summary>
        public List<ColumnsDetail> Columns { get; set; }

        /// <summary>
        /// 搜索
        /// </summary>
        public ColumnsSearch Search { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>
        public List<Order> OrderBy { get; set; }
    }
}