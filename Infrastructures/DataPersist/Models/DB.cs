using Ban3.Infrastructures.DataPersist.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Infrastructures.DataPersist.Models;

/// <summary>
/// 数据库配置
/// </summary>
public class DB
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    [JsonProperty("database", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Database Database { get; set; }

    /// <summary>
    /// 连接字符串
    /// </summary>
    [JsonProperty("connectionString", NullValueHandling = NullValueHandling.Ignore)]
    public string ConnectionString { get; set; } = string.Empty;
}