using Newtonsoft.Json;
using System;

namespace Ban3.Infrastructures.DataPersist.Attributes;

/// <summary>
/// 字段属性
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class FieldIsAttribute
    : Attribute
{
    /// <summary>
    /// 主键
    /// </summary>
    [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
    public bool Key { get; set; }

    /// <summary>
    /// 自增/自动生成字段
    /// </summary>
    [JsonProperty("increment", NullValueHandling = NullValueHandling.Ignore)]
    public bool Increment { get; set; }

    /// <summary>
    /// 插入所需
    /// </summary>
    [JsonProperty("notForInsert", NullValueHandling = NullValueHandling.Ignore)]
    public bool NotForInsert { get; set; }

    /// <summary>
    /// 更新所需
    /// </summary>
    [JsonProperty("notForUpdate", NullValueHandling = NullValueHandling.Ignore)]
    public bool NotForUpdate { get; set; }

    /// <summary>
    /// 外键信息
    /// </summary>
    [JsonProperty("foreignKey", NullValueHandling = NullValueHandling.Ignore)]
    public Entities.ForeignKey? ForeignKey { get; set; }

    /// <summary>
    /// 显示主题
    /// </summary>
    [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
    public bool Subject { get; set; }

    /// <summary>
    /// 字段支持检索
    /// </summary>
    [JsonProperty("supportSearch", NullValueHandling = NullValueHandling.Ignore)]
    public bool SupportSearch { get; set; }

    /// <summary>
    /// 列表显示列序
    /// </summary>
    [JsonProperty("colIndex", NullValueHandling = NullValueHandling.Ignore)]
    public int ColIndex { get; set; }

    /// <summary>
    /// 转字符格式
    /// </summary>
    [JsonProperty("formatPattern", NullValueHandling = NullValueHandling.Ignore)]
    public string FormatPattern { get; set; } = string.Empty;

}