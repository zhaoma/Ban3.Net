/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            排序
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

namespace Ban3.Infrastructures.Common.Requests.DataTables
{
    /// <summary>
    /// 排序
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// 排序方式asc/desc
        /// </summary>
        public string Dir { get; set; }
    }
}
