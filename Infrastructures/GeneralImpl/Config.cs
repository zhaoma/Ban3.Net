// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre;

using System;

namespace Ban3.Infrastructures.GeneralImpl;

///
public class Config : IConfig
{
    ///
    public T Read<T>( string filePath, Func<T> defaultValue = null )
    {
        return default( T );
    }
}