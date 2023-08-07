
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Enums;
using Microsoft.Extensions.Configuration;

namespace Ban3.Infrastructures.DataPersist.Models;

public class EntityStrategy
{
    public DB? DB { get; set; }

    public TableIsAttribute? Table { get; set; }

    public Dictionary<string, FieldIsAttribute>? Fields { get; set; }

    public bool Viable() => DB != null && Table != null && Fields != null;

    public EntityStrategy() { }

    public EntityStrategy(Type entityType)
    {
        Table = GetTable(entityType);
        Fields = GetFields(entityType);
        DB = Table != null ? GetDB(Table.DbName) : null;
    }

    static DB? GetDB(string key)
        => new DB
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

    public string InsertCommand()
    {
        var sb = new StringBuilder();

        var fieldsItems = Fields
            .Where(o => !o.Value.NotForInsert)
            .ToList();

        var fieldsString = fieldsItems
            .Select(o => $"{o.Value.ColumnName}")
            .AggregateToString(",");
        var valuesString = fieldsItems
            .Select(o => $"@{o.Value.ColumnName}")
        .AggregateToString(",");

        sb.Append($"INSERT INTO {Table!.TableName} ({fieldsString}) VALUES ({valuesString});");

        var requestInsertedId = Fields.Any(x => x.Value.Key && x.Value.Increment);
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

    public string UpdateCommand() 
    {
        var sb = new StringBuilder();

        var fieldsItems = Fields
            .Where(o => !o.Value.NotForUpdate)
            .ToList();

        var fieldsString = fieldsItems
            .Select(o => $"{o.Value.ColumnName}=@{o.Value.ColumnName}")
            .AggregateToString(" AND ");
        var keysString = Fields
            .Where(o => o.Value.Key)
            .Select(o => $"{o.Value.ColumnName}=@{o.Value.ColumnName}")
            .AggregateToString(" AND ");

        sb.Append($"UPDATE {Table!.TableName} SET {fieldsString} WHERE {keysString}");

        return sb.ToString();
    }

    public string DeleteCommand()
    {
        var sb = new StringBuilder();

        var keysString = Fields
            .Where(o => o.Value.Key)
            .Select(o => $"{o.Value.ColumnName}=@{o.Value.ColumnName}")
            .AggregateToString(" AND ");

        sb.Append($"DELETE FROM {Table!.TableName} WHERE {keysString}");

        return sb.ToString();
    }

    public string SelectCommand()
    {
        var sb = new StringBuilder();

        var fieldsString = Fields
            .Select(o => $"{o.Value.ColumnName}")
            .AggregateToString(",");
        var keysString = Fields
            .Where(o => o.Value.Key)
            .Select(o => $"{o.Value.ColumnName}=@{o.Value.ColumnName}")
        .AggregateToString(" AND ");

        sb.Append($"SELECT {fieldsString} FROM {Table!.TableName} SET WHERE {keysString}");

        return sb.ToString();
    }
}