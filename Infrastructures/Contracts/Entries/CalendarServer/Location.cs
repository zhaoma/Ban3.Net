using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 地址
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/location
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/physicaladdress
/// </summary>
public class Location
{
    /// <summary>
    /// 显示名称
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "displayName")]
    public string DisplayName { get; set; }

    /// <summary>
    /// 地址
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "address")]
    public string Address { get; set; }

    /// <summary>
    /// 城市
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "city")]
    public string City { get; set; }

    /// <summary>
    /// 国家和地区
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "countryOrRegion")]
    public string CountryOrRegion { get; set; }

    /// <summary>
    /// 邮政编码
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "postalCode")]
    public string PostalCode { get; set; }

    /// <summary>
    /// 国家
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state")]
    public string State { get; set; }

    /// <summary>
    /// 街道
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "street")]
    public string Street { get; set; }

    /// <summary>
    /// 可选的电子邮件
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "locationEmailAddress")]
    public string LocationEmailAddress { get; set; }

    /// <summary>
    /// 经度
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "longitude")]
    public double? Longitude { get; set; }

    /// <summary>
    /// 维度
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "latitude")]
    public double? Latitude { get; set; }
}
