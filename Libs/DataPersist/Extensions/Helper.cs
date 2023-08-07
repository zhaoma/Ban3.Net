
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
    public static CancellationTokenSource CancellationTokenSource = new();

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

    private static readonly Dictionary<string, IDbConnection> ConnectionDic = new();

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
        if (paramList != null)
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

    public static EntityStrategy Strategy<T>(this T obj)
        => Config.Strategy(obj!.GetType());

    public static string KeyValue<T>(this T obj)
    {
        var keys = obj.Strategy().Fields?.Where(o => o.Value.Key).ToList();

        if (keys != null && keys.Any())
        {
            return keys.Select(o => obj!.GetProperty(o.Key)?.GetValue(obj)!)
                .AggregateToString("_");
        }

        return string.Empty;
    }

    public static DbParameter[]? ParametersForInsert<T>(this T obj) => obj.ParametersForCommand(fa => !fa.NotForInsert);

    public static DbParameter[]? ParametersForUpdate<T>(this T obj) => obj.ParametersForCommand(fa => !fa.NotForUpdate);

    public static DbParameter[]? ParametersForKeys<T>(this T obj) => obj.ParametersForCommand(fa => fa.Key);

    public static DbParameter[]? ParametersForCommand<T>(this T obj,Func<FieldIsAttribute ,bool> func)
    {
        var strategy = obj.Strategy();
        if (strategy.Viable()) return null;

        var ps = strategy.Fields.Where(o => func(o.Value));

        return strategy.DB!.Database switch
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
        var keyField = obj!.Strategy().Fields?
            .Where(o => o.Value.Key)
            .First();
        var keyType = obj!.GetProperty(keyField!.Value.Key)!.PropertyType;
        obj!.SetPropertyValue(keyField.Value.Key, Convert.ChangeType(keyValue, keyType));

        return obj;
    }
}