using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;

using Ban3.Protocols.Rfc2445.Interfaces;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 序列化与解析类
    /// </summary>
    public class Serializer
    {
        /// <summary>
        /// 
        /// </summary>
        public Func<Type, object> DependencyResolver { get; set; }

        private ConcurrentDictionary<Type, Type> _cache = new ConcurrentDictionary<Type, Type>();

        /// <summary>
        /// 
        /// </summary>
        public Serializer()
        {
            Encoding = new System.Text.UTF8Encoding( false );
        }

        /// <summary>
        /// 
        /// </summary>
        public System.Text.Encoding Encoding { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T GetService<T>()
        {
            if( DependencyResolver == null )
            {
                DependencyResolver = type =>
                {
                    type = _cache.GetOrAdd( type, t =>
                                                    typeof( Serializer ).Assembly.GetTypes()
                                                                        .FirstOrDefault( x => x.IsClass && !x.IsAbstract && x.IsAssignableFrom( type ) )
                                          );
                    return Activator.CreateInstance( type );
                };
            }

            return (T)DependencyResolver( typeof( T ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public T Deserialize<T>( string filename, System.Text.Encoding? encoding = null ) where T : ISerializeToICAL
        {
            using( var file = new System.IO.FileStream( filename, FileMode.Open ) )
                return Deserialize<T>( file, encoding );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public T Deserialize<T>( Stream stream, System.Text.Encoding? encoding = null ) where T : ISerializeToICAL
        {
            using( var rdr = new StreamReader( stream, encoding ?? Encoding ) )
                return Deserialize<T>( rdr );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rdr"></param>
        /// <returns></returns>
        public virtual T Deserialize<T>( TextReader rdr ) where T : ISerializeToICAL
        {
            var obj = GetService<T>();
            obj.Deserialize( rdr, this );
            return obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <param name="obj"></param>
        /// <param name="encoding"></param>
        public void Serialize<T>( string filename, T obj, System.Text.Encoding? encoding = null )
                where T : ISerializeToICAL
        {
            using( var file = new System.IO.FileStream( filename, FileMode.Create ) )
                Serialize( file, obj, encoding );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="encoding"></param>
        public void Serialize<T>( Stream stream, T obj, System.Text.Encoding? encoding = null ) where T : ISerializeToICAL
        {
            if( obj == null ) return;
            using( var wrtr = new StreamWriter( stream, encoding ?? Encoding ) )
                Serialize( wrtr, obj );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="wrtr"></param>
        /// <param name="obj"></param>
        public virtual void Serialize<T>( TextWriter wrtr, T obj ) where T : ISerializeToICAL
        {
            if( obj == null ) return;
            obj.Serialize( wrtr );
        }
    }
}