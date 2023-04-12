/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            明确字符串主键实体基类
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Dapper.Contrib.Extensions;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Common.Entities
{
    /// <summary>
    /// 明确字符串主键实体基类
    /// </summary>
    public class ExplicitStringKeyEntity
        : BasisEntity
    {
        /// ctor
        public ExplicitStringKeyEntity()
        {
        }

        /// <summary>
        /// 明确字符串主键
        /// </summary>
        [ExplicitKey]
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        /// inherit 
        public override string KeyValue() => Id;

        /// inherit 
        public override string EqualCondition() => Id;

        /// inherit 
        public override string CreateSql() => "";
    }
}

