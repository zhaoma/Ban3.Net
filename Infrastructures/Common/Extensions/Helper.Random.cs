//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 随机值生成
/// </summary>
public static partial class Helper
{
    /// 
    public static bool NextBool( this Random random )
    {
        return random.NextDouble() > 0.5;
    }

    /// 
    public static T NextEnum<T>( this Random random ) where T : struct
    {
        Type type = typeof( T );
        if( type.IsEnum == false ) throw new InvalidOperationException();

        var array = Enum.GetValues( type );
        var index = random.Next( array.GetLowerBound( 0 ), array.GetUpperBound( 0 ) + 1 );
        return (T)array.GetValue( index );
    }

    /// 
    public static byte[] NextBytes( this Random random, int length )
    {
        var data = new byte[length];
        random.NextBytes( data );
        return data;
    }

    /// 
    public static UInt16 NextUInt16( this Random random )
    {
        return BitConverter.ToUInt16( random.NextBytes( 2 ), 0 );
    }

    /// 
    public static Int16 NextInt16( this Random random )
    {
        return BitConverter.ToInt16( random.NextBytes( 2 ), 0 );
    }

    /// 
    public static float NextFloat( this Random random )
    {
        return BitConverter.ToSingle( random.NextBytes( 4 ), 0 );
    }

    /// 
    public static DateTime NextDateTime( this Random random, DateTime minValue, DateTime maxValue )
    {
        var ticks = minValue.Ticks + (long)( ( maxValue.Ticks - minValue.Ticks ) * random.NextDouble() );
        return new DateTime( ticks );
    }

    /// 
    public static DateTime NextDateTime( this Random random )
    {
        return NextDateTime( random, DateTime.MinValue, DateTime.MaxValue );
    }
}