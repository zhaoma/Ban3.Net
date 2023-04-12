/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            自增整数主键实体基类
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.ComponentModel;

using Dapper.Contrib.Extensions;

namespace Ban3.Infrastructures.Common.Entities
{
    /// <summary>
    /// 自增整数主键实体基类
    /// </summary>
    public class IncrementIntKeyEntity
            : BasisEntity
    {
        /// ctor
        public IncrementIntKeyEntity() { }

        /// <summary>
        /// 自增整数主键
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// inherit 
        public override string KeyValue() => Id + "";

        /// inherit 
        public override string EqualCondition() => Id + "";
    }
}