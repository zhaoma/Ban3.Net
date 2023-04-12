/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            明确整数主键实体基类
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;

using Dapper.Contrib.Extensions;

namespace Ban3.Infrastructures.Common.Entities
{
    /// <summary>
    /// 明确整数主键实体基类
    /// </summary>
    public class ExplicitIntKeyEntity
            : BasisEntity
    {
        /// ctor
        public ExplicitIntKeyEntity() { }

        /// <summary>
        /// 明确整数主键
        /// </summary>
        [ExplicitKey]
        public int Id { get; set; }

        /// inherit 
        public string LatestUpdate { get; set; }

        /// inherit 
        public override string KeyValue() => Id + "";

        /// inherit 
        public override string EqualCondition() => Id + "";
    }
}