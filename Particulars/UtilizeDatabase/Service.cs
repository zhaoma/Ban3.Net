/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma @ 2022 :
 * 数据库接口实现
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

using log4net;
using Ban3.Infrastructures.Interfaces.ServiceTags;

using Dapper;
using Dapper.Contrib.Extensions;
using static Dapper.SqlMapper;

namespace Ban3.Infrastructures.Particulars.UtilizeDatabase
{
    /// <summary>
    /// dapper常用方法
    /// </summary>
    public class Service
            : Interfaces.Particulars.IDatabase, ISingletonTag
    {
        private readonly ILog _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public Service( ILog logger )
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public IDbTransaction BeginTransaction(
                IDbConnection dbConnection,
                IsolationLevel isolationLevel = IsolationLevel.Unspecified )
        {
            return dbConnection.BeginTransaction( isolationLevel );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbTransaction"></param>
        public void CommitTransaction(IDbTransaction dbTransaction)
        {
            try
            {
                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                _logger.Error(ex);
            }
            finally
            {
                dbTransaction.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="t"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public long Insert<T>(
                IDbConnection dbConnection,
                T t,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null ) where T : class
        {
            return dbConnection.Insert<T>( t, dbTransaction, commandTimeout );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="t"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public bool Update<T>(
                IDbConnection dbConnection,
                T t,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null ) where T : class
        {
            return dbConnection.Update<T>( t, dbTransaction, commandTimeout );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="t"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public bool Delete<T>(
                IDbConnection dbConnection,
                T t,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null ) where T : class
        {
            return dbConnection.Delete<T>( t, dbTransaction, commandTimeout );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IQueryable<T> Set<T>(
                IDbConnection dbConnection,
                string sql ) where T : class
        {
            return dbConnection.Query<T>( sql )
                               .AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public int Execute(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null
        )
        {
            return dbConnection.Execute( sql, param, dbTransaction, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task<int> ExecuteAsync(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null
        )
        {
            return dbConnection.ExecuteAsync( sql, param, dbTransaction, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null
        )
        {
            return dbConnection.ExecuteReader( sql, param, dbTransaction, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task<IDataReader> ExecuteReaderAsync(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null
        )
        {
            return dbConnection.ExecuteReaderAsync( sql, param, dbTransaction, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public T ExecuteScalar<T>(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null
        )
        {
            return dbConnection.ExecuteScalar<T>( sql, param, dbTransaction, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task<T> ExecuteScalarAsync<T>(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null
        )
        {
            return dbConnection.ExecuteScalarAsync<T>( sql, param, dbTransaction, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                bool buffered = true,
                int? commandTimeout = null,
                CommandType? commandType = null
        )
        {
            return dbConnection.Query<T>( sql, param, dbTransaction, buffered, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="type"></param>
        /// <param name="func"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task<IEnumerable<T>> QueryAsync<T>(
                IDbConnection dbConnection,
                Type[] type,
                Func<object[], T> func,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                bool buffered = true,
                string splitOn = "id",
                int? commandTimeout = null,
                CommandType? commandType = null
        )
        {
            return dbConnection.QueryAsync( sql, type, func, param, dbTransaction, buffered, splitOn, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public GridReader QueryMultiple(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null )
        {
            return dbConnection.QueryMultiple( sql, param, dbTransaction, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task<GridReader> QueryMultipleAsync(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null )
        {
            return dbConnection.QueryMultipleAsync( sql, param, dbTransaction, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public T QueryFirst<T>(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null )
        {
            return dbConnection.QueryFirst<T>( sql, param, dbTransaction, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task<T> QueryFirstAsync<T>(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null )
        {
            return dbConnection.QueryFirstAsync<T>( sql, param, dbTransaction, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public T QueryFirstOrDefault<T>(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null )
        {
            return dbConnection.QueryFirstOrDefault<T>( sql, param, dbTransaction, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task<T> QueryFirstOrDefaultAsync<T>(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null )
        {
            return dbConnection.QueryFirstOrDefaultAsync<T>( sql, param, dbTransaction, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public T QuerySingle<T>(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null )
        {
            return dbConnection.QuerySingle<T>( sql, param, dbTransaction, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task<T> QuerySingleAsync<T>(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null )
        {
            return dbConnection.QuerySingleAsync<T>( sql, param, dbTransaction, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public T QuerySingleOrDefault<T>(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null )
        {
            return dbConnection.QuerySingleOrDefault<T>( sql, param, dbTransaction, commandTimeout, commandType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task<T> QuerySingleOrDefaultAsync<T>(
                IDbConnection dbConnection,
                string sql,
                object? param = null,
                IDbTransaction? dbTransaction = null,
                int? commandTimeout = null,
                CommandType? commandType = null )
        {
            return dbConnection.QuerySingleOrDefaultAsync<T>( sql, param, dbTransaction, commandTimeout, commandType );
        }
    }
}