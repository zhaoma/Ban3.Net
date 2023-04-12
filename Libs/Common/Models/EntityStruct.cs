/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            实体结构
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Linq;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Common.Attributes;

namespace Ban3.Infrastructures.Common.Models
{
    /// <summary>
    /// 实体结构
    /// </summary>
    public class EntityStruct
    {
        /// ctor
        public EntityStruct() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public EntityStruct(Type type)
        {
            Identity = type.Name;
            TableStrategy = type.TableStrategy();
            Fields = type.Columns();
        }

        /// <summary>
        /// 实体标识
        /// </summary>
        public string Identity { get; set; } = string.Empty;

        /// <summary>
        /// 数据表策略（名称/表名/记录修改/缓存全部/使用Redis/推送Rabbit
        /// </summary>
        public TableStrategyAttribute TableStrategy { get; set; }

        /// <summary>
        /// 所有字段
        /// </summary>
        public Dictionary<string, FieldAttribute> Fields { get; set; }

        /// <summary>
        /// 列表显示字段
        /// </summary>
        public List<KeyValuePair<string, FieldAttribute>> ShowFields()
        {
            return Fields.Where(o => o.Value.ColIndex > 0)
                         .OrderBy(o => o.Value.ColIndex)
                         .ToList();
        }
    }
}