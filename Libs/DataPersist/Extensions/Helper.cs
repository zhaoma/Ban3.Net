
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Entities;
using Ban3.Infrastructures.DataPersist.Enums;
using Ban3.Infrastructures.DataPersist.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using ZstdSharp.Unsafe;

// ReSharper disable CoVariantArrayConversion

namespace Ban3.Infrastructures.DataPersist.Extensions;

/// <summary>
/// 
/// </summary>
public static partial class Helper
{
    private static readonly log4net.ILog Logger =
        log4net.LogManager.GetLogger(typeof(Helper));

    /// <summary>
    /// 
    /// </summary>
    public static CancellationTokenSource CancellationTokenSource = new ();

    /// <summary>
    /// 建立连接
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private static IDbConnection PrepareConnection(
        this Models.DB db)
    {
        switch (db.Database)
        {
            case Database.Sqlite:
                var c1 = new SqliteConnection(db.ConnectionString);
                c1.Open();
                return c1;
            case Database.MSSQL:
                var c2=new SqlConnection(db.ConnectionString);
                c2.Open();
                return c2;
            case Database.mysql:
                var c3=new MySqlConnection(db.ConnectionString);
                c3.Open(); 
                return c3;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    private static IDbConnection _connection

    public static IDbConnection Connection
    {
        get
        {

        }
    }

    /// <summary>
    /// 开始事务
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public static IDbTransaction Transaction(
        this Models.DB db)
        => db.Connection().BeginTransaction();

    /// <summary>
    /// 创建命令
    /// </summary>
    /// <param name="db"></param>
    /// <param name="sql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static DbCommand Command(
        this Models.DB db,
        string sql,
        IDbTransaction? transaction = null)
    {
        Logger.Debug($"SQL:{sql}");
        IDbConnection connection;
        if (transaction == null)
        {
            connection = db.Connection();
            return db.Database switch
            {
                Database.Sqlite => new SqliteCommand(sql, (SqliteConnection)connection),
                Database.MSSQL => new SqlCommand(sql, (SqlConnection)connection),
                Database.mysql => new MySqlCommand(sql, (MySqlConnection)connection),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        connection = transaction.Connection;
        return db.Database switch
        {
            Database.Sqlite => new SqliteCommand(
                sql,
                (SqliteConnection)connection,
                (SqliteTransaction)transaction),
            Database.MSSQL => new SqlCommand(
                sql,
                (SqlConnection)connection,
                (SqlTransaction)transaction),
            Database.mysql => new MySqlCommand(
                sql,
                (MySqlConnection)connection,
                (MySqlTransaction)transaction),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static DbCommand AddParameters(
        this DbCommand command, 
        DbParameter[]? paramList)
    {
        if(paramList!=null)
            command.Parameters.AddRange(paramList);

        return command;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dr"></param>
    /// <returns></returns>
    public static T DataReaderToEntity<T>(this IDataReader dr)
    {
        var builder = DynamicBuilder<T>.CreateBuilder(dr);
        var instance = builder.Build(dr);

        return instance;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dr"></param>
    /// <returns></returns>
    public static List<T> DataReaderToList<T>(this IDataReader dr)
    {
        var list = new List<T>();
        var builder = DynamicBuilder<T>.CreateBuilder(dr);

        while (dr.Read())
        {
            var instance = builder.Build(dr);
            if (!list.Contains(instance))
                list.Add(instance);
        }

        return list;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static DB? DB<T>(this T obj)
    {
        var tableAttribute = obj.Table();
        if (tableAttribute != null)
        {
            return Config.DB(tableAttribute.DbName);
        }

        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static TableIsAttribute? Table<T>(this T obj)
        => Config.Table(obj);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static Dictionary<string, FieldIsAttribute>? Fields<T>(this T obj)
        => Config.Fields(obj);

    public static string KeyValue<T>(this T obj)
    {
        var keys = obj.Fields()?.Where(o => o.Value.Key).ToList();

        if (keys != null && keys.Any())
        {
            return keys.Select(o => obj!.GetProperty(o.Key)?.GetValue(obj)!)
                .AggregateToString("_");
        }

        return string.Empty;
    }

    public static string SqlForInsert<T>(this T obj)
    {
        var table = obj.Table();

        var fields = obj.Fields();

        if (table == null || fields == null) return string.Empty;

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
        switch (obj.DB()?.Database)
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

        return sb.ToString();
    }

    public static DbParameter[]? ParametersForInsert<T>(this T obj)
    {
        var ps = obj.Fields()?.Where(o => !o.Value.NotForInsert);

        if(ps==null)return null;

        return obj.DB()!.Database switch
        {
            Database.Sqlite => ps.Select(o =>
                new SqliteParameter($"@{o.Value.ColumnName}", obj!.GetProperty(o.Key)?.GetValue(obj)!)).ToArray(),
            Database.MSSQL => ps.Select(o =>
                new SqlParameter($"@{o.Value.ColumnName}", obj!.GetProperty(o.Key)?.GetValue(obj)!)).ToArray(),
            Database.mysql => ps.Select(o =>
                new MySqlParameter($"@{o.Value.ColumnName}", obj!.GetProperty(o.Key)?.GetValue(obj)!)).ToArray(),
            _ => throw new NotImplementedException()
        };
    }

    public static string SqlForUpdate<T>(this T obj)
    {
        var table = obj.Table();

        var fields = obj.Fields();

        if (table == null || fields == null) return string.Empty;

        var sb = new StringBuilder();

        var fieldsItems = fields
            .Where(o => !o.Value.NotForUpdate)
            .ToList();

        var fieldsString = fieldsItems
            .Select(o => $"[{o.Value.ColumnName}]=@{o.Value.ColumnName}")
            .AggregateToString(" AND ");
        var keysString = fields
            .Where( o=>o.Value.Key)
            .Select(o => $"[{o.Value.ColumnName}]=@{o.Value.ColumnName}")
            .AggregateToString(" AND ");

        sb.Append($"UPDATE [{table.TableName}] SET {fieldsString} WHERE {keysString}");
        
        return sb.ToString();
    }

    public static DbParameter[]? ParametersForUpdate<T>(this T obj)
    {
        var fs = obj.Fields();
        var ps = fs?.Where(o => !o.Value.NotForUpdate)
            .Union(fs?.Where(o=>o.Value.Key)!);

        if (ps == null) return null;

        return obj.DB()!.Database switch
        {
            Database.Sqlite => ps.Select(o =>
                new SqliteParameter($"@{o.Value.ColumnName}", obj!.GetProperty(o.Key)?.GetValue(obj)!)).ToArray(),
            Database.MSSQL => ps.Select(o =>
                new SqlParameter($"@{o.Value.ColumnName}", obj!.GetProperty(o.Key)?.GetValue(obj)!)).ToArray(),
            Database.mysql => ps.Select(o =>
                new MySqlParameter($"@{o.Value.ColumnName}", obj!.GetProperty(o.Key)?.GetValue(obj)!)).ToArray(),
            _ => throw new NotImplementedException()
        };
    }

    public static T FulfillKeyValue<T>(this T obj, object? keyValue)
    {
        var keyField = obj.Fields()?
            .Where(o => o.Value.Key)
            .First();
        var keyType = obj.GetProperty(keyField.Value.Key).PropertyType;
        obj.SetPropertyValue(keyField.Value.Key,Convert.ChangeType( keyValue , keyType));

        return obj;
    }
}