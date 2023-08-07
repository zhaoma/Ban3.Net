
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
                return new SqliteConnection(db.ConnectionString);
            case Database.MSSQL:
                return new SqlConnection(db.ConnectionString);
            case Database.mysql:
                return new MySqlConnection(db.ConnectionString);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static readonly Dictionary<string, IDbConnection> ConnectionDic=new ();

    public static IDbConnection Connection(this Models.DB db)
    {
        if (ConnectionDic.TryGetValue(db.ConnectionString, out var dbConnection))
        {
            Logger.Debug($"load connection from pool");
            if (dbConnection.State != ConnectionState.Open)
            {
                Logger.Debug("OPEN CONN");
                dbConnection.Open();
            }

            return dbConnection;
        }

        Logger.Debug("PREPARE CONN");
        dbConnection = db.PrepareConnection();
        dbConnection.Open();
        
        ConnectionDic.AddOrReplace(db.ConnectionString, dbConnection);

        return dbConnection;
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
        if (paramList!=null)
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
    /// <param name="tableAttribute"></param>
    /// <returns></returns>
    public static DB? DB(this TableIsAttribute? tableAttribute)
    {
        if (tableAttribute != null)
        {
            return Config.DB(tableAttribute.DbName);
        }

        return null;
    }

    public static DB? DB(this System.Type tp)
        => tp.Table().DB();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static TableIsAttribute? Table(this System.Type tp)
        => Config.Table(tp);
    
    public static Dictionary<string, FieldIsAttribute>? Fields(this System.Type tp)
        => Config.Fields(tp);

    public static string KeyValue<T>(this T obj)
    {
        var keys = obj!.GetType().Fields()?.Where(o => o.Value.Key).ToList();

        if (keys != null && keys.Any())
        {
            return keys.Select(o => obj!.GetProperty(o.Key)?.GetValue(obj)!)
                .AggregateToString("_");
        }

        return string.Empty;
    }

    public static string SqlForInsert(this System.Type entityType)
        => Config.InsertCommand(entityType);

    public static string SqlForUpdate(this System.Type entityType)
        => Config.UpdateCommand(entityType);

    public static string SqlForDelete(this System.Type entityType)
        => Config.DeleteCommand(entityType);
    
    public static string SqlForSelect(this System.Type entityType)
        => Config.SelectCommand(entityType);

    public static DbParameter[]? ParametersForInsert<T>(this T obj)
    {
        var ps = obj!.GetType().Fields()?.Where(o => !o.Value.NotForInsert);

        if(ps==null)return null;

        return obj!.GetType().DB()!.Database switch
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

    public static DbParameter[]? ParametersForUpdate<T>(this T obj)
    {
        var fs = obj!.GetType().Fields();
        var ps = fs?.Where(o => !o.Value.NotForUpdate);

        if (ps == null) return null;

        return obj.GetType().DB()!.Database switch
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

    public static DbParameter[]? ParametersForKeys<T>(this T obj)
    {
        var fs = obj!.GetType().Fields();
        var ps = fs?.Where(o => o.Value.Key);

        if (ps == null) return null;

        return obj.GetType().DB()!.Database switch
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
        var keyField = obj!.GetType().Fields()?
            .Where(o => o.Value.Key)
            .First();
        var keyType = obj.GetProperty(keyField.Value.Key).PropertyType;
        obj.SetPropertyValue(keyField.Value.Key,Convert.ChangeType( keyValue , keyType));

        return obj;
    }

    public static string Sql(this Enums.Operate operate, System.Type entityType, string condition = "")
    {

    }
}