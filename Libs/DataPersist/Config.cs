using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Enums;
using Ban3.Infrastructures.DataPersist.Models;
using Microsoft.Extensions.Configuration;

namespace Ban3.Infrastructures.DataPersist;

/// <summary>
/// 
/// </summary>
public class Config
{
    private static readonly Dictionary<string, EntityStrategy> StrategyDic = new ();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entityType"></param>
    /// <returns></returns>
    public static EntityStrategy? Strategy(Type entityType)
    {
        if (StrategyDic.TryGetValue(entityType.FullName, out var strategy))
        {
            return strategy;
        }

        strategy = new EntityStrategy(entityType);

        StrategyDic.AddOrReplace(entityType.FullName, strategy, false);

        return strategy;
    }
    
    #region 表属性

    private static readonly Dictionary<string, TableIsAttribute> TableDic = new ();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tp"></param>
    /// <returns></returns>
    public static TableIsAttribute? Table(Type tp)
    {
        var key =tp.FullName;
        if (TableDic.TryGetValue(key, out var table))
        {
            return table;
        }

        var target = tp.GetAttributes<TableIsAttribute>()?.First();
        if (target != null)
            TableDic.AddOrReplace(key!, target, false);

        return target;
    }

    #endregion
    
    #region 字段属性

    private static readonly Dictionary<string, Dictionary<string,FieldIsAttribute>> FieldsDic = new ();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tp"></param>
    /// <returns></returns>
    public static Dictionary<string, FieldIsAttribute>? Fields(Type tp)
    {
        var key = tp.FullName;

        if (FieldsDic.TryGetValue(key, out var fields))
        {
            return fields;
        }

        var properties =tp.GetPublicProperties();

        if (properties == null) return null;

        var target = new Dictionary<string, FieldIsAttribute>();

        properties.ForEach(o =>
        {
            var propertyAttribute = o.GetPropertyAttributes<FieldIsAttribute>()?.First();
            if (propertyAttribute != null)
                target.AddOrReplace(o.Name, propertyAttribute, false);
        });

        FieldsDic.AddOrReplace(key!, target, false);

        return target;
    }

    #endregion

    public static Func<Type, string> InsertCommand = (t) =>
    {
        var table = Table(t);
        var fields = Fields(t);
        var db = table != null ? DB(table.DbName) : null;

        return SQLForInsert(db,table, fields);
    };

    private static readonly Func<DB?, TableIsAttribute?, Dictionary<string, FieldIsAttribute>?, string>
        SQLForInsert = (db, table, fields) =>
            {
                if (db == null || table == null || fields == null) return string.Empty;
                
                var sb = new StringBuilder();

                var fieldsItems = fields
                    .Where(o => !o.Value.NotForInsert)
                    .ToList();

                var fieldsString = fieldsItems
                    .Select(o => $"{o.Value.ColumnName}")
                    .AggregateToString(",");
                var valuesString = fieldsItems
                    .Select(o => $"@{o.Value.ColumnName}")
                    .AggregateToString(",");

                sb.Append($"INSERT INTO {table.TableName} ({fieldsString}) VALUES ({valuesString});");

                var requestInsertedId = fields.Any(x => x.Value.Key && x.Value.Increment);
                if (requestInsertedId)
                {
                    switch (db.Database)
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
            };

    public static Func<Type, string> UpdateCommand = (t) =>
    {
        var table = Table(t);
        var fields = Fields(t);
        var db = table != null ? DB(table.DbName) : null;

        return SQLForUpdate(db, table, fields);
    };

    private static readonly Func<DB?, TableIsAttribute?, Dictionary<string, FieldIsAttribute>?, string>
        SQLForUpdate = (db, table, fields) =>
        {
            if (db == null || table == null || fields == null) return string.Empty;
            
            var sb = new StringBuilder();

            var fieldsItems = fields
                .Where(o => !o.Value.NotForUpdate)
                .ToList();

            var fieldsString = fieldsItems
                .Select(o => $"{o.Value.ColumnName}=@{o.Value.ColumnName}")
                .AggregateToString(" AND ");
            var keysString = fields
                .Where(o => o.Value.Key)
                .Select(o => $"{o.Value.ColumnName}=@{o.Value.ColumnName}")
                .AggregateToString(" AND ");

            sb.Append($"UPDATE {table.TableName} SET {fieldsString} WHERE {keysString}");

            return sb.ToString();
        };

    public static Func<Type, string> DeleteCommand = (t) =>
    {
        var table = Table(t);
        var fields = Fields(t);
        var db = table != null ? DB(table.DbName) : null;

        return SQLForDelete(db, table, fields);
    };

    private static readonly Func<DB?, TableIsAttribute?, Dictionary<string, FieldIsAttribute>?, string>
        SQLForDelete = (db, table, fields) =>
        {
            if (db == null || table == null || fields == null) return string.Empty;

            var sb = new StringBuilder();
            
            var keysString = fields
                .Where(o => o.Value.Key)
                .Select(o => $"{o.Value.ColumnName}=@{o.Value.ColumnName}")
                .AggregateToString(" AND ");

            sb.Append($"DELETE FROM {table.TableName} WHERE {keysString}");

            return sb.ToString();
        };

    public static Func<Type, string> SelectCommand = (t) =>
    {
        var table = Table(t);
        var fields = Fields(t);
        var db = table != null ? DB(table.DbName) : null;

        return SQLForSelect(db, table, fields);
    };
    
    private static readonly Func<DB?, TableIsAttribute?, Dictionary<string, FieldIsAttribute>?, string>
        SQLForSelect = (db, table, fields) =>
        {
            if (db == null || table == null || fields == null) return string.Empty;

            var sb = new StringBuilder();
            
            var fieldsString = fields
                .Select(o => $"{o.Value.ColumnName}")
                .AggregateToString(",");
            var keysString = fields
                .Where(o => o.Value.Key)
                .Select(o => $"{o.Value.ColumnName}=@{o.Value.ColumnName}")
                .AggregateToString(" AND ");

            sb.Append($"SELECT {fieldsString} FROM {table.TableName} SET WHERE {keysString}");

            return sb.ToString();
        };
}