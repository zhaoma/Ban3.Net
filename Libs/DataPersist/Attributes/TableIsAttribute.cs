/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.DataPersist.Attributes;

/// <summary>
/// 表策略属性
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class TableIsAttribute
    : Attribute
{
    /// 
    public TableIsAttribute()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="tableName"></param>
    /// <param name="cacheAll"></param>
    /// <param name="dbName"></param>
    public TableIsAttribute(
        string name,
        string tableName,
        bool cacheAll = false,
        string dbName="Default")
    {
        Name = name;
        TableName = tableName;
        DbName = dbName;
        CacheAll = cacheAll;
    }

    /// <summary>
    /// 表逻辑名
    /// </summary>
    [JsonProperty("name",NullValueHandling=NullValueHandling.Ignore)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 数据表名
    /// </summary>
    [JsonProperty("tableName", NullValueHandling = NullValueHandling.Ignore)]
    public string TableName { get; set; } = string.Empty;

    /// <summary>
    /// 缓存全集合
    /// </summary>
    [JsonProperty("cacheAll", NullValueHandling = NullValueHandling.Ignore)]
    public bool CacheAll { get; set; }

    /// <summary>
    /// 配置节中Db节点名称
    /// </summary>
    [JsonProperty("dbName", NullValueHandling = NullValueHandling.Ignore)]
    public string DbName { get; set; } = string.Empty;

}