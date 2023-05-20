using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaTushare.Entries;

public class StockBasic
{
    [JsonIgnore] public List<string> RequestFields = new()
    {
        "ts_code", "symbol", "name", "list_date"
    };
    
    public string Code { get; set; }

    public string Symbol { get; set; }

    public string Name { get; set; }

    public string ListDate { get; set; }

    public StockBasic(){}

    public StockBasic(List<string> row)
    {
        Code = row[0];
        Symbol = row[1];
        Name = row[2];
        ListDate = row[3];
    }
}