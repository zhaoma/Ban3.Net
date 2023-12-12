//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-26
//  ————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;

///
public class StockTrigger : StockRecord, IStockRecord
{
    ///
    public string Code { get; set; }

    ///
    public TriggerIs TriggerIs { get; set; }

    ///
    public string Subject { get; set; }
}