/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            表策略属性
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;

namespace Ban3.Infrastructures.Common.Attributes
{
    /// <summary>
    /// 表策略属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TableStrategyAttribute
            : Attribute
    {
        /// ctor
        public TableStrategyAttribute() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tableName"></param>
        /// <param name="cacheAll"></param>
        /// <param name="needRecord"></param>
        public TableStrategyAttribute(
                string name,
                string tableName,
                bool cacheAll = false,
                bool needRecord = false)
        {
            Name = name;
            TableName = tableName;
            CacheAll = cacheAll;
            NeedRecord = needRecord;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public bool NeedRecord { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool CacheAll { get; set; }
    }
}