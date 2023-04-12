/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            实体定义接口申明
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

namespace Ban3.Infrastructures.Common.Interfaces
{
    /// <summary>
    /// 实体定义接口申明
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// 主键值
        /// </summary>
        /// <returns></returns>
        string KeyValue();

        /// <summary>
        /// 等条件
        /// </summary>
        /// <returns></returns>
        string EqualCondition();

        /// <summary>
        /// 数据表创建语句
        /// </summary>
        /// <returns></returns>
        string CreateSql();
    }
}