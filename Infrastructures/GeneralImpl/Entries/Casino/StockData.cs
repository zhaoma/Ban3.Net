// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino;

public class StockData<T> : Stock, IStockData<T>
{
    public IEnumerable<T> Values { get; set; }
}