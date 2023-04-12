/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            实体基类
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using Ban3.Infrastructures.Common.Interfaces;

namespace Ban3.Infrastructures.Common.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class BasisEntity : IEntity, IEquatable<IEntity>
    {
        /// ctor
        public BasisEntity() { }

        /// <summary>
        /// 主键值
        /// </summary>
        /// <returns></returns>
        public virtual string KeyValue() => "";

        /// <summary>
        /// 等条件
        /// </summary>
        /// <returns></returns>
        public virtual string EqualCondition() => "";

        /// <summary>
        /// 数据表创建语句
        /// </summary>
        /// <returns></returns>
        public virtual string CreateSql() => "";

        /// <summary>
        /// 等判断
        /// </summary>
        /// <param name="compareTarget"></param>
        /// <returns></returns>
        public virtual bool Equals(IEntity? compareTarget)
        {
            return EqualCondition() == compareTarget?.EqualCondition();
        }
    }
}