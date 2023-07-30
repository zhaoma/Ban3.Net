/* —————————————————————————————————————————————————————————————————————————————
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

namespace Ban3.Particulars.UtilizeRedis;

/// <summary>
/// Redis服务器访问接口实现
/// </summary>
public class Service
        : Interfaces.IKeyAndString, Interfaces.IList,Interfaces.ISet,Interfaces.ISortedSet
{
    private readonly ILog _logger = LogManager.GetLogger(typeof(Service));

     static readonly object Locker = new object();
    static Models.Server _server;
     static ConnectionMultiplexer? _instance;

    static Service() {
        _server = new Models.Server
        {
            Endpoints=Infrastructures.Common.Config.GetValue("Redis:Endpoints")+"",
            Password = Infrastructures.Common.Config.GetValue("Redis:Password") + "",
            DbNumber= (Infrastructures.Common.Config.GetValue("Redis:DbNumber") + "").ToInt(),
            KeepAlive = (Infrastructures.Common.Config.GetValue("Redis:KeepAlive") + "").ToInt()
        };
    }

    /// <summary>
    /// 单例获取
    /// </summary>
     ConnectionMultiplexer? Instance
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
     ConnectionMultiplexer? GetManager()
    {
        if(! _server.HasValue())
            return null;

        var config = new ConfigurationOptions
        {
                Password = _server.Password,
                EndPoints = { _server.Endpoints },
                KeepAlive = _server.KeepAlive
        };

        var connect = ConnectionMultiplexer.Connect( config );

        if (MuxerConnectionFailed != null)
            connect.ConnectionFailed += MuxerConnectionFailed;

        if (MuxerConnectionRestored != null)
            connect.ConnectionRestored += MuxerConnectionRestored;

        if (MuxerErrorMessage != null)
            connect.ErrorMessage += MuxerErrorMessage;

        if (MuxerConfigurationChanged != null)
            connect.ConfigurationChanged += MuxerConfigurationChanged;

        if (MuxerHashSlotMoved != null)
            connect.HashSlotMoved += MuxerHashSlotMoved;

        if (MuxerInternalError != null)
            connect.InternalError += MuxerInternalError;

        return connect;
    }

    /// <summary>
    /// 
    /// </summary>
    public IDatabase? Client => Instance != null ? Instance.GetDatabase(_server.DbNumber) : null;

    /// <summary>
    /// 
    /// </summary>
    public ISubscriber? Subscriber => Instance != null ? Instance.GetSubscriber() : null;

    #region 事件

    /// <summary>
    /// 配置更改时
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public EventHandler<EndPointEventArgs>? MuxerConfigurationChanged;

    /// <summary>
    /// 发生错误时
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public EventHandler<RedisErrorEventArgs>? MuxerErrorMessage;

    /// <summary>
    /// 重新建立连接之前的错误
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public EventHandler<ConnectionFailedEventArgs>? MuxerConnectionRestored;

    /// <summary>
    /// 连接失败 ， 如果重新连接成功你将不会收到这个通知
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public EventHandler<ConnectionFailedEventArgs>? MuxerConnectionFailed;

    /// <summary>
    /// 更改集群
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public EventHandler<HashSlotMovedEventArgs>? MuxerHashSlotMoved;

    /// <summary>
    /// redis类库错误
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public EventHandler<InternalErrorEventArgs>? MuxerInternalError;

    #endregion 事件

    #region Private

    T? ConvertOne<T>(RedisValue val)
        => val.ToString().JsonToObj<T>();

    List<T?> ConvertList<T>( RedisValue[] values )
	=> values.Select(o => ConvertOne<T>(o)).ToList();

    RedisValue[] ConvertRedisValue<T>( params T[] redisValues ) =>
            redisValues.Select( o => (RedisValue)(o!.ObjToJson()) ).ToArray();

    RedisKey[] ConvertRedisKeys( params string[] redisKeys ) =>
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
    public TimeSpan Ping() => Client != null ? Client.Ping() : new TimeSpan();

    /// <summary>
    /// 链接？
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool IsConnected(string key) => Client != null ? Client.IsConnected(key) : false;

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
    public T? StringGet<T>( string key )
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
    public long HashDecrement(string hashKey, string hashField)
=> Client != null ? Client.HashDecrement(hashKey, hashField) : 0;

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
        return Client!.HashIncrement( hashKey, hashField );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hashKey"></param>
    /// <returns></returns>
    public int HashLength( string hashKey )
    {
        return Convert.ToInt32( Client!.HashLength( hashKey ) );
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
        return ConvertList<T>( data ).ToList();
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

    public bool SetAdd<T>(string setKey, T value) => Client.SetAdd(setKey, value.ObjToJson());

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

    public List<T> SetDifference<T>(string first, string second) => ConvertList<T>(Client.SetCombine(SetOperation.Difference, first, second));

    public List<T> SetIntersect<T>(string first, string second) => ConvertList<T>(Client.SetCombine(SetOperation.Intersect, first, second));

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

    public List<T> SetUnion<T>(string first, string second) => ConvertList<T>(Client.SetCombine(SetOperation.Union, first, second));

    public bool SetContains<T>(string setKey, T value) => Client.SetContains(setKey, value.ObjToJson());

    public int SetLength(string setKey) => Convert.ToInt32(Client.SetLength(setKey));

    public List<T> SetMembers<T>(string setKey) => ConvertList<T>(Client.SetMembers(setKey));

    public bool SetMove<T>(string source, string destination, T value) => Client.SetMove(source, destination, value.ObjToJson());

    public T SetPop<T>(string setKey) => Client.SetPop(setKey).ToString().JsonToObj<T>();

    public IEnumerable<string> SetPop( string setKey, int count )
    {
        var result = new List<string>();

        for( int i = 1; i <= Math.Min( count, SetLength( setKey ) ); i++ )
        {
            result.Add( Client.SetPop( setKey ) + "" );
        }

        return result;
    }

    public T SetRandomMember<T>( string setKey )
    {
        return Client.SetRandomMember( setKey )
                     .ToString()
                     .JsonToObj<T>();
    }

    public List<T> SetRandomMembers<T>( string setKey, int count )
    {
        return ConvertList<T>( Client.SetRandomMembers( setKey, count ) );
    }

    public bool SetRemove<T>(string setKey, T value) => Client.SetRemove(setKey, value.ObjToJson());

    public List<T> SetScan<T>(string setKey, string pattern, int pageSize, int pageNo) => ConvertList<T>(Client.SetScan(setKey, pattern, pageSize, pageNo).ToArray());

    #endregion

    #region SortedSet

    public bool SortedSetAdd<T>( string setKey, T value, double score )
    {
        return Client.SortedSetAdd( setKey, value.ObjToJson(), score );
    }

    public long SortedSetDifference<T>( string first, string second, string destination )
    {
        return Client.SortedSetCombineAndStore( SetOperation.Difference, destination, first, second );
    }

    public long SortedSetIntersect<T>( string first, string second, string destination )
    {
        return Client.SortedSetCombineAndStore( SetOperation.Intersect, destination, first, second );
    }

    public long SortedSetUnion<T>( string first, string second, string destination )
    {
        return Client.SortedSetCombineAndStore( SetOperation.Union, destination, first, second );
    }

    public int SortedSetLength( string setKey )
    {
        return Convert.ToInt32( Client.SortedSetLength( setKey ) );
    }

    public T SortedSetPop<T>( string setKey )
    {
        var obj = Client.SortedSetPop( setKey );
        return obj != null
                       ? ((SortedSetEntry)obj).Element.ToString().JsonToObj<T>()
                       : default(T);
    }

    public List<T?> SortedSetRangeByRank<T>( string setKey, int start, int stop )
    {
        return ConvertList<T>( Client.SortedSetRangeByRank( setKey, start, stop ) );
    }

    public List<T> SortedSetRangeByScore<T>( string setKey, int start, int stop )
    {
        return ConvertList<T>( Client.SortedSetRangeByScore( setKey, start, stop ) );
    }

    public long? SortedSetRank<T>( string setKey, T value )
    {
        return Client.SortedSetRank( setKey, value.ObjToJson() );
    }

    public bool SortedSetRemove<T>( string setKey, T value )
    {
        return Client.SortedSetRemove( setKey, value.ObjToJson() );
    }

    public double? SortedSetScore<T>( string setKey, T value )
    {
        return Client.SortedSetScore( setKey, value.ObjToJson() );
    }

    public List<T> SortedSetScan<T>( string setKey, string pattern, int pageSize, int pageNo )
    {
        return ConvertList<T>( Client.SortedSetScan( setKey, pattern, pageSize, pageNo ).Select( o => o.Element ).ToArray() );
    }

    #endregion
}