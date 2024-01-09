//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using log4net;

namespace Ban3.Infrastructures.ServiceCentre.Applications;

/// <summary>
/// 实现的基类 
/// </summary>
public abstract class OneImplement
{
    public readonly ILog Logger = LogManager.GetLogger( typeof( OneImplement ) );
}