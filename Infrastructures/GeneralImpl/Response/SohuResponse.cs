//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-29
//  ————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

namespace Ban3.Infrastructures.GeneralImpl.Response;

/// 
public class SohuResponse
{
    /// 
    public static IEnumerable<IStockNotion> ResultToNotions( IInternetResponse callback )
    {
        return new List<IStockNotion>();
    }

    public static IEnumerable<IStock> ResultToStocks( IInternetResponse callback )
    {
        return new List<IStock>();
    }
}