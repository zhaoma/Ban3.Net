using System;
using System.Runtime.Serialization;

namespace Ban3.Sites.ViaNetease.Entries;

/// <summary>
/// 股票分组定义
/// </summary>
[Serializable, DataContract]
public class StockGroup
{
    /// <summary>
    /// 标识
    /// </summary>
    [DataMember]
    public int Identity { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [DataMember]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 网易详情数据前缀
    /// </summary>
    [DataMember]
    public string NeteasePrefix { get; set; } = string.Empty;

    /// <summary>
    /// 股票数
    /// </summary>
    [DataMember]
    public int StockCount { get; set; }

    /// <summary>
    /// 编码前缀
    /// sh/sz
    /// </summary>
    [DataMember]
    public string CodePrefix { get; set; } = string.Empty;
}