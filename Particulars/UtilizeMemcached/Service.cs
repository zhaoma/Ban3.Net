/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma @ 2022 :
 * Memcached服务器访问接口实现
 * —————————————————————————————————————————————————————————————————————————————
 */
using System;

using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using Enyim.Caching.Memcached.

using log4net;
using Microsoft.Extensions.Configuration;
using ILog = log4net.ILog;

namespace Ban3.Infrastructures.Particulars.UtilizeMemcached
{
    /// <summary>
    /// Memcached服务器接口实现
    /// </summary>
    public class Service
            : Interfaces.Particulars.IMemcached
    {
        private readonly ILog _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public Service(ILog logger )
        {
            _logger = logger;
        }

        internal static readonly object Locker = new object();
        internal static MemcachedClient _instance;

        /// <summary>
        /// 单例获取
        /// </summary>
        public static MemcachedClient Instance
        {
            get
            {
                if( _instance == null )
                {
                    lock( Locker )
                    {
                        var loggerFactory = new LoggerFactory();
                        var options = new MemcachedClientOptions();
                        Common.Config.GetSection( "enyimMemcached" ).Bind( options );

                        _instance = new MemcachedClient(
                                                        loggerFactory,
                                                        new MemcachedClientConfiguration( loggerFactory, options ) );
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool Set( string key, object value )
        {
            bool result = true;

            try
            {
                Instance.Store( StoreMode.Set, key, value );
            }
            catch( Exception ex )
            {
                _logger.LogError( ex, null, null );
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public object Get( string key )
        {
            try
            {
                //enyim = new Enyim.Caching.MemcachedClient();
                Instance.Get( key );
            }
            catch( Exception ex )
            {
                _logger.LogError( ex, null, null );
            }

            return null;
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool Remove( string key )
        {
            bool result = true;
            try
            {
                Instance.Remove( key );
            }
            catch( Exception ex )
            {
                _logger.LogError( ex, null, null );
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Flushes all.
        /// </summary>
        /// <returns></returns>
        public bool FlushAll()
        {
            bool result = true;
            try
            {
                Instance.FlushAll();
            }
            catch( Exception ex )
            {
                _logger.LogError( ex, null, null );
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Increments the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="delta">The delta.</param>
        /// <returns></returns>
        public ulong Increment( string key, ulong defaultValue, ulong delta )
        {
            ulong result = 0;
            try
            {
                result = Instance.Increment( key, defaultValue, delta );
            }
            catch( Exception ex )
            {
                _logger.LogError( ex, null, null );
            }

            return result;
        }

        /// <summary>
        /// Decrements the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="delta">The delta.</param>
        /// <returns></returns>
        public ulong Decrement( string key, ulong defaultValue, ulong delta )
        {
            ulong result = 0;
            try
            {
                result = Instance.Decrement( key, defaultValue, delta );
            }
            catch( Exception ex )
            {
                _logger.LogError( ex, null, null );
            }

            return result;
        }
    }
}