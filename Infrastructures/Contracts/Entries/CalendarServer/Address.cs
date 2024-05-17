using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 地址信息
/// </summary>
public class Address
{
    /// <summary>
    /// 地址的类型
    /// </summary>
    [DataMember]
    public string Type { get; set; }

    /// <summary>
    /// 地址的非结构化
    /// </summary>
    [DataMember]
    public string FormattedValue { get; set; }

    /// <summary>
    /// 类型翻译
    /// </summary>
    [DataMember]
    public string FormattedType { get; set; }

    /// <summary>
    /// 城市
    /// </summary>
    [DataMember]
    public string City { get; set; }

    /// <summary>
    /// 国家代码
    /// </summary>
    [DataMember]
    public string CountryCode { get; set; }

    /// <summary>
    /// 国家与地区
    /// </summary>
    [DataMember]
    public string CountryOrRegion { get; set; }

    /// <summary>
    /// 国家
    /// </summary>
    [DataMember]
    public string Country { get; set; }

    /// <summary>
    ///区域地址
    /// </summary>
    [DataMember]
    public string Region { get; set; }

    /// <summary>
    /// 邮编
    /// </summary>
    [DataMember]
    public string PostalCode { get; set; }

    /// <summary>
    /// 邮政信箱
    /// </summary>
    [DataMember]
    public string Pobox { get; set; }

    /// <summary>
    /// 州县
    /// </summary>
    [DataMember]
    public string State { get; set; }

    /// <summary>
    /// 街道地址
    /// </summary>
    [DataMember]
    public string Street { get; set; }

    /// <summary>
    /// 街道地址
    /// </summary>
    [DataMember]
    public string StreetAddress { get; set; }

    /// <summary>
    /// 扩展地址
    /// </summary>
    [DataMember]
    public string ExtendedAddress { get; set; }
}
