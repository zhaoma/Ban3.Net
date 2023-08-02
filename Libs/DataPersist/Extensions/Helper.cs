
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;
using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Entities;
using Ban3.Infrastructures.DataPersist.Enums;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;

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
    public static IDbConnection Connection(
        this Models.DB db)
        =>
            db.Database switch
            {
                Database.Sqlite=>new SqliteConnection(db.ConnectionString),
                Database.MSSQL=>new SqlConnection(db.ConnectionString),
                Database.mysql=>new MySqlConnection(db.ConnectionString),
                _=>throw new ArgumentOutOfRangeException()
            };

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
        DbParameter[] paramList)
    {
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

    public static TableIsAttribute? Table(this BaseEntity entity)
        => Config.Table(entity);

    public static List<FieldIsAttribute>? Fields(this BaseEntity entity)
        => Config.Fields(entity);
}