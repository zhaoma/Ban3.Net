
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Enums;
using Microsoft.Extensions.Configuration;

namespace Ban3.Infrastructures.DataPersist.Models;

/// <summary>
/// 实体策略定义
/// </summary>
public class EntityStrategy
{
    /// <summary>
    /// 库申明
    /// </summary>
    public DB? DB { get; set; }

    /// <summary>
    /// 表申明
    /// </summary>
    public TableIsAttribute? Table { get; set; }

    /// <summary>
    /// 字段申明
    /// </summary>
    public Dictionary<string, FieldIsAttribute>? Fields { get; set; }

    /// <summary>
    /// 实体有效
    /// </summary>
    /// <returns></returns>
    public bool Viable() => DB != null && Table != null && Fields != null;

    public EntityStrategy() { }

    public EntityStrategy(Type entityType)
    {
        Table = GetTable(entityType);
        Fields = GetFields(entityType);
        DB = Table != null ? GetDB(Table.DbName) : null;
    }

    static DB GetDB(string key)
        => new ()
        {
            Database = (Common.Config.GetValue($"DBS:{key}") + "").StringToEnum<Database>(),
            ConnectionString = Common.Config.AppConfiguration?.GetConnectionString(key) + ""
        };

    static TableIsAttribute? GetTable(Type tp)
        => tp.GetAttributes<TableIsAttribute>()?.First();

    static Dictionary<string, FieldIsAttribute>? GetFields(Type tp)
    {
        var properties = tp.GetPublicProperties();

        if (properties == null) return null;

        var target = new Dictionary<string, FieldIsAttribute>();

        properties.ForEach(o =>
        {
            var propertyAttribute = o.GetPropertyAttributes<FieldIsAttribute>()?.First();
            if (propertyAttribute != null)
                target.AddOrReplace(o.Name, propertyAttribute, false);
        });

        return target;
    }

    /// <summary>
    /// 新建记录命令
    /// </summary>
    /// <returns></returns>
    public string InsertCommand()
    {
        var sb = new StringBuilder();

        var fieldsItems = Fields!
            .Where(o => !o.Value.NotForInsert)
            .ToList();

        var fieldsString = fieldsItems
            .Select(o => $"{o.Value.ColumnName}")
            .AggregateToString(",");
        var valuesString = fieldsItems
            .Select(o => $"@{o.Value.ColumnName}")
        .AggregateToString(",");

        sb.Append($"INSERT INTO {Table!.TableName} ({fieldsString}) VALUES ({valuesString});");

        var requestInsertedId = Fields!.Any(x => x.Value.Key && x.Value.Increment);
        if (requestInsertedId)
        {
            switch (DB!.Database)
            {
                case Database.Sqlite:
                    sb.Append("SELECT last_insert_rowid();");
                    break;
                case Database.MSSQL:
                    sb.Append("SELECT SCOPE_IDENTITY();");
                    break;
                case Database.mysql:
                    sb.Append("SELECT LAST_INSERT_ID();");
                    break;
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// 更新命令(用主键)
    /// </summary>
    /// <returns></returns>
    public string UpdateCommand()
        => UpdateCommand(Fields!
            .Where(o => o.Value.Key)
            .Select(o => $"{o.Value.ColumnName}=@{o.Value.ColumnName}")
            .AggregateToString(" AND "));

    /// <summary>
    /// 更新命令(按条件)
    /// </summary>
    /// <param name="condition"></param>
    /// <returns></returns>
    public string UpdateCommand(string condition)
    {
        var fieldsString = Fields!
            .Where(o => !o.Value.NotForUpdate)
            .Select(o => $"{o.Value.ColumnName}=@{o.Value.ColumnName}")
            .AggregateToString(",");
        return $"UPDATE {Table!.TableName}  SET {fieldsString} WHERE {condition}";
    }

    /// <summary>
    /// 删除命令(用主键)
    /// </summary>
    /// <returns></returns>
    public string DeleteCommand()
        => DeleteCommand(Fields!
            .Where(o => o.Value.Key)
            .Select(o => $"{o.Value.ColumnName}=@{o.Value.ColumnName}")
            .AggregateToString(" AND "));

    /// <summary>
    /// 删除命令(按条件)
    /// </summary>
    /// <param name="condition"></param>
    /// <returns></returns>
    public string DeleteCommand(string condition)
        => $"DELETE FROM {Table!.TableName} WHERE {condition}";

    /// <summary>
    /// 检索命令(用主键)
    /// </summary>
    /// <returns></returns>
    public string SelectCommand()
        => SelectCommand(Fields!
            .Where(o => o.Value.Key)
            .Select(o => $"{o.Value.ColumnName}=@{o.Value.ColumnName}")
            .AggregateToString(" AND "));

    /// <summary>
    /// 检索命令(用条件)
    /// </summary>
    /// <param name="condition"></param>
    /// <returns></returns>
    public string SelectCommand(string condition)
    {
        var fieldsString = Fields!
            .Select(o => $"{o.Value.ColumnName}")
            .AggregateToString(",");

        return $"SELECT {fieldsString} FROM {Table!.TableName} WHERE {condition}";
    }
}