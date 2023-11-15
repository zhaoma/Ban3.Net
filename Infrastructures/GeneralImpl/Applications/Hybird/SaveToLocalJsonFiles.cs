// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

namespace Ban3.Infrastructures.GeneralImpl.Applications.Hybird;

/// <summary>
/// 数据存储的本地json文件实现
/// </summary>
public class SaveToLocalJsonFiles : OneImplement, IStoragesHelper
{
    /// 
    public async Task<bool> TrySave<T>( T data, Func<T, string> getKey )
        => await TrySave( data, getKey( data ) );

    /// 
    public async Task<bool> TrySave<T>( T data, string key )
        => await JsonFilePath<T>( key ).WriteFileAsync( data.ObjToJson() );

    /// 
    public async Task<T> TryLoad<T>( string key )
    {
        var content = await JsonFilePath<T>( key ).ReadFileAsync();
        return content.JsonToObj<T>();
    }

    /// 
    public async Task<bool> TryDelete<T>( T data, Func<T, string> getKey )
        => await TryDelete<T>( getKey( data ) );

    /// 
    public async Task<bool> TryDelete<T>( string key )
    {
        try
        {
            File.Delete( JsonFilePath<T>( key ) );
            return await Task.FromResult( true );
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        return await Task.FromResult( false );
    }

    /// 
    public async Task<bool> TryQuery<T>( Predicate<T> predicate, Action<IEnumerable<T>> action )
    {
        try
        {
            var content = await JsonFilePath<T>().ReadFileAsync();
            var result = content.JsonToObj<List<T>>()
                                .Where( t => predicate( t ) );
            action( result );
            return await Task.FromResult( true );
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        return await Task.FromResult( false );
    }

    private string JsonFilePath<T>( string key = "all" )
    {
        var path = Path.Combine( Common.Config.LocalStorage!.RootPath, typeof( T ).Name );
        if( !Directory.Exists( path ) )
        {
            Directory.CreateDirectory( path );
        }

        return Path.Combine( path, $"{key}.json" );
    }
}