// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino;

///
public class StockData<T> : Stock, IStockData<T>
{
    ///
    public StockData( IStock stock )
    {
        Code = stock.Code;
        Name = stock.Name;
        Symbol = stock.Symbol;
        ListDate = stock.ListDate;
        Values = new List<T>();
    }

    ///
    public IEnumerable<T> Values { get; set; }
}