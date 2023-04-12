/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            表字段关联属性
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Common.Attributes
{
    /// <summary>
    /// 字段属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class FieldAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public override object TypeId => base.TypeId;

        /// <summary>
        /// 字段支持检索
        /// </summary>
        public bool SupportSearch { get; set; }

        /// <summary>
        /// 列表显示列序
        /// </summary>
        public int ColIndex { get; set; }

        /// <summary>
        /// 转字符格式
        /// </summary>
        public string FormatPattern { get; set; }

        /// <summary>
        /// 属性数据类型
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FieldAttribute() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supportSearch"></param>
        /// <param name="colIndex"></param>
        /// <param name="formatPattern"></param>
        public FieldAttribute(
                bool supportSearch,
                int colIndex,
                string formatPattern)
        {
            SupportSearch = supportSearch;
            ColIndex = colIndex;
            FormatPattern = formatPattern;
        }
    }
}