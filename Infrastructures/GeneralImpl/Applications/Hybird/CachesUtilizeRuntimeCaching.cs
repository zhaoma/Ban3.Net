//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Models.Hybird;

using System.Threading.Tasks;
using System;
using System.Runtime.Caching;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

namespace Ban3.Infrastructures.GeneralImpl.Applications.Hybird;

/// 
public class CachesUtilizeRuntimeCaching : OneImplement, ICachesHelper
{
    /// 
    public async Task<bool> TrySet<T>( string key, T data, CachesProfile cachesProfile )
    {
        try
        {
            MemoryCache.Default.Set( key, data.ObjToJson(), Policy( cachesProfile ) );

            return await Task.FromResult( false );
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        return await Task.FromResult( false );
    }

    /// 
    public async Task<bool> TrySet<T>( T data, Func<T, string> getKey, CachesProfile cachesProfile )
        => await TrySet( getKey( data ), data, cachesProfile );

    /// 
    public async Task<T> TryGet<T>( string key )
    {
        try
        {
            var cached = MemoryCache.Default.Get( key ) + "";

            return await Task.FromResult( cached.JsonToObj<T>() );
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        return await Task.FromResult( default( T ) );
    }

    /// 
    public async Task<bool> TryRemove( string key )
    {
        try
        {
            MemoryCache.Default.Remove( key );

            return await Task.FromResult( false );
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        return await Task.FromResult( false );
    }

    /// 
    public async Task<bool> TryFlush()
        => await Task.FromResult( false );

    /// 
    private CacheItemPolicy Policy( CachesProfile profile )
        => profile.CacheDependency switch
        {
            CacheDependency.AbsoluteTime
                => new CacheItemPolicy
                {
                    AbsoluteExpiration = new DateTimeOffset( profile.AbsoluteTime!.Value )
                },
            CacheDependency.File
                => new CacheItemPolicy
                {
                    Priority = CacheItemPriority.Default,
                    ChangeMonitors = { new HostFileChangeMonitor( new[] { profile.File } ) }
                },
            CacheDependency.RelativeTime
                => new CacheItemPolicy
                {
                    SlidingExpiration = profile.RelativeTime!.Value
                },
            CacheDependency.None
                => new CacheItemPolicy
                {
                    Priority = CacheItemPriority.NotRemovable
                },
            _ => new CacheItemPolicy()
        };
}