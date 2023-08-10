
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.DataPersist.Entities;
using Ban3.Infrastructures.DataPersist.Enums;
using Ban3.Infrastructures.DataPersist.Models;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;

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
        this DB db)
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

    /// <summary>
    /// 获取连接
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public static IDbConnection Connection(this DB db)
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
        this DB db)
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
        this DB db,
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

    /// <summary>
    /// 实体的操作命令
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="operate">Enums.Operate</param>
    /// <param name="transaction"></param>
    /// <param name="conditionOrSql"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static DbCommand? Command<T>(
        this T obj, 
        Operate operate,
        IDbTransaction? transaction = null,
        string conditionOrSql = "") where T : BaseEntity
    {
        var strategy = obj.EntityStrategy();
        if (strategy.Viable())
        {
            return operate switch
            {
                Operate.Create => 
                    strategy.DB!.Command(strategy.InsertCommand(), transaction),
                Operate.Update => 
                    strategy.DB!.Command(strategy.UpdateCommand(), transaction),
                Operate.UpdateByCondition => 
                    strategy.DB!.Command(strategy.UpdateCommand(conditionOrSql), transaction),
                Operate.Retrieve =>
                    strategy.DB!.Command(strategy.SelectCommand(), transaction),
                Operate.RetrieveByCondition =>
                    strategy.DB!.Command(strategy.SelectCommand(conditionOrSql), transaction),
                Operate.Delete => 
                    strategy.DB!.Command(strategy.DeleteCommand(), transaction),
                Operate.DeleteByCondition => 
                    strategy.DB!.Command(strategy.DeleteCommand(conditionOrSql), transaction),
                Operate.Sql => 
                    strategy.DB!.Command(conditionOrSql, transaction),
                _ => throw new ArgumentOutOfRangeException(nameof(operate), operate, null)
            };
        }

        return null;
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
    /// 快速填充实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dr"></param>
    /// <returns></returns>
    public static T? DataReaderToEntity<T>(this IDataReader dr)
    {
        try
        {
            if (dr.Read())
            {
                var builder = DynamicBuilder<T>.CreateBuilder(dr);
                var instance = builder.Build(dr);
                return instance;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }
        finally
        {
            dr.Close();
            dr.Dispose();
        }

        return default(T);
    }

    /// <summary>
    /// 快速填充实体集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dr"></param>
    /// <returns></returns>
    public static List<T> DataReaderToList<T>(this IDataReader dr)
    {
        var list = new List<T>();
        try
        {
            var builder = DynamicBuilder<T>.CreateBuilder(dr);
            
            while (dr.Read())
            {
                var instance = builder.Build(dr);
                if (!list.Contains(instance))
                    list.Add(instance);
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }
        finally
        {
            dr.Close();
            dr.Dispose();
        }

        return list;
    }
}