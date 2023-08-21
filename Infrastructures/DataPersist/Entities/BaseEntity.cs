using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Enums;
using Ban3.Infrastructures.DataPersist.Models;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;

namespace Ban3.Infrastructures.DataPersist.Entities;

/// <summary>
/// 
/// </summary>
public abstract class BaseEntity
{
    /// 
    protected BaseEntity(){}

    /// <summary>
    /// 读取实体策略信息
    /// </summary>
    /// <returns></returns>
    public virtual EntityStrategy EntityStrategy() => Config.Strategy(GetType());

    /// 
    public virtual DbParameter[]? ParametersForCommand(Func<FieldIsAttribute, bool> func)
    {
        var strategy = EntityStrategy();
        if (!strategy.Viable()) return null;

        var ps = strategy.Fields!.Where(o => func(o.Value));

        return strategy.DB!.Database switch
        {
            Database.Sqlite => ps.Select(o =>
                new SqliteParameter($"@{o.Value.ColumnName}", this.GetProperty(o.Key)?.GetValue(this))).ToArray(),
            Database.MSSQL => ps.Select(o =>
                new SqlParameter($"@{o.Value.ColumnName}", this.GetProperty(o.Key)?.GetValue(this)!)).ToArray(),
            Database.mysql => ps.Select(o =>
                new MySqlParameter($"@{o.Value.ColumnName}", this.GetProperty(o.Key)?.GetValue(this)!)).ToArray(),
            _ => throw new NotImplementedException()
        };
    }

    /// <summary>
    /// 主键参数数组
    /// </summary>
    /// <returns></returns>
    public virtual DbParameter[]? ParametersForKeys()
        => ParametersForCommand(fa => fa.Key);

    /// <summary>
    /// 创建的参数数组
    /// </summary>
    /// <returns></returns>
    public virtual DbParameter[]? ParametersForInsert()
        => ParametersForCommand(fa => !fa.NotForInsert);

    /// <summary>
    /// 更新的参数数组
    /// </summary>
    /// <returns></returns>
    public DbParameter[]? ParametersForUpdate()
        => ParametersForCommand(fa => !fa.NotForUpdate);

    /// <summary>
    /// 主键取值(字符串)
    /// </summary>
    /// <returns></returns>
    public virtual string KeyValue()
    {
        var strategy = EntityStrategy();
        if (!strategy.Viable()) return string.Empty;

        return strategy.Fields!.Where(o => o.Value.Key)
            .Select(o => this.GetProperty(o.Key)?.GetValue(this)!)
            .AggregateToString("_");
    }

    /// <summary>
    /// 填回主键
    /// </summary>
    /// <param name="keyValue"></param>
    public virtual void FulfillKeyValue(object? keyValue)
    {
        var strategy = EntityStrategy();
        if (!strategy.Viable()) return;

        var keyField = strategy.Fields?
            .Where(o => o.Value.Key)
            .First();
        var keyType = this.GetProperty(keyField!.Value.Key)!.PropertyType;
        this.SetPropertyValue(keyField.Value.Key, Convert.ChangeType(keyValue, keyType));
    }
}