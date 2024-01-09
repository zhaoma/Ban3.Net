//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 空值扩展方法
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// Checks the on null.
    /// </summary>
    /// <param name="this">The @this.</param>
    /// <param name="parameterName">Name of the parameter.</param>
    public static void CheckOnNull( this object @this, string parameterName )
    {
        if( @this.IsNull() ) throw new ArgumentNullException( parameterName );
    }

    /// <summary>
    /// Checks the on null.
    /// </summary>
    /// <param name="this">The @this.</param>
    /// <param name="parameterName">Name of the parameter.</param>
    /// <param name="message">The message.</param>
    public static void CheckOnNull( this object @this, string parameterName, string message )
    {
        if( @this.IsNull() ) throw new ArgumentNullException( parameterName, message );
    }

    /// <summary>
    /// Determines whether the specified @this is null.
    /// </summary>
    /// <param name="this">The @this.</param>
    /// <returns>
    ///   <c>true</c> if the specified @this is null; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNull( this object? @this )
    {
        return @this == null;
    }

    /// <summary>
    /// Determines whether [is not null] [the specified @this].
    /// </summary>
    /// <param name="this">The @this.</param>
    /// <returns>
    ///   <c>true</c> if [is not null] [the specified @this]; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNotNull( this object @this )
    {
        return !@this.IsNull();
    }
}