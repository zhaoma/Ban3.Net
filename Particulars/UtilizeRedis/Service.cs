﻿/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma @ 2022 :
 * Redis服务器访问接口实现
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Linq;

using Ban3.Infrastructures.Common.Extensions;

using log4net;

using StackExchange.Redis;

namespace Ban3.Infrastructures.Particulars.UtilizeRedis
{
    /// <summary>
    /// Redis服务器访问接口实现
    /// </summary>
    public class Service
            : Interfaces.Particulars.IRedis
    {
        private readonly ILog _logger;

        /// <summary>
        /// Redis服务器访问接口实现
        /// </summary>
        /// <param name="logger"></param>
        public Service(
                ILog logger
        )
        {
            _logger = logger;
        }

        internal static readonly object Locker = new object();
        internal static ConnectionMultiplexer _instance;

        /// <summary>
        /// 单例获取
        /// </summary>
        public static ConnectionMultiplexer Instance
        {
            get
            {
                if( _instance == null )
                {
                    lock( Locker )
                    {
                        if( _instance == null || !_instance.IsConnected )
                        {
                            _instance = GetManager();
                        }
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// 内部方法，获取Redis连接
        /// </summary>
        /// <returns></returns>
        private static ConnectionMultiplexer GetManager()
        {
            if( string.IsNullOrEmpty( Common.Config.CurrrentEnvironment.Particulars.Redis.Endpoints ) )
                return null;

            var config = new ConfigurationOptions
            {
                    Password = Common.Config.CurrrentEnvironment.Particulars.Redis.Password,
                    EndPoints = { Common.Config.CurrrentEnvironment.Particulars.Redis.Endpoints },
                    KeepAlive = 180
            };

            var connect = ConnectionMultiplexer.Connect( config );

            //注册如下事件
            connect.ConnectionFailed += MuxerConnectionFailed;
            connect.ConnectionRestored += MuxerConnectionRestored;
            connect.ErrorMessage += MuxerErrorMessage;
            connect.ConfigurationChanged += MuxerConfigurationChanged;
            connect.HashSlotMoved += MuxerHashSlotMoved;
            connect.InternalError += MuxerInternalError;

            return connect;
        }

        /// <summary>
        /// 
        /// </summary>
        public static IDatabase Client
        {
            get
            {
                if( Instance != null )
                    return Instance.GetDatabase( Common.Config.CurrrentEnvironment.Particulars.Redis.DbNumber );

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static ISubscriber Subscriber
        {
            get
            {
                if( Instance != null )
                    return Instance.GetSubscriber();

                return null;
            }
        }

        #region 事件

        /// <summary>
        /// 配置更改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConfigurationChanged( object sender, EndPointEventArgs e )
        {
            //log.InfoAsync($"Configuration changed: {e.EndPoint}");
        }

        /// <summary>
        /// 发生错误时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerErrorMessage( object sender, RedisErrorEventArgs e )
        {
            //log.InfoAsync($"ErrorMessage: {e.Message}");
        }

        /// <summary>
        /// 重新建立连接之前的错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionRestored( object sender, ConnectionFailedEventArgs e )
        {
            //log.InfoAsync($"ConnectionRestored: {e.EndPoint}");
        }

        /// <summary>
        /// 连接失败 ， 如果重新连接成功你将不会收到这个通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionFailed( object sender, ConnectionFailedEventArgs e )
        {
            //log.InfoAsync($"重新连接：Endpoint failed: {e.EndPoint},  {e.FailureType} , {(e.Exception == null ? "" : e.Exception.Message)}");
        }

        /// <summary>
        /// 更改集群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerHashSlotMoved( object sender, HashSlotMovedEventArgs e )
        {
            //log.InfoAsync($"HashSlotMoved:NewEndPoint{e.NewEndPoint}, OldEndPoint{e.OldEndPoint}");
        }

        /// <summary>
        /// redis类库错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerInternalError( object sender, InternalErrorEventArgs e )
        {
            //log.InfoAsync($"InternalError:Message{ e.Exception.Message}");
        }

        #endregion 事件

        #region Private

        /// <summary>
        /// 将值反系列化成对象集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        protected List<T> ConvertList<T>( RedisValue[] values )
        {
            List<T> result = new List<T>();
            foreach( string item in values )
            {
                var model = item.JsonToObj<T>();
                result.Add( model );
            }

            return result;
        }

        /// <summary>
        /// 将值集合转换成RedisValue集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisValues"></param>
        /// <returns></returns>
        protected RedisValue[] ConvertRedisValue<T>( params T[] redisValues ) =>
                redisValues.Select( o => (RedisValue)(o.ObjToJson()) ).ToArray();

        /// <summary>
        /// 将string类型的Key转换成 <see cref="RedisKey"/> 型的Key
        /// </summary>
        /// <param name="redisKeys"></param>
        /// <returns></returns>
        protected RedisKey[] ConvertRedisKeys( params string[] redisKeys ) =>
                redisKeys.Select( redisKey => (RedisKey)redisKey ).ToArray();

        #endregion

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="channel">发布频道</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public long Publish( string channel, string obj )
        {
            if( Subscriber != null )
                return Subscriber.Publish( channel, obj );

            return 0;
        }

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="channel">订阅频道</param>
        /// <param name="callBack"></param>
        public void Subscribe( string channel, Action<string, string> callBack )
        {
            if( Subscriber != null )
                Subscriber
                        .Subscribe( channel, ( c, message ) =>
                        {
                            callBack( c, message );
                        } );
        }

        /// <summary>
        /// 链接测速
        /// </summary>
        /// <returns></returns>
        public TimeSpan Ping()
        {
            if( Client != null )
                return Client.Ping();

            return new TimeSpan();
        }

        /// <summary>
        /// 链接？
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsConnected( string key )
        {
            if( Client != null )
                return Client.IsConnected( key );

            return false;
        }

        /// <summary>
        /// 判断键值存在与否
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool KeyExists( string key )
        {
            if( Client != null )
                return Client.KeyExists( key );

            return false;
        }

        /// <summary>
        /// 移除键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool KeyDelete( string key )
        {
            if( Client != null )
                return Client.KeyDelete( key );

            return false;
        }

        #region String

        /// <summary>
        /// 读取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public T StringGet<T>( string key )
        {
            if( Client != null )
            {
                var c = Client
                        .StringGet( key ).ToString();

                return c.JsonToObj<T>();
            }

            return default(T);
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        /// <param name="expiryMinutes">过期时间</param>
        /// <returns></returns>
        public T StringSet<T>( string key, T value, int expiryMinutes )
        {
            if( Client != null )
            {
                if( value != null )
                {
                    var data = value.ObjToJson();
                    if( expiryMinutes > 0 )
                        Client.StringSet( key, data, TimeSpan.FromMinutes( expiryMinutes ) );
                    else
                        Client.StringSet( key, data );
                }
            }

            return value;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key">键值</param>
        /// <returns></returns>
        public bool StringDelete( string key )
        {
            if( Client != null )
            {
                return Client.KeyDelete( key );
            }

            return false;
        }

        #endregion

        #region Hash

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashKey"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public long HashDecrement( string hashKey, string hashField )
        {
            if( Client != null )
            {
                return Client.HashDecrement( hashKey, hashField );
            }

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashKey"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public bool HashDelete( string hashKey, string hashField )
        {
            if( Client != null )
            {
                return Client.HashDelete( hashKey, hashField );
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashKey"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public bool HashExists( string hashKey, string hashField )
        {
            if( Client != null )
            {
                return Client.HashExists( hashKey, hashField );
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashKey"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public T HashGet<T>( string hashKey, string hashField )
        {
            if( Client != null )
            {
                return Client.HashGet( hashKey, hashField )
                             .ToString()
                             .JsonToObj<T>();
            }

            return default(T);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashKey"></param>
        /// <returns></returns>
        public List<KeyValuePair<string, T>> HashGetAll<T>( string hashKey )
        {
            var hashEntries = Client.HashGetAll( hashKey );

            var kvs = new List<KeyValuePair<string, T>>();

            foreach( var hashEntry in hashEntries )
            {
                kvs.Add( new KeyValuePair<string, T>( hashEntry.Name, hashEntry.Value.ToString().JsonToObj<T>() ) );
            }

            return kvs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashKey"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public long HashIncrement( string hashKey, string hashField )
        {
            return Client.HashIncrement( hashKey, hashField );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashKey"></param>
        /// <returns></returns>
        public int HashLength( string hashKey )
        {
            return Convert.ToInt32( Client.HashLength( hashKey ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashKey"></param>
        /// <param name="pattern"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        public List<KeyValuePair<string, T>> HashScan<T>( string hashKey, string pattern, int pageSize, int pageNo )
        {
            var hashEntries = Client.HashScan( hashKey, pattern, pageSize, 0, pageNo );

            var kvs = new List<KeyValuePair<string, T>>();

            foreach( var hashEntry in hashEntries )
            {
                kvs.Add( new KeyValuePair<string, T>( hashEntry.Name, hashEntry.Value.ToString().JsonToObj<T>() ) );
            }

            return kvs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashKey"></param>
        /// <param name="kvs"></param>
        public void HashSet<T>( string hashKey, List<KeyValuePair<string, T>> kvs )
        {
            var hashEntries = new HashEntry[ kvs.Count ];
            foreach( var kv in kvs )
            {
                hashEntries.Append( new HashEntry( kv.Key, kv.Value.ObjToJson() ) );
            }

            Client.HashSet( hashKey, hashEntries );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashKey"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        public void HashSet<T>( string hashKey, string hashField, T value )
        {
            var hashEntry = new HashEntry( hashField, value.ObjToJson() );

            Client.HashSet( hashKey, new HashEntry[] { hashEntry } );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashKey"></param>
        /// <returns></returns>
        public List<T> HashValues<T>( string hashKey )
        {
            var data = Client.HashValues( hashKey );
            return ConvertList<T>( data );
        }

        #endregion

        #region List

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listKey"></param>
        /// <param name="value"></param>
        public void ListLeftPush<T>( string listKey, T value )
        {
            var data = value.ObjToJson();
            Client.ListLeftPush( listKey, data );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listKey"></param>
        /// <returns></returns>
        public T ListLeftPop<T>( string listKey )
        {
            var c = Client.ListLeftPop( listKey )
                          .ToString();

            return c.JsonToObj<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listKey"></param>
        /// <param name="value"></param>
        public void ListRightPush<T>( string listKey, T value )
        {
            var data = value.ObjToJson();
            Client.ListRightPush( listKey, data );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listKey"></param>
        /// <returns></returns>
        public T ListRightPop<T>( string listKey )
        {
            var c = Client.ListRightPop( listKey )
                          .ToString();

            return c.JsonToObj<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listKey"></param>
        /// <returns></returns>
        public int ListLength( string listKey )
        {
            return Convert.ToInt32( Client.ListLength( listKey ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listKey"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        public List<T> ListRange<T>( string listKey, int start = 0, int stop = -1 )
        {
            return ConvertList<T>( Client.ListRange( listKey, start, stop ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listKey"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public T ListGetByIndex<T>( string listKey, int index )
        {
            return Client.ListGetByIndex( listKey, index )
                         .ToString()
                         .JsonToObj<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listKey"></param>
        /// <param name="pivot"></param>
        /// <param name="value"></param>
        public void ListInsertAfter<T>( string listKey, T pivot, T value )
        {
            Client.ListInsertAfter( listKey, pivot.ObjToJson(), value.ObjToJson() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listKey"></param>
        /// <param name="pivot"></param>
        /// <param name="value"></param>
        public void ListInsertBefore<T>( string listKey, T pivot, T value )
        {
            Client.ListInsertBefore( listKey, pivot.ObjToJson(), value.ObjToJson() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ListRemove<T>( string listKey, T value )
        {
            return Client.ListRemove( listKey, value.ObjToJson() ) > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listKey"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void ListSetByIndex<T>( string listKey, int index, T value )
        {
            Client.ListSetByIndex( listKey, index, value.ObjToJson() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listKey"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public void ListTrim( string listKey, int start = 0, int stop = -1 )
        {
            Client.ListTrim( listKey, start, stop );
        }

        #endregion

        #region Set

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetAdd<T>( string setKey, T value )
        {
            return Client.SetAdd( setKey, value.ObjToJson() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetAdd<T>( string setKey, List<T> value )
        {
            try
            {
                value.AsParallel()
                     .ForAll( o =>
                     {
                         Client.SetAdd( setKey, o.ObjToJson() );
                     } );

                return true;
            }
            catch( Exception ex )
            {
                _logger.Error( ex);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public List<T> SetDifference<T>( string first, string second )
        {
            return ConvertList<T>( Client.SetCombine( SetOperation.Difference, first, second ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public List<T> SetIntersect<T>( string first, string second )
        {
            return ConvertList<T>( Client.SetCombine( SetOperation.Intersect, first, second ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKeys"></param>
        /// <returns></returns>
        public List<T> SetMerge<T>( List<string> setKeys )
        {
            if( setKeys is null || setKeys.Count() == 0 )
                return null;

            if( setKeys.Count() == 1 )
                return SetMembers<T>( setKeys[ 0 ] );

            var result = SetIntersect<T>( setKeys[ 0 ], setKeys[ 1 ] );

            for( var index = 2; index < setKeys.Count(); index++ )
            {
                for( var j = result.Count(); j >= 0; j-- )
                {
                    if( !SetContains<T>( setKeys[ index ], result[ j ] ) )
                        result.Remove( result[ j ] );
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public List<T> SetUnion<T>( string first, string second )
        {
            return ConvertList<T>( Client.SetCombine( SetOperation.Union, first, second ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetContains<T>( string setKey, T value )
        {
            return Client.SetContains( setKey, value.ObjToJson() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="setKey"></param>
        /// <returns></returns>
        public int SetLength( string setKey )
        {
            return Convert.ToInt32( Client.SetLength( setKey ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <returns></returns>
        public List<T> SetMembers<T>( string setKey )
        {
            return ConvertList<T>( Client.SetMembers( setKey ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetMove<T>( string source, string destination, T value )
        {
            return Client.SetMove( source, destination, value.ObjToJson() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <returns></returns>
        public T SetPop<T>( string setKey )
        {
            return Client.SetPop( setKey )
                         .ToString()
                         .JsonToObj<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="setKey"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<string> SetPop( string setKey, int count )
        {
            var result = new List<string>();

            for( int i = 1; i <= Math.Min( count, SetLength( setKey ) ); i++ )
            {
                result.Add( Client.SetPop( setKey ) + "" );
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <returns></returns>
        public T SetRandomMember<T>( string setKey )
        {
            return Client.SetRandomMember( setKey )
                         .ToString()
                         .JsonToObj<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<T> SetRandomMembers<T>( string setKey, int count )
        {
            return ConvertList<T>( Client.SetRandomMembers( setKey, count ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetRemove<T>( string setKey, T value )
        {
            return Client.SetRemove( setKey, value.ObjToJson() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <param name="pattern"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        public List<T> SetScan<T>( string setKey, string pattern, int pageSize, int pageNo )
        {
            return ConvertList<T>( Client.SetScan( setKey, pattern, pageSize, pageNo ).ToArray() );
        }

        #endregion

        #region SortedSet

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool SortedSetAdd<T>( string setKey, T value, double score )
        {
            return Client.SortedSetAdd( setKey, value.ObjToJson(), score );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public long SortedSetDifference<T>( string first, string second, string destination )
        {
            return Client.SortedSetCombineAndStore( SetOperation.Difference, destination, first, second );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public long SortedSetIntersect<T>( string first, string second, string destination )
        {
            return Client.SortedSetCombineAndStore( SetOperation.Intersect, destination, first, second );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public long SortedSetUnion<T>( string first, string second, string destination )
        {
            return Client.SortedSetCombineAndStore( SetOperation.Union, destination, first, second );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="setKey"></param>
        /// <returns></returns>
        public int SortedSetLength( string setKey )
        {
            return Convert.ToInt32( Client.SortedSetLength( setKey ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <returns></returns>
        public T SortedSetPop<T>( string setKey )
        {
            var obj = Client.SortedSetPop( setKey );
            return obj != null
                           ? ((SortedSetEntry)obj).Element.ToString().JsonToObj<T>()
                           : default(T);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        public List<T> SortedSetRangeByRank<T>( string setKey, int start, int stop )
        {
            return ConvertList<T>( Client.SortedSetRangeByRank( setKey, start, stop ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        public List<T> SortedSetRangeByScore<T>( string setKey, int start, int stop )
        {
            return ConvertList<T>( Client.SortedSetRangeByScore( setKey, start, stop ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long? SortedSetRank<T>( string setKey, T value )
        {
            return Client.SortedSetRank( setKey, value.ObjToJson() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SortedSetRemove<T>( string setKey, T value )
        {
            return Client.SortedSetRemove( setKey, value.ObjToJson() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public double? SortedSetScore<T>( string setKey, T value )
        {
            return Client.SortedSetScore( setKey, value.ObjToJson() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setKey"></param>
        /// <param name="pattern"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        public List<T> SortedSetScan<T>( string setKey, string pattern, int pageSize, int pageNo )
        {
            return ConvertList<T>( Client.SortedSetScan( setKey, pattern, pageSize, pageNo ).Select( o => o.Element ).ToArray() );
        }

        #endregion
    }
}